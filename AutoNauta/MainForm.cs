using System;
using System.Windows.Forms;
using System.Net.Http;
using AutoNauta.Model;
using System.Collections.Generic;

namespace AutoNauta
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private ConnectURLParams cURLParams = new ConnectURLParams();
        private DisconnectURLParams dURLParams = new DisconnectURLParams();

        private Dictionary<string, string> btnConnectionText = new Dictionary<string, string>
            {
                { "1", "Disconnect" },
                { "0", "Connect" }
            };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();    
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        async void connect()
        {
            var response = await httpClient.PostAsync("https://secure.etecsa.net:8443/LoginServlet", cURLParams.getHttpContent());

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                dURLParams.ATTRIBUTE_UUID = getBetween(responseString, "ATTRIBUTE_UUID=", "&");
                dURLParams.CSRFHW = getBetween(responseString, "CSRFHW=", "\"");
                dURLParams.domain = getBetween(responseString, "domain=", "\"");
                dURLParams.loggerId = getBetween(responseString, "loggerId=", "\"");
                dURLParams.ssid = getBetween(responseString, "ssid=", "\"");
                dURLParams.username = getBetween(responseString, "username=", "\"");
                dURLParams.wlanacname = getBetween(responseString, "wlanacname=", "\"");
                dURLParams.wlanmac = getBetween(responseString, "wlanmac=", "\"");
                dURLParams.wlanuserip = getBetween(responseString, "wlanuserip=", "\"");

                dURLParams.saveToRegistry();

                cURLParams.connected = "1";
                cURLParams.saveToRegistry();
                btnConnection.Text = btnConnectionText[cURLParams.connected];
            }
        }

        async void disconnect()
        {
            var response = await httpClient.PostAsync("https://secure.etecsa.net:8443/LogoutServlet", dURLParams.getHttpContent());

            var responseString = await response.Content.ReadAsStringAsync();

            if (responseString.Contains("SUCCESS"))
            {
                cURLParams.connected = "0";
                cURLParams.saveToRegistry();
                btnConnection.Text = btnConnectionText[cURLParams.connected];
            }
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (cURLParams.connected.Equals("1"))
                disconnect(); 
            else
                connect();
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // TODO: Check for empty or invalid fields...
            cURLParams.username = editUsername.Text;
            cURLParams.password = editPassword.Text;

            cURLParams.saveToRegistry();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cURLParams.loadFromRegistry();
            if (cURLParams.connected != null)
                btnConnection.Text = btnConnectionText[cURLParams.connected];

            editUsername.Text = cURLParams.username;
            editPassword.Text = cURLParams.password;
        }
    }
}
