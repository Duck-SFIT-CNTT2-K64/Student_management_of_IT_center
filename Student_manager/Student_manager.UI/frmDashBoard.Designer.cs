using AntdUI;
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Student_manager.UI
{
    partial class frmDashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private AntdUI.Label lblTitle;
        private AntdUI.Label lblUser;
        private System.Windows.Forms.Panel panelNav;
        private FlowLayoutPanel navFlow;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelDivider;
        private FontAwesome.Sharp.IconButton btnExit;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashBoard));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new AntdUI.Label();
            this.lblTitle = new AntdUI.Label();
            this.lblUser = new AntdUI.Label();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.panelNav = new System.Windows.Forms.Panel();
            this.navFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDivider = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.panelNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblUser);
            this.panelHeader.Controls.Add(this.btnExit);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(12);
            this.panelHeader.Size = new System.Drawing.Size(1217, 118);
            this.panelHeader.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("label1.BackgroundImage")));
            this.label1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 111);
            this.label1.TabIndex = 2;
            this.label1.Text = "";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSizeMode = AntdUI.TAutoSize.Auto;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(133, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(637, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ - DASHBOARD";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSizeMode = AntdUI.TAutoSize.Auto;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblUser.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUser.Location = new System.Drawing.Point(1967, 28);
            this.lblUser.Name = "lblUser";
            this.lblUser.Padding = new System.Windows.Forms.Padding(0, 0, 115, 0);
            this.lblUser.Size = new System.Drawing.Size(316, 43);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "User: -  Role: -";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnExit.IconColor = System.Drawing.Color.Red;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 32;
            this.btnExit.Location = new System.Drawing.Point(1120, 24);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(15);
            this.btnExit.Size = new System.Drawing.Size(60, 60);
            this.btnExit.TabIndex = 3;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panelNav.Controls.Add(this.navFlow);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNav.Location = new System.Drawing.Point(0, 118);
            this.panelNav.Name = "panelNav";
            this.panelNav.Padding = new System.Windows.Forms.Padding(12);
            this.panelNav.Size = new System.Drawing.Size(320, 682);
            this.panelNav.TabIndex = 2;
            // 
            // navFlow
            // 
            this.navFlow.AutoScroll = true;
            this.navFlow.BackColor = System.Drawing.Color.Transparent;
            this.navFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.navFlow.Location = new System.Drawing.Point(12, 12);
            this.navFlow.Name = "navFlow";
            this.navFlow.Padding = new System.Windows.Forms.Padding(6);
            this.navFlow.Size = new System.Drawing.Size(296, 658);
            this.navFlow.TabIndex = 0;
            this.navFlow.WrapContents = false;
            // 
            // panelDivider
            // 
            this.panelDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelDivider.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDivider.Location = new System.Drawing.Point(320, 118);
            this.panelDivider.Name = "panelDivider";
            this.panelDivider.Size = new System.Drawing.Size(6, 682);
            this.panelDivider.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(326, 118);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(16);
            this.panelContent.Size = new System.Drawing.Size(891, 682);
            this.panelContent.TabIndex = 0;
            // 
            // frmDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 800);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelDivider);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "frmDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - Student Manager";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label label1;
    }
}