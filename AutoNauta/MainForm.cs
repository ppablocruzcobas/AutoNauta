using System;
using System.Windows.Forms;
using System.Net.Http;
using AutoNauta.Model;

namespace AutoNauta
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private bool connected = false;

        private ConnectURLParams cURLParams = new ConnectURLParams();
        private DisconnectURLParams dURLParams = new DisconnectURLParams();

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

                btnConnection.Text = "Disconnect";
                connected = true;
            }
        }

        async void disconnect()
        {
            var response = await httpClient.PostAsync("https://secure.etecsa.net:8443/LogoutServlet", dURLParams.getHttpContent());

            var responseString = await response.Content.ReadAsStringAsync();

            if (responseString.Contains("SUCCESS"))
            {
                btnConnection.Text = "Connect";
                connected = false;
            }
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                disconnect(); 
            }
            else
            {
                connect();
                btnConnection.Text = "Disconnect";
                connected = true;
            }
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

            editUsername.Text = cURLParams.username;
            editPassword.Text = cURLParams.password;
        }
    }
}
