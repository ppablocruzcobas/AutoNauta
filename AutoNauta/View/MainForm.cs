using System;
using System.Windows.Forms;
using System.Collections.Generic;
using AutoNauta.Controller;
using AutoNauta.View;

namespace AutoNauta
{
    public partial class MainForm : Form, IMainForm
    {
        private Dictionary<string, string> btnConnectionText =
            new Dictionary<string, string>
            {
                { "1", "Disconnect" },
                { "0", "Connect" }
            };

        private ConnectionController connectionController;
            

        public MainForm()
        {
            InitializeComponent();

            connectionController = new ConnectionController("https://secure.etecsa.net:8443/", this);
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

        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (connectionController.status.connected.Equals("1"))
                connectionController.Disconnect();
            else
                connectionController.Connect();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // TODO: Check for empty or invalid fields...
            connectionController.connectParams.username = editUsername.Text;
            connectionController.connectParams.password = editPassword.Text;

            connectionController.SaveConfig();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Hide();

            connectionController.LoadConfig();

            btnConnection.Text = btnConnectionText[connectionController.status.connected];

            if (connectionController.status.connected.Equals("1"))
                connectionController.Refresh();

            editUsername.Text = connectionController.connectParams.username;
            editPassword.Text = connectionController.connectParams.password;
        }

        public void OnConnected()
        {
            timer.Start();

            btnConnection.Text = btnConnectionText[connectionController.status.connected];
            textTime.Visible = connectionController.status.connected.Equals("1");
        }

        public void OnDisconnected()
        {
            timer.Stop();

            btnConnection.Text = btnConnectionText[connectionController.status.connected];
            textTime.Visible = connectionController.status.connected.Equals("1");
        }

        public void OnRefreshed()
        {
            textTime.Text = connectionController.remainingTime;
            textTime.Visible = connectionController.status.connected.Equals("1");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (connectionController.status.connected.Equals("1"))
                connectionController.Refresh();
        }
    }
}
