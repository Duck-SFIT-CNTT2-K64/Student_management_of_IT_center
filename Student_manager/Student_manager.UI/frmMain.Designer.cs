using AntdUI;
using System.Drawing;
using System.Windows.Forms;

namespace Student_manager.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Designer fields
        private AntdUI.Panel panelHeader;
        private AntdUI.Label labelGTVT;
        private AntdUI.Button btnLogin;
        private AntdUI.Panel LoginPanel;
        private AntdUI.Panel panelLogoRight;
        private AntdUI.Panel LoginPanelLeft;
        private AntdUI.Input txtUser;
        private AntdUI.Label labelText;
        private AntdUI.Label labelUser;
        private AntdUI.Label labelPassword;
        private AntdUI.Button buttonOut;
        private AntdUI.Button buttonLogin;
        private AntdUI.Checkbox checkboxPassword;
        private AntdUI.Input txtPassword;
        #endregion

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
        /// Required method for Designer support — do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelHeader = new AntdUI.Panel();
            this.btnOutHeader = new AntdUI.Button();
            this.labelLogo = new AntdUI.Label();
            this.btnLogin = new AntdUI.Button();
            this.labelGTVT = new AntdUI.Label();
            this.LoginPanel = new AntdUI.Panel();
            this.LoginPanelLeft = new AntdUI.Panel();
            this.labelText = new AntdUI.Label();
            this.labelUser = new AntdUI.Label();
            this.txtUser = new AntdUI.Input();
            this.labelPassword = new AntdUI.Label();
            this.txtPassword = new AntdUI.Input();
            this.checkboxPassword = new AntdUI.Checkbox();
            this.buttonLogin = new AntdUI.Button();
            this.buttonOut = new AntdUI.Button();
            this.panelLogoRight = new AntdUI.Panel();
            this.panelHeader.SuspendLayout();
            this.LoginPanel.SuspendLayout();
            this.LoginPanelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Back = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelHeader.BackColor = System.Drawing.Color.Transparent;
            this.panelHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelHeader.BackgroundImage")));
            this.panelHeader.Controls.Add(this.btnOutHeader);
            this.panelHeader.Controls.Add(this.labelLogo);
            this.panelHeader.Controls.Add(this.btnLogin);
            this.panelHeader.Controls.Add(this.labelGTVT);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1446, 110);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Text = "panelHeader";
            // 
            // btnOutHeader
            // 
            this.btnOutHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutHeader.Location = new System.Drawing.Point(1039, 12);
            this.btnOutHeader.Name = "btnOutHeader";
            this.btnOutHeader.Size = new System.Drawing.Size(350, 79);
            this.btnOutHeader.TabIndex = 3;
            this.btnOutHeader.Text = "THOÁT NGAY";
            this.btnOutHeader.Type = AntdUI.TTypeMini.Error;
            this.btnOutHeader.Click += new System.EventHandler(this.btnOutHeader_Click);
            // 
            // labelLogo
            // 
            this.labelLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("labelLogo.BackgroundImage")));
            this.labelLogo.Location = new System.Drawing.Point(45, 0);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(108, 108);
            this.labelLogo.TabIndex = 2;
            this.labelLogo.Text = "";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(683, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(350, 79);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "ĐĂNG NHẬP HỆ THỐNG";
            this.btnLogin.Type = AntdUI.TTypeMini.Primary;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // labelGTVT
            // 
            this.labelGTVT.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGTVT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.labelGTVT.Location = new System.Drawing.Point(179, 44);
            this.labelGTVT.Name = "labelGTVT";
            this.labelGTVT.Size = new System.Drawing.Size(532, 40);
            this.labelGTVT.TabIndex = 0;
            this.labelGTVT.Text = "TRƯỜNG ĐẠI HỌC GIAO THÔNG VẬN TẢI";
            // 
            // LoginPanel
            // 
            this.LoginPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LoginPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoginPanel.BackgroundImage")));
            this.LoginPanel.Controls.Add(this.LoginPanelLeft);
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(1446, 850);
            this.LoginPanel.TabIndex = 3;
            this.LoginPanel.Visible = false;
            // 
            // LoginPanelLeft
            // 
            this.LoginPanelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LoginPanelLeft.Controls.Add(this.labelText);
            this.LoginPanelLeft.Controls.Add(this.labelUser);
            this.LoginPanelLeft.Controls.Add(this.txtUser);
            this.LoginPanelLeft.Controls.Add(this.labelPassword);
            this.LoginPanelLeft.Controls.Add(this.txtPassword);
            this.LoginPanelLeft.Controls.Add(this.checkboxPassword);
            this.LoginPanelLeft.Controls.Add(this.buttonLogin);
            this.LoginPanelLeft.Controls.Add(this.buttonOut);
            this.LoginPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.LoginPanelLeft.Name = "LoginPanelLeft";
            this.LoginPanelLeft.Padding = new System.Windows.Forms.Padding(20);
            this.LoginPanelLeft.Size = new System.Drawing.Size(450, 479);
            this.LoginPanelLeft.TabIndex = 0;
            // 
            // labelText
            // 
            this.labelText.Font = new System.Drawing.Font("Segoe UI", 21.2F, System.Drawing.FontStyle.Bold);
            this.labelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(90)))));
            this.labelText.Location = new System.Drawing.Point(55, 30);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(360, 40);
            this.labelText.TabIndex = 7;
            this.labelText.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // labelUser
            // 
            this.labelUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelUser.Location = new System.Drawing.Point(45, 90);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(360, 20);
            this.labelUser.TabIndex = 5;
            this.labelUser.Text = "Tài khoản:";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUser.Location = new System.Drawing.Point(45, 132);
            this.txtUser.Name = "txtUser";
            this.txtUser.PlaceholderText = "Nhập tài khoản...";
            this.txtUser.Size = new System.Drawing.Size(360, 36);
            this.txtUser.TabIndex = 6;
            // 
            // labelPassword
            // 
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPassword.Location = new System.Drawing.Point(45, 199);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(360, 20);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPassword.Location = new System.Drawing.Point(45, 225);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.PlaceholderText = "Nhập mật khẩu...";
            this.txtPassword.Size = new System.Drawing.Size(360, 36);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // checkboxPassword
            // 
            this.checkboxPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkboxPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkboxPassword.Location = new System.Drawing.Point(45, 298);
            this.checkboxPassword.Name = "checkboxPassword";
            this.checkboxPassword.Size = new System.Drawing.Size(200, 24);
            this.checkboxPassword.TabIndex = 2;
            this.checkboxPassword.Text = "Hiển thị mật khẩu";
            this.checkboxPassword.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.Location = new System.Drawing.Point(45, 339);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(360, 44);
            this.buttonLogin.TabIndex = 1;
            this.buttonLogin.Text = "Đăng nhập";
            this.buttonLogin.Type = AntdUI.TTypeMini.Primary;
            this.buttonLogin.Click += new System.EventHandler(this.BtnLoginMain_Click);
            // 
            // buttonOut
            // 
            this.buttonOut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonOut.Location = new System.Drawing.Point(45, 401);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(360, 44);
            this.buttonOut.TabIndex = 0;
            this.buttonOut.Text = "Thoát ngay";
            this.buttonOut.Type = AntdUI.TTypeMini.Error;
            this.buttonOut.Click += new System.EventHandler(this.BtnOut_Click);
            // 
            // panelLogoRight
            // 
            this.panelLogoRight.Location = new System.Drawing.Point(640, 0);
            this.panelLogoRight.Name = "panelLogoRight";
            this.panelLogoRight.Size = new System.Drawing.Size(220, 520);
            this.panelLogoRight.TabIndex = 1;
            this.panelLogoRight.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(28)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1446, 850);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.LoginPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.panelHeader.ResumeLayout(false);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label labelLogo;
        private AntdUI.Button btnOutHeader;
    }
}

