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
        private double _dashboardSplitterRatio = 0.60;

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
            new MenuItemDef("Home", "dashboard", IconChar.Home),
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
                if (m.Msg != WM_MOUSEWHEEL) return false;
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

                iconBtn.MouseEnter += (s, e) =>
                {
                    var b = s as IconButton;
                    if (b != null && b != _selectedNavButton) b.Parent.BackColor = ControlPaint.Light(NavItemBgDefault);
                };
                iconBtn.MouseLeave += (s, e) =>
                {
                    var b = s as IconButton;
                    if (b != null && b != _selectedNavButton) b.Parent.BackColor = NavItemBgDefault;
                };

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

                case "tuition":
                    OpenChildForm(new frmTuitions());
                    return;

                case "classes":
                    OpenChildForm(new frmLopHoc());
                    return;

                case "courses":
                    OpenChildForm(new frmKhoaHoc());
                    return;

                case "enroll":
                    OpenChildForm(new frmEnrollment());
                    return;

                case "system":
                    OpenChildForm(new frmSystem());
                    return;

                case "reports":
                    OpenChildForm(new frmReport());
                    return;

                case "accounts":
                    OpenChildForm(new frmAccount());
                    return;

                case "lecturers":
                    OpenChildForm(new frmLectures());
                    return;

                case "dashboard":
                    // switch into the Silver-themed home view
                    panelContent.Controls.Clear();
                    panelContent.BackColor = Color.Silver; // make entire content area silver to match other forms

                    var lblHome = new AntdUI.Label
                    {
                        Text = "Home - Dashboard",
                        Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                        Dock = DockStyle.Top,
                        Height = 48,
                        ForeColor = Color.FromArgb(30, 30, 30),
                        Padding = new Padding(12, 8, 0, 0),
                        AutoSizeMode = AntdUI.TAutoSize.Auto
                    };
                    panelContent.Controls.Add(lblHome);

                    var split = new SplitContainer
                    {
                        Dock = DockStyle.Fill,
                        Orientation = Orientation.Vertical,
                        BackColor = Color.Silver, // keep split background aligned with panelContent
                        SplitterWidth = 8,
                    };

                    // LEFT: ranking grid (keeps white grid for contrast on silver background)
                    var dgvRanking = new DataGridView
                    {
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        AllowUserToAddRows = false,
                        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                        BackgroundColor = Color.White,
                        BorderStyle = BorderStyle.None,
                        Font = new Font("Segoe UI", 10F),
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        ColumnHeadersDefaultCellStyle = { BackColor = Color.FromArgb(240, 240, 240), Font = new Font("Segoe UI", 10F, FontStyle.Bold) }
                    };
                    dgvRanking.Columns.Add("Rank", "Rank");
                    dgvRanking.Columns.Add("TeacherName", "Teacher");
                    dgvRanking.Columns.Add("ClassesCompleted", "Classes Completed");
                    dgvRanking.Columns["Rank"].Width = 60;
                    dgvRanking.Columns["ClassesCompleted"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    var sampleRanking = new[]
                    {
                        new { Rank = 1, Name = "Bùi Hải Đức", Count = 32 },
                        new { Rank = 2, Name = "Đặng Hoàng Huy", Count = 28 },
                        new { Rank = 3, Name = "Đinh Quang Hưng", Count = 24 },
                        new { Rank = 4, Name = "Nguyễn Mạnh Tiến", Count = 20 }
                    };
                    foreach (var r in sampleRanking) dgvRanking.Rows.Add(r.Rank, r.Name, r.Count);

                    var leftHeaderPanel = new System.Windows.Forms.Panel { Dock = DockStyle.Top, Height = 82, BackColor = Color.Silver };
                    var leftHeaderLabel = new AntdUI.Label
                    {
                        Text = "Top teachers by classes completed",
                        Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                        Dock = DockStyle.Fill,
                        Padding = new Padding(12, 24, 0, 0),
                        ForeColor = Color.FromArgb(30, 30, 30),
                        AutoSizeMode = AntdUI.TAutoSize.Auto
                    };
                    leftHeaderPanel.Controls.Add(leftHeaderLabel);

                    var leftContainer = new System.Windows.Forms.Panel { Dock = DockStyle.Fill, Padding = new Padding(12), BackColor = Color.Silver };
                    leftContainer.Controls.Add(dgvRanking);
                    leftContainer.Controls.Add(leftHeaderPanel);
                    split.Panel1.Controls.Add(leftContainer);

                    // RIGHT: featured teacher cards - cards keep white backgrounds to stand out on silver
                    var rightFlow = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.TopDown,
                        AutoScroll = true,
                        WrapContents = false,
                        Padding = new Padding(12),
                        BackColor = Color.Silver
                    };

                    var featured = new[]
                    {
                        new { Name = "Bùi Hải Đức", ImagePath = System.IO.Path.Combine(Application.StartupPath, "Images", "duc_1.png") },
                        new { Name = "Đặng Hoàng Huy", ImagePath = System.IO.Path.Combine(Application.StartupPath, "Images", "teacher2.jpg") },
                        new { Name = "Đinh Quang Hưng", ImagePath = System.IO.Path.Combine(Application.StartupPath, "Images", "Hung_quang.jpg") },
                        new { Name = "Nguyễn Mạnh Tiến", ImagePath = System.IO.Path.Combine(Application.StartupPath, "Images", "Tien.jpg") }
                    };

                    foreach (var t in featured) rightFlow.Controls.Add(CreateFeaturedTeacherCard(t.Name, t.ImagePath));

                    var rightHeader = new AntdUI.Label
                    {
                        Text = "Featured Teachers",
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                        Dock = DockStyle.Top,
                        Height = 36,
                        Padding = new Padding(8, 6, 0, 0),
                        ForeColor = Color.FromArgb(30, 30, 30),
                        AutoSizeMode = AntdUI.TAutoSize.Auto
                    };
                    var rightPanel = new System.Windows.Forms.Panel { Dock = DockStyle.Fill, Padding = new Padding(0), BackColor = Color.Silver };
                    rightPanel.Controls.Add(rightFlow);
                    rightPanel.Controls.Add(rightHeader);
                    split.Panel2.Controls.Add(rightPanel);

                    panelContent.Controls.Add(split);

                    // minimums and persistence
                    split.Panel1MinSize = 300;
                    split.Panel2MinSize = 220;

                    if (panelContent.IsHandleCreated)
                    {
                        panelContent.BeginInvoke((Action)(() =>
                        {
                            try
                            {
                                // Đây là logic dùng để đặt lại vị trí thanh trượt
                                // dựa trên tỉ lệ đã lưu (_dashboardSplitterRatio)
                                int totalW = Math.Max(1, split.ClientSize.Width);
                                int desired = (int)(_dashboardSplitterRatio * totalW);
                                int min = split.Panel1MinSize;
                                int max = totalW - split.Panel2MinSize;
                                if (max < min) split.SplitterDistance = min;
                                else split.SplitterDistance = Math.Max(min, Math.Min(desired, max));
                            }
                            catch { }
                        }));
                    }

                    split.SplitterMoved += (s, e) =>
                    {
                        try
                        {
                            if (split.ClientSize.Width > 0) _dashboardSplitterRatio = split.SplitterDistance / (double)split.ClientSize.Width;
                        }
                        catch { }
                    };

                    split.SizeChanged += (s, e) =>
                    {
                        try
                        {
                            int totalW = Math.Max(1, split.ClientSize.Width);
                            int desired = (int)(_dashboardSplitterRatio * totalW);
                            int min = split.Panel1MinSize;
                            int max = totalW - split.Panel2MinSize;
                            if (max < min) split.SplitterDistance = min;
                            else split.SplitterDistance = Math.Max(min, Math.Min(desired, max));
                        }
                        catch { }
                    };

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

        private Control CreateFeaturedTeacherCard(string displayName, string imageFilePath)
        {
            var card = new System.Windows.Forms.Panel
            {
                Width = 260,
                Height = 120,
                Margin = new Padding(6),
                Padding = new Padding(8),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Control pictureCtrl;
            try
            {
                if (!string.IsNullOrEmpty(imageFilePath) && System.IO.File.Exists(imageFilePath))
                {
                    var pb = new PictureBox
                    {
                        Image = Image.FromFile(imageFilePath),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(96, 96),
                        Location = new Point(8, 12)
                    };
                    pictureCtrl = pb;
                }
                else
                {
                    var ip = new IconPictureBox
                    {
                        IconChar = IconChar.UserGraduate,
                        IconColor = Color.FromArgb(45, 140, 240),
                        IconSize = 64,
                        Size = new Size(96, 96),
                        Location = new Point(8, 12)
                    };
                    pictureCtrl = ip;
                }
            }
            catch
            {
                var ip = new IconPictureBox
                {
                    IconChar = IconChar.UserGraduate,
                    IconColor = Color.FromArgb(45, 140, 240),
                    IconSize = 64,
                    Size = new Size(96, 96),
                    Location = new Point(8, 12)
                };
                pictureCtrl = ip;
            }

            var lblName = new AntdUI.Label
            {
                Text = displayName,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(112, 24),
                AutoSizeMode = AntdUI.TAutoSize.Auto
            };

            var lblMeta = new AntdUI.Label
            {
                Text = "Top performer",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(112, 52),
                AutoSizeMode = AntdUI.TAutoSize.Auto
            };

            card.Controls.Add(pictureCtrl);
            card.Controls.Add(lblName);
            card.Controls.Add(lblMeta);

            card.Cursor = Cursors.Hand;
            card.Click += (s, e) =>
            {
                MessageBox.Show($"Open details for: {displayName}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            return card;
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

        private void frmDashBoard_Load(object sender, EventArgs e)
        {
           
        }

        private void AdjustSplitDistanceForPanel(SplitContainer split, Control container)
        {
            if (split == null || container == null) return;

            int totalW = container.ClientSize.Width;
            int minTotal = split.Panel1MinSize + split.Panel2MinSize;

            if (totalW <= minTotal || totalW <= 0)
            {
                split.SplitterDistance = split.Panel1MinSize;
                return;
            }

            int pd = (int)(totalW * 0.60);
            int maxAllowed = totalW - split.Panel2MinSize;
            pd = Math.Max(split.Panel1MinSize, Math.Min(pd, maxAllowed));
            pd = Math.Max(split.Panel1MinSize, Math.Min(pd, totalW - split.Panel2MinSize));
            split.SplitterDistance = pd;
        }
    }
}
