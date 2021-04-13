using AutoNauta.Model;
using AutoNauta.Util;
using AutoNauta.View;
using System.Net.Http;


namespace AutoNauta.Controller
{
    public class ConnectionController
    {
        private IMainForm form;

        private string domain = "";
        public string remainingTime { get; set; } = "";

        private static readonly HttpClient httpClient = new HttpClient();

        public RegistryController registry = new RegistryController();

        public QueryConnectParams connectParams = new QueryConnectParams();
        public QueryRefreshParams refreshParams = new QueryRefreshParams();
        public QueryDisconnectParams disconnectParams = new QueryDisconnectParams();

        public ConnStatus status = new ConnStatus();

        public ConnectionController(string domain, IMainForm form)
        {
            this.form = form;
            this.domain = domain;
        }

        public async void Connect()
        {
            var response = await httpClient.PostAsync(domain + "LoginServlet",
                                                      connectParams.GetHttpContent());
            var responseString = await response.Content.ReadAsStringAsync();

            if (responseString.Contains("ATTRIBUTE_UUID=") && responseString.Contains("CSRFHW="))
            {
                disconnectParams.ATTRIBUTE_UUID = StringUtil.GetBetween(responseString, "ATTRIBUTE_UUID=", "&");
                disconnectParams.CSRFHW = StringUtil.GetBetween(responseString, "CSRFHW=", "\"");
                disconnectParams.domain = StringUtil.GetBetween(responseString, "domain=", "\"");
                disconnectParams.loggerId = StringUtil.GetBetween(responseString, "loggerId=", "\"");
                disconnectParams.ssid = StringUtil.GetBetween(responseString, "ssid=", "\"");
                disconnectParams.username = StringUtil.GetBetween(responseString, "username=", "\"");
                disconnectParams.wlanacname = StringUtil.GetBetween(responseString, "wlanacname=", "\"");
                disconnectParams.wlanmac = StringUtil.GetBetween(responseString, "wlanmac=", "\"");
                disconnectParams.wlanuserip = StringUtil.GetBetween(responseString, "wlanuserip=", "\"");

                status.connected = "1";

                form.OnConnected();

                registry.Save(disconnectParams);
                registry.Save(status);
                registry.Save(refreshParams);

                Refresh();
            }
        }

        public async void Refresh()
        {
            registry.Load(refreshParams);

            var response = await httpClient.PostAsync(domain + "EtecsaQueryServlet",
                                                      refreshParams.GetHttpContent());
            remainingTime = await response.Content.ReadAsStringAsync();

            form.OnRefreshed();
        }

        public async void Disconnect()
        {
            registry.Load(disconnectParams);

            var response = await httpClient.PostAsync(domain + "LogoutServlet",
                                                      disconnectParams.GetHttpContent());
            var responseString = await response.Content.ReadAsStringAsync();

            status.connected = responseString.Contains("SUCCESS") ? "0" : "1";

            registry.Save(status);

            form.OnDisconnected();
        }

        internal void SaveConfig()
        {
            registry.Save(connectParams);
        }

        internal void LoadConfig()
        {
            registry.Load(connectParams);
            registry.Load(status);
        }
    }
}