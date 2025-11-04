using AntdUI;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmDashBoard : Form
    {
        private readonly string _username;
        private readonly string _role;

        [DllImport("user32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;
        private const int SB_BOTH = 3;

        private Form activeChildForm = null;

        private IconButton _selectedNavButton = null;
        private readonly Color NavItemBgDefault = Color.FromArgb(28, 33, 39);
        private readonly Color NavItemBgSelected = Color.FromArgb(45, 140, 240);
        private readonly float NavItemFontSize = 10F;

        private readonly List<MenuItemDef> _menuItems = new List<MenuItemDef>
        {
            new MenuItemDef("Home (Dashboard)", "dashboard", IconChar.Home),
            new MenuItemDef("Reports and Statistics", "reports", IconChar.ChartBar),
            new MenuItemDef("System Settings", "system", IconChar.Cogs),
            new MenuItemDef("Accounts", "accounts", IconChar.UserCog),

            new MenuItemDef("Notifications", "notifications", IconChar.Bell),

            new MenuItemDef("Study Management", "study", IconChar.GraduationCap),
            new MenuItemDef("Student Management", "students", IconChar.UserGraduate),
            new MenuItemDef("Lecturer Management", "lecturers", IconChar.ChalkboardTeacher),
            new MenuItemDef("Class Management", "classes", IconChar.ClipboardList),
            new MenuItemDef("Course Management", "courses", IconChar.Book),
            new MenuItemDef("Tuition Management", "tuition", IconChar.MoneyCheckAlt),
            new MenuItemDef("Enrollment Management", "enroll", IconChar.Edit)
        };

        public frmDashBoard(string username = "admin", string role = "Admin")
        {
            _username = username;
            _role = role;

            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            lblTitle.Text = "STUDENT MANAGEMENT - DASHBOARD";

            lblUser.Text = $"User: {_username}    Role: {_role}";

            AdjustUserLabelPosition();

            this.Resize += (s, e) => AdjustUserLabelPosition();
            this.panelHeader.SizeChanged += (s, e) => AdjustUserLabelPosition();

            try { if (this.btnExit != null) this.btnExit.BringToFront(); } catch { }

            PopulateNavigation();
            SetupNavFlowMouseWheel();

            LoadFeature("dashboard");
        }

        private void SetupNavFlowMouseWheel()
        {
            var h = navFlow.Handle;

            ShowScrollBar(navFlow.Handle, SB_BOTH, false);

            Application.AddMessageFilter(new NavMouseWheelFilter(navFlow));
        }

        private class NavMouseWheelFilter : IMessageFilter
        {
            private readonly FlowLayoutPanel _target;
            private const int WM_MOUSEWHEEL = 0x020A;

            public NavMouseWheelFilter(FlowLayoutPanel target) { _target = target; }

            public bool PreFilterMessage(ref System.Windows.Forms.Message m)
            {
                if (m.Msg != 0x020A) return false;
                var mousePos = Control.MousePosition;
                if (!_target.Visible) return false;

                var clientPt = _target.PointToClient(mousePos);
                if (!_target.ClientRectangle.Contains(clientPt)) return false;

                int wParam = m.WParam.ToInt32();
                int delta = (short)((wParam >> 16) & 0xffff);
                int scrollPixels = -(delta / 120) * 20;

                var v = _target.VerticalScroll;
                int min = v.Minimum;
                int max = v.Maximum - v.LargeChange + 1;
                int newVal = v.Value + scrollPixels;
                newVal = Math.Max(min, Math.Min(max, newVal));

                _target.Invoke((Action)(() =>
                {
                    try
                    {
                        _target.VerticalScroll.Value = newVal;
                        _target.AutoScrollPosition = new Point(_target.AutoScrollPosition.X, newVal);
                    }
                    catch { }
                }));

                return true;
            }

        }

        private void PopulateNavigation()
        {
            navFlow.Controls.Clear();

            foreach (var mi in _menuItems)
            {
                var iconBtn = new IconButton
                {
                    Text = mi.Text,
                    Tag = mi.Key,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    IconChar = mi.Icon,
                    IconColor = Color.White,
                    IconSize = 20,
                    Width = Math.Max(220, navFlow.ClientSize.Width - 24),
                    Height = 56,
                    Margin = new Padding(6),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(38, 45, 52),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", NavItemFontSize, FontStyle.Regular),
                    TextImageRelation = TextImageRelation.ImageBeforeText,
                    Padding = new Padding(12, 0, 0, 0)
                };
                iconBtn.FlatAppearance.BorderSize = 0;
                iconBtn.Click += NavButton_Click;

                var card = new System.Windows.Forms.Panel
                {
                    Width = iconBtn.Width + 8,
                    Height = iconBtn.Height + 4,
                    Padding = new Padding(4),
                    Margin = new Padding(4),
                    BackColor = Color.Transparent
                };
                var bg = new AntdUI.Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = NavItemBgDefault
                };
                bg.Tag = mi.Key;
                bg.Controls.Add(iconBtn);
                card.Controls.Add(bg);

                navFlow.Controls.Add(card);

                if (mi.Key == "dashboard")
                {
                    UpdateNavSelection(iconBtn);
                }
            }

            var spacer = new System.Windows.Forms.Panel { Height = 16, Width = navFlow.ClientSize.Width - 8, BackColor = Color.Transparent };
            navFlow.Controls.Add(spacer);
        }

        private void NavButton_Click(object sender, EventArgs e)
        {
            if (!(sender is IconButton b)) return;
            UpdateNavSelection(b);

            var key = b.Tag as string;
            LoadFeature(key);
        }

        private void UpdateNavSelection(IconButton btn)
        {
            if (btn == null) return;
            if (_selectedNavButton == btn) return;

            try
            {
                if (_selectedNavButton != null && !_selectedNavButton.IsDisposed)
                {
                    var prevBg = _selectedNavButton.Parent as Control;
                    if (prevBg != null) prevBg.BackColor = NavItemBgDefault;
                    _selectedNavButton.ForeColor = Color.White;
                    _selectedNavButton.IconColor = Color.White;
                    _selectedNavButton.Font = new Font(_selectedNavButton.Font.FontFamily, NavItemFontSize, FontStyle.Regular);
                }
            }
            catch { }

            try
            {
                var newBg = btn.Parent as Control;
                if (newBg != null) newBg.BackColor = NavItemBgSelected;
                btn.ForeColor = Color.White;
                btn.IconColor = Color.White;
                btn.Font = new Font(btn.Font.FontFamily, NavItemFontSize, FontStyle.Bold);

                try { newBg?.BringToFront(); btn.BringToFront(); } catch { }
            }
            catch { }

            _selectedNavButton = btn;
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeChildForm != null)
            {
                try
                {
                    activeChildForm.Close();
                    activeChildForm.Dispose();
                }
                catch { }
                activeChildForm = null;
            }

            activeChildForm = childForm;
            if (childForm == null) return;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.Show();
            childForm.BringToFront();
        }

        private void LoadFeature(string featureKey)
        {
            switch (featureKey)
            {
                case "students":
                    OpenChildForm(new frmStudent());
                    return;

                case "study":
                    OpenChildForm(new frmStudy());
                    return;

                case "notifications":
                    OpenChildForm(new frmNotification());
                    return;

                case "dashboard":
                    panelContent.Controls.Clear();
                    var lblHome = new AntdUI.Label
                    {
                        Text = "Home - Dashboard",
                        Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                        Dock = DockStyle.Top,
                        Height = 48
                    };
                    panelContent.Controls.Add(lblHome);
                    var homePanel = new System.Windows.Forms.Panel { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke };
                    panelContent.Controls.Add(homePanel);
                    return;

                default:
                    panelContent.Controls.Clear();
                    var lbl = new AntdUI.Label
                    {
                        Text = "Feature: " + featureKey,
                        Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(30, 30, 30),
                        Dock = DockStyle.Top,
                        Height = 48
                    };
                    panelContent.Controls.Add(lbl);

                    var defaultContent = new System.Windows.Forms.Panel { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke, Padding = new Padding(12) };

                    var grid = new DataGridView
                    {
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        AllowUserToAddRows = false,
                        ColumnCount = 5,
                        BackgroundColor = Color.White
                    };
                    grid.Columns[0].Name = "ID";
                    grid.Columns[1].Name = "Name";
                    grid.Columns[2].Name = "Description";
                    grid.Columns[3].Name = "Status";
                    grid.Columns[4].Name = "Date";

                    grid.Rows.Add("1", featureKey + " A", "Description...", "OK", DateTime.Now.ToShortDateString());
                    grid.Rows.Add("2", featureKey + " B", "Description...", "OK", DateTime.Now.ToShortDateString());

                    defaultContent.Controls.Add(grid);
                    panelContent.Controls.Add(defaultContent);
                    return;
            }
        }

        private class MenuItemDef
        {
            public string Text { get; }
            public string Key { get; }
            public IconChar Icon { get; }
            public MenuItemDef(string text, string key, IconChar icon) { Text = text; Key = key; Icon = icon; }
        }

        private void AdjustUserLabelPosition()
        {
            try
            {
                int headerWidth = (panelHeader != null) ? panelHeader.ClientSize.Width : this.ClientSize.Width;
                int rightPadding = 24;

                if (this.btnExit != null && !this.btnExit.IsDisposed && this.btnExit.Visible)
                {
                    rightPadding += this.btnExit.Width + 8; // 8px gap
                }

                int newLeft = Math.Max(12, headerWidth - lblUser.Width - rightPadding);

                lblUser.Left = newLeft;
            }
            catch
            {
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc muốn thoát ứng dụng?",
                "Xác nhận Thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
