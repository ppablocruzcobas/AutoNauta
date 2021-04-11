namespace AutoNauta
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.editUsername = new DevExpress.XtraEditors.TextEdit();
            this.editPassword = new DevExpress.XtraEditors.TextEdit();
            this.lbUsername = new DevExpress.XtraEditors.LabelControl();
            this.lbPassword = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AutoNauta";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRestore,
            this.btnClose,
            this.btnConnection});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(120, 70);
            // 
            // btnRestore
            // 
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(180, 22);
            this.btnRestore.Text = "Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(180, 22);
            this.btnConnection.Text = "Connect";
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // editUsername
            // 
            this.editUsername.Location = new System.Drawing.Point(83, 12);
            this.editUsername.Name = "editUsername";
            this.editUsername.Size = new System.Drawing.Size(100, 20);
            this.editUsername.TabIndex = 1;
            // 
            // editPassword
            // 
            this.editPassword.Location = new System.Drawing.Point(83, 38);
            this.editPassword.Name = "editPassword";
            this.editPassword.Size = new System.Drawing.Size(100, 20);
            this.editPassword.TabIndex = 2;
            // 
            // lbUsername
            // 
            this.lbUsername.Location = new System.Drawing.Point(12, 15);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(48, 13);
            this.lbUsername.TabIndex = 3;
            this.lbUsername.Text = "Username";
            // 
            // lbPassword
            // 
            this.lbPassword.Location = new System.Drawing.Point(12, 41);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(46, 13);
            this.lbPassword.TabIndex = 4;
            this.lbPassword.Text = "Password";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(108, 64);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 99);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.editPassword);
            this.Controls.Add(this.editUsername);
            this.Name = "MainForm";
            this.Text = "AutoNauta";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem btnRestore;
        private System.Windows.Forms.ToolStripMenuItem btnClose;
        private System.Windows.Forms.ToolStripMenuItem btnConnection;
        private DevExpress.XtraEditors.TextEdit editUsername;
        private DevExpress.XtraEditors.TextEdit editPassword;
        private DevExpress.XtraEditors.LabelControl lbUsername;
        private DevExpress.XtraEditors.LabelControl lbPassword;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}

