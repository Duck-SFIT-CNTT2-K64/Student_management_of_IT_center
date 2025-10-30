using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmMain : Form
    {
        // UI validation labels
        private AntdUI.Label errorUserLabel;
        private AntdUI.Label errorPasswordLabel;

        // Animation fields (removed timer-based animation)
        private Size loginTargetSize;
        private Point loginTargetPos;

        // Shadow / rounding
        private Panel shadowPanel;
        private int cardCornerRadius = 14;
        private Point shadowOffset = new Point(10, 10); // shadow offset from card
        private int shadowAlpha = 90; // 0..255

        // Dim strength for surrounding background while login is visible
        private int overlayDimAlpha = 48;

        // caches to avoid expensive Region recreation
        private Size lastShadowSize = Size.Empty;
        private Size lastCardSize = Size.Empty;

        // minimal password length
        private const int MinPasswordLength = 4;

        public frmMain()
        {
            InitializeComponent();

            // Keep runtime enforcement of full-screen, borderless
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Header visual
            panelHeader.BackColor = Color.FromArgb(20, Color.White); // subtle translucent header

            // Login panel initial state
            LoginPanel.Visible = false;
            LoginPanel.BackColor = Color.Transparent; // no dim at start

            // Configure login button (designer also sets text and handler)
            btnLogin.Text = "ĐĂNG NHẬP HỆ THỐNG";
            btnLogin.Type = AntdUI.TTypeMini.Primary;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Ensure header login handler
            btnLogin.Click -= BtnLogin_Click;
            btnLogin.Click += BtnLogin_Click;

            // Set form double-buffering to reduce flicker
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // store target size from designer (card inside overlay)
            loginTargetSize = LoginPanelLeft.Size;
            loginTargetPos = LoginPanelLeft.Location;

            // Create inline error labels and wire Enter handler
            CreateValidationLabels();
            txtUser.KeyDown += Input_KeyDown;
            txtPassword.KeyDown += Input_KeyDown;

            // Wire checkbox to toggle password visibility
            checkboxPassword.CheckedChanged -= CheckboxPassword_CheckedChanged;
            checkboxPassword.CheckedChanged += CheckboxPassword_CheckedChanged;

            // Ensure initial password masking
            txtPassword.PasswordChar = '•';
        }

        private void CreateValidationLabels()
        {
            // error label - user
            errorUserLabel = new AntdUI.Label
            {
                Text = "",
                ForeColor = Color.FromArgb(200, 200, 50, 50),
                Font = new Font("Segoe UI", 9F),
                Visible = false,
                AutoSize = false
            };
            // error label - password
            errorPasswordLabel = new AntdUI.Label
            {
                Text = "",
                ForeColor = Color.FromArgb(200, 200, 50, 50),
                Font = new Font("Segoe UI", 9F),
                Visible = false,
                AutoSize = false
            };

            // position will be updated in CenterLoginCard() and whenever showing the overlay
            LoginPanelLeft.Controls.Add(errorUserLabel);
            LoginPanelLeft.Controls.Add(errorPasswordLabel);
        }

        private void PositionValidationLabels()
        {
            // Place error labels right under the inputs
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
            // initial: overlay hidden and card centered
            LoginPanel.Visible = false;

            // create shadow behind the card (will be added inside LoginPanel)
            CreateShadowPanel();

            CenterLoginCard();

            // position inline validation labels relative to inputs
            PositionValidationLabels();

            // smoother drawing
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

            // add shadow behind the card
            LoginPanel.Controls.Add(shadowPanel);
            // send shadow behind other controls in the overlay
            LoginPanel.Controls.SetChildIndex(shadowPanel, LoginPanel.Controls.Count - 1);

            // initial rounded region for both shadow and card
            ApplyRoundedCorners(shadowPanel, cardCornerRadius + 2);
            ApplyRoundedCorners(LoginPanelLeft, cardCornerRadius);

            // cache current sizes
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

            // top-left
            path.AddArc(arc, 180, 90);

            // top-right
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom-right
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
            // Center card inside client area
            int x = (this.ClientSize.Width - LoginPanelLeft.Width) / 2;
            int y = (this.ClientSize.Height - LoginPanelLeft.Height) / 2;
            if (x < 0) x = 0;
            if (y < 0) y = 0;

            LoginPanelLeft.Location = new Point(x, y);

            // update shadow position and size
            if (shadowPanel != null)
            {
                var newShadowSize = new Size(LoginPanelLeft.Width + shadowOffset.X, LoginPanelLeft.Height + shadowOffset.Y);
                shadowPanel.Size = newShadowSize;
                shadowPanel.Location = new Point(LoginPanelLeft.Left + shadowOffset.X, LoginPanelLeft.Top + shadowOffset.Y);

                // only recreate Region if size actually changed (expensive)
                if (newShadowSize != lastShadowSize)
                {
                    ApplyRoundedCorners(shadowPanel, cardCornerRadius + 2);
                    lastShadowSize = newShadowSize;
                }
            }

            // update the logical animation target to current card location/size
            if (LoginPanelLeft.Size != lastCardSize)
            {
                ApplyRoundedCorners(LoginPanelLeft, cardCornerRadius);
                lastCardSize = LoginPanelLeft.Size;
            }

            loginTargetSize = LoginPanelLeft.Size;
            loginTargetPos = LoginPanelLeft.Location;

            // reposition validation labels in case card moved/resized
            PositionValidationLabels();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            CenterLoginCard();
        }

        private void CenterLoginPanel()
        {
            // recompute the target based on card
            CenterLoginCard();
        }

        // Instant show/hide (animation removed)
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Recompute center for current window size
            CenterLoginPanel();

            if (!LoginPanel.Visible)
            {
                // show dim overlay so background remains visible but de-emphasized
                LoginPanel.BackColor = Color.FromArgb(overlayDimAlpha, 0, 0, 0);
                LoginPanel.Visible = true;

                // show shadow
                if (shadowPanel != null) shadowPanel.Visible = true;

                // ensure rounding applied
                ApplyRoundedCorners(LoginPanelLeft, cardCornerRadius);
                if (shadowPanel != null) ApplyRoundedCorners(shadowPanel, cardCornerRadius + 2);

                // place card at final centered location and make it fully readable
                LoginPanelLeft.Size = loginTargetSize;
                LoginPanelLeft.Location = loginTargetPos;
                LoginPanelLeft.BackColor = Color.FromArgb(255, 255, 255, 255);

                // update shadow to match
                if (shadowPanel != null)
                {
                    shadowPanel.Size = new Size(LoginPanelLeft.Width + shadowOffset.X, LoginPanelLeft.Height + shadowOffset.Y);
                    shadowPanel.Location = new Point(LoginPanelLeft.Left + shadowOffset.X, LoginPanelLeft.Top + shadowOffset.Y);
                }

                // reposition validation labels
                PositionValidationLabels();

                // clear previous errors
                ClearValidationErrors();

                // hide header login button while visible
                btnLogin.Visible = false;
                // optional: hide other header buttons if present
                // btnOutHeader.Visible = false;
            }
            else
            {
                // hide overlay and shadow, restore transparent overlay so background returns to original look
                LoginPanel.Visible = false;
                LoginPanel.BackColor = Color.Transparent;
                if (shadowPanel != null) shadowPanel.Visible = false;

                // show the top button again
                btnLogin.Visible = true;
                btnOutHeader.Visible = false;
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                // call login action
                BtnLoginMain_Click(this, EventArgs.Empty);
            }
        }

        private void CheckboxPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            txtPassword.PasswordChar = checkboxPassword.Checked ? '\0' : '•';
        }

        // linear interpolation helper (kept for completeness though not used now)
        private int Lerp(int a, int b, double t)
        {
            return a + (int)Math.Round((b - a) * t);
        }

        // Validation helpers
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

        // The real login action (wired in Designer)
        private void BtnLoginMain_Click(object sender, EventArgs e)
        {
            // Validate inputs first
            if (!ValidateInputs(out var username, out var password))
                return;

            // Disable login button to prevent duplicate clicks
            buttonLogin.Enabled = false;
            buttonLogin.Text = "Đang xử lý...";

            try
            {
                // TODO: Replace this placeholder with actual authentication logic.
                // Example: bool success = AuthService.Authenticate(username, password);
                // For now we simulate success when username == "admin" and password == "admin"
                bool success = (username == "admin" && password == "admin");

                if (success)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // hide login after success
                    LoginPanel.Visible = false;


                    //if (shadowPanel != null) shadowPanel.Visible = false;
                    //LoginPanel.BackColor = Color.Transparent;
                    //btnLogin.Visible = true;
                }
                else
                {
                    // show a general error below password (or a MessageBox)
                    errorPasswordLabel.Text = "Tài khoản hoặc mật khẩu không đúng";
                    errorPasswordLabel.Visible = true;
                    txtPassword.Focus();
                }
            }
            finally
            {
                // restore button state
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
