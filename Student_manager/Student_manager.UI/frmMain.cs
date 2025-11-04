using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmMain : Form
    {
        private AntdUI.Label errorUserLabel;
        private AntdUI.Label errorPasswordLabel;

        private Size loginTargetSize;
        private Point loginTargetPos;

        private Panel shadowPanel;
        private int cardCornerRadius = 14;
        private Point shadowOffset = new Point(10, 10);
        private int shadowAlpha = 90;

        private int overlayDimAlpha = 48;

        private Size lastShadowSize = Size.Empty;
        private Size lastCardSize = Size.Empty;

        private const int MinPasswordLength = 4;

        public frmMain()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Header visual
            panelHeader.BackColor = Color.FromArgb(20, Color.White);

            LoginPanel.Visible = false;
            LoginPanel.BackColor = Color.Transparent;

            btnLogin.Text = "ĐĂNG NHẬP HỆ THỐNG";
            btnLogin.Type = AntdUI.TTypeMini.Primary;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            btnLogin.Click -= BtnLogin_Click;
            btnLogin.Click += BtnLogin_Click;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            loginTargetSize = LoginPanelLeft.Size;
            loginTargetPos = LoginPanelLeft.Location;

            CreateValidationLabels();
            txtUser.KeyDown += Input_KeyDown;
            txtPassword.KeyDown += Input_KeyDown;

            checkboxPassword.CheckedChanged -= CheckboxPassword_CheckedChanged;
            checkboxPassword.CheckedChanged += CheckboxPassword_CheckedChanged;

            txtPassword.PasswordChar = '•';
        }

        private void CreateValidationLabels()
        {
            errorUserLabel = new AntdUI.Label
            {
                Text = "",
                ForeColor = Color.FromArgb(200, 200, 50, 50),
                Font = new Font("Segoe UI", 9F),
                Visible = false,
                AutoSize = false
            };
            errorPasswordLabel = new AntdUI.Label
            {
                Text = "",
                ForeColor = Color.FromArgb(200, 200, 50, 50),
                Font = new Font("Segoe UI", 9F),
                Visible = false,
                AutoSize = false
            };

            LoginPanelLeft.Controls.Add(errorUserLabel);
            LoginPanelLeft.Controls.Add(errorPasswordLabel);
        }

        private void PositionValidationLabels()
        {
            if (txtUser != null && errorUserLabel != null)
            {
                errorUserLabel.Size = new Size(txtUser.Width, 18);
                errorUserLabel.Location = new Point(txtUser.Left, txtUser.Bottom + 6);
            }

            if (txtPassword != null && errorPasswordLabel != null)
            {
                errorPasswordLabel.Size = new Size(txtPassword.Width, 18);
                errorPasswordLabel.Location = new Point(txtPassword.Left, txtPassword.Bottom + 6);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoginPanel.Visible = false;

            CreateShadowPanel();

            CenterLoginCard();

            PositionValidationLabels();

            this.DoubleBuffered = true;
        }

        private void CreateShadowPanel()
        {
            if (shadowPanel != null)
                return;

            shadowPanel = new Panel
            {
                BackColor = Color.FromArgb(shadowAlpha, 0, 0, 0),
                Size = new Size(LoginPanelLeft.Width + shadowOffset.X, LoginPanelLeft.Height + shadowOffset.Y),
                Visible = false
            };

            LoginPanel.Controls.Add(shadowPanel);
            LoginPanel.Controls.SetChildIndex(shadowPanel, LoginPanel.Controls.Count - 1);

            ApplyRoundedCorners(shadowPanel, cardCornerRadius + 2);
            ApplyRoundedCorners(LoginPanelLeft, cardCornerRadius);

            lastShadowSize = shadowPanel.Size;
            lastCardSize = LoginPanelLeft.Size;
        }

        private void ApplyRoundedCorners(Control ctrl, int radius)
        {
            if (ctrl == null) return;
            using (var path = RoundedRect(new Rectangle(0, 0, ctrl.Width, ctrl.Height), radius))
            {
                ctrl.Region?.Dispose();
                ctrl.Region = new Region(path);
            }
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;
            if (diameter > bounds.Width) diameter = bounds.Width;
            if (diameter > bounds.Height) diameter = bounds.Height;
            var arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90);

            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom-left
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void CenterLoginCard()
        {
            int x = (this.ClientSize.Width - LoginPanelLeft.Width) / 2;
            int y = (this.ClientSize.Height - LoginPanelLeft.Height) / 2;
            if (x < 0) x = 0;
            if (y < 0) y = 0;

            LoginPanelLeft.Location = new Point(x, y);

            if (shadowPanel != null)
            {
                var newShadowSize = new Size(LoginPanelLeft.Width + shadowOffset.X, LoginPanelLeft.Height + shadowOffset.Y);
                shadowPanel.Size = newShadowSize;
                shadowPanel.Location = new Point(LoginPanelLeft.Left + shadowOffset.X, LoginPanelLeft.Top + shadowOffset.Y);

                if (newShadowSize != lastShadowSize)
                {
                    ApplyRoundedCorners(shadowPanel, cardCornerRadius + 2);
                    lastShadowSize = newShadowSize;
                }
            }

            if (LoginPanelLeft.Size != lastCardSize)
            {
                ApplyRoundedCorners(LoginPanelLeft, cardCornerRadius);
                lastCardSize = LoginPanelLeft.Size;
            }

            loginTargetSize = LoginPanelLeft.Size;
            loginTargetPos = LoginPanelLeft.Location;

            PositionValidationLabels();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            CenterLoginCard();
        }

        private void CenterLoginPanel()
        {
            CenterLoginCard();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            CenterLoginPanel();

            if (!LoginPanel.Visible)
            {
                LoginPanel.BackColor = Color.FromArgb(overlayDimAlpha, 0, 0, 0);
                LoginPanel.Visible = true;

                if (shadowPanel != null) shadowPanel.Visible = true;

                ApplyRoundedCorners(LoginPanelLeft, cardCornerRadius);
                if (shadowPanel != null) ApplyRoundedCorners(shadowPanel, cardCornerRadius + 2);

                LoginPanelLeft.Size = loginTargetSize;
                LoginPanelLeft.Location = loginTargetPos;
                LoginPanelLeft.BackColor = Color.FromArgb(255, 255, 255, 255);

                if (shadowPanel != null)
                {
                    shadowPanel.Size = new Size(LoginPanelLeft.Width + shadowOffset.X, LoginPanelLeft.Height + shadowOffset.Y);
                    shadowPanel.Location = new Point(LoginPanelLeft.Left + shadowOffset.X, LoginPanelLeft.Top + shadowOffset.Y);
                }

                PositionValidationLabels();

                ClearValidationErrors();

                btnLogin.Visible = false;
                // btnOutHeader.Visible = false;
            }
            else
            {
                LoginPanel.Visible = false;
                LoginPanel.BackColor = Color.Transparent;
                if (shadowPanel != null) shadowPanel.Visible = false;

                btnLogin.Visible = true;
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                BtnLoginMain_Click(this, EventArgs.Empty);
            }
        }

        private void CheckboxPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkboxPassword.Checked ? '\0' : '•';
        }

        private int Lerp(int a, int b, double t)
        {
            return a + (int)Math.Round((b - a) * t);
        }

        private void ClearValidationErrors()
        {
            if (errorUserLabel != null) { errorUserLabel.Text = ""; errorUserLabel.Visible = false; }
            if (errorPasswordLabel != null) { errorPasswordLabel.Text = ""; errorPasswordLabel.Visible = false; }
        }

        private bool ValidateInputs(out string username, out string password)
        {
            username = (txtUser.Text ?? "").Trim();
            password = txtPassword.Text ?? "";

            bool ok = true;
            ClearValidationErrors();

            if (string.IsNullOrWhiteSpace(username))
            {
                errorUserLabel.Text = "Vui lòng nhập tài khoản";
                errorUserLabel.Visible = true;
                ok = false;
            }

            if (string.IsNullOrEmpty(password))
            {
                errorPasswordLabel.Text = "Vui lòng nhập mật khẩu";
                errorPasswordLabel.Visible = true;
                if (ok) txtPassword.Focus();
                ok = false;
            }
            else if (password.Length < MinPasswordLength)
            {
                errorPasswordLabel.Text = $"Mật khẩu phải có ít nhất {MinPasswordLength} ký tự";
                errorPasswordLabel.Visible = true;
                if (ok) txtPassword.Focus();
                ok = false;
            }

            // If username error, focus username
            if (!ok && string.IsNullOrWhiteSpace(username))
                txtUser.Focus();

            return ok;
        }

        private void BtnLoginMain_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out var username, out var password))
                return;

            buttonLogin.Enabled = false;
            buttonLogin.Text = "Đang xử lý...";

            try
            {
                bool success = (username == "admin" && password == "admin");

                if (success)
                {
                    var dr = MessageBox.Show("Đăng nhập thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        this.Hide();
                        using (var dash = new frmDashBoard(username, "Admin"))
                        {
                            dash.ShowDialog();
                        }
                        this.Close();
                    }
                }
                else
                {
                    errorPasswordLabel.Text = "Tài khoản hoặc mật khẩu không đúng";
                    errorPasswordLabel.Visible = true;
                    txtPassword.Focus();
                }
            }
            finally
            {
                buttonLogin.Enabled = true;
                buttonLogin.Text = "Đăng nhập";
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            // reserved
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (shadowPanel != null)
            {
                shadowPanel.Dispose();
                shadowPanel = null;
            }
            base.OnFormClosing(e);
        }

        private void BtnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOutHeader_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }

        private void panelHeader_Click(object sender, EventArgs e)
        {

        }
    }
}
