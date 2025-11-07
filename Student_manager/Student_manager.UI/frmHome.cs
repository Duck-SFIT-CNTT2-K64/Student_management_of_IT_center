using AntdUI;
using FontAwesome.Sharp;
using Student_manager.BLL;
using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Student_manager.UI
{
    public partial class frmHome : Form
    {
        private readonly HomeNoticeService _noticeService = new HomeNoticeService();
        private readonly FeaturedTeacherDAO _featuredDao = new FeaturedTeacherDAO();
        private readonly TuitionDAO _tuitionDao = new TuitionDAO();

        private DataGridView dgvNotices;
        private TextBox txtNoticeTitle;
        private TextBox txtNoticeContent;
        private AntdUI.Button btnNoticeNew, btnNoticeEdit, btnNoticeSave, btnNoticeDelete, btnNoticeRefresh;
        private FlowLayoutPanel featuredFlow;

        private int _editingNoticeId = -1;

        public frmHome()
        {
            InitializeComponent(); // keep designer if present
            BuildLayout();        // builds the visual UI programmatically (safe if designer absent)
            LoadDashboardData();
        }

        private void BuildLayout()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Font = new Font("Segoe UI", 10F);

            // switch to a clear 2-column layout so the Featured column cannot be obscured;
            // left column: main content (stats + chart/board), right column: notices + featured stacked
            var main = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 4, Padding = new Padding(12) };
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F)); // left area (chart + main)
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F)); // right column for notices & featured
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F)); // top stat cards
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 150F));  // chart / main area (must be > 0)
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));  // second area (if needed)
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));

            // TOP stats row (span both columns)
            var statPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, AutoScroll = false };
            statPanel.Padding = new Padding(6);
            statPanel.Controls.Add(CreateStatCard("Students", "\uf0c0", 50000, Color.FromArgb(72, 201, 176)));
            statPanel.Controls.Add(CreateStatCard("Teachers", "\uf19d", 10000, Color.FromArgb(52, 152, 219)));
            statPanel.Controls.Add(CreateStatCard("Parents", "\uf2bb", 15000, Color.FromArgb(241, 196, 15)));
            statPanel.Controls.Add(CreateStatCard("Earnings", "\uf0d6", 30000, Color.FromArgb(231, 76, 60)));
            main.Controls.Add(statPanel, 0, 0);
            main.SetColumnSpan(statPanel, 2);

            // LEFT: fees collection chart area
            var chartCard = new System.Windows.Forms.Panel { BackColor = Color.White, Dock = DockStyle.Fill, Padding = new Padding(12), Margin = new Padding(6) };
            var lblChart = new AntdUI.Label { Text = "Fees Collection & Expenses", Font = new Font("Segoe UI", 12F, FontStyle.Bold), Dock = DockStyle.Top, AutoSizeMode = AntdUI.TAutoSize.Auto };
            chartCard.Controls.Add(lblChart);

            var feesChart = new System.Windows.Forms.DataVisualization.Charting.Chart { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke };
            feesChart.MinimumSize = new Size(0, 1);

            var ca = new ChartArea("Main");
            ca.BackColor = Color.WhiteSmoke;
            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            feesChart.ChartAreas.Add(ca);

            var legend = new Legend { Docking = Docking.Bottom };
            feesChart.Legends.Add(legend);

            var sTotal = new Series("Total Fee") { ChartType = SeriesChartType.Column, ChartArea = "Main", Color = Color.FromArgb(72, 201, 176) };
            var sPaid = new Series("Amount Paid") { ChartType = SeriesChartType.Column, ChartArea = "Main", Color = Color.FromArgb(52, 152, 219) };
            var sDue = new Series("Outstanding") { ChartType = SeriesChartType.Column, ChartArea = "Main", Color = Color.FromArgb(231, 76, 60) };

            feesChart.Series.Add(sTotal);
            feesChart.Series.Add(sPaid);
            feesChart.Series.Add(sDue);

            chartCard.Controls.Add(feesChart);

            // Add chart to the LEFT column (column 0), spanning two rows
            main.SuspendLayout();
            main.Controls.Add(chartCard, 0, 1);
            main.SetRowSpan(chartCard, 2);
            main.ResumeLayout(false);

            // RIGHT: Notice Board (top-right) and Featured (below it)
            var rightColumn = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(6) };
            rightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            rightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            rightColumn.Padding = new Padding(6, 6, 6, 6);

            // Notice Board
            var noticeCard = new System.Windows.Forms.Panel { BackColor = Color.White, Dock = DockStyle.Fill, Padding = new Padding(12), Margin = new Padding(6,6,6,6) };
            var lblNoticeHeader = new AntdUI.Label { Text = "Notice Board", Font = new Font("Segoe UI", 12F, FontStyle.Bold), Dock = DockStyle.Top, AutoSizeMode = AntdUI.TAutoSize.Auto };
            noticeCard.Controls.Add(lblNoticeHeader);

            dgvNotices = new DataGridView { Dock = DockStyle.Top, Height = 220, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = Color.WhiteSmoke };
            dgvNotices.Columns.Add("NoticeId", "Id");
            dgvNotices.Columns["NoticeId"].Width = 40;
            dgvNotices.Columns.Add("Title", "Title");
            dgvNotices.Columns.Add("CreatedAt", "Date");
            dgvNotices.CellDoubleClick += (s, e) => LoadSelectedNoticeForEdit();
            noticeCard.Controls.Add(dgvNotices);

            var editorPanel = new System.Windows.Forms.Panel { Dock = DockStyle.Bottom, Height = 200 };

            txtNoticeTitle = new TextBox { Dock = DockStyle.Top };
            txtNoticeTitle.SetPlaceholder("Title");
            txtNoticeContent = new TextBox { Multiline = true, Dock = DockStyle.Fill, Height = 100, ScrollBars = ScrollBars.Vertical };
            txtNoticeContent.SetPlaceholder("Content");

            var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 40, FlowDirection = FlowDirection.LeftToRight };
            btnNoticeNew = new AntdUI.Button { Text = "New", Width = 80 };
            btnNoticeEdit = new AntdUI.Button { Text = "Edit", Width = 80 };
            btnNoticeSave = new AntdUI.Button { Text = "Save", Width = 80 };
            btnNoticeDelete = new AntdUI.Button { Text = "Delete", Width = 80 };
            btnNoticeRefresh = new AntdUI.Button { Text = "Refresh", Width = 80 };
            btnPanel.Controls.AddRange(new Control[] { btnNoticeNew, btnNoticeEdit, btnNoticeSave, btnNoticeDelete, btnNoticeRefresh });

            btnNoticeNew.Click += (s, e) => NewNotice();
            btnNoticeEdit.Click += (s, e) => LoadSelectedNoticeForEdit();
            btnNoticeSave.Click += (s, e) => SaveNotice();
            btnNoticeDelete.Click += (s, e) => DeleteSelectedNotice();
            btnNoticeRefresh.Click += (s, e) => LoadNotices();

            editorPanel.Controls.Add(txtNoticeContent);
            editorPanel.Controls.Add(txtNoticeTitle);
            editorPanel.Controls.Add(btnPanel);

            noticeCard.Controls.Add(editorPanel);

            rightColumn.Controls.Add(noticeCard, 0, 0);

            // Featured Teachers (stacked, wrap to next row when full)
            var featuredCard = new System.Windows.Forms.Panel { BackColor = Color.White, Dock = DockStyle.Fill, Padding = new Padding(12), Margin = new Padding(6,0,6,6) };
            var featuredHeader = new AntdUI.Label { Text = "Featured Teachers", Font = new Font("Segoe UI", 12F, FontStyle.Bold), Dock = DockStyle.Top, AutoSizeMode = AntdUI.TAutoSize.Auto };
            featuredCard.Controls.Add(featuredHeader);

            // --- CHANGED: horizontal layout that wraps to next line when full ---
            featuredFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight, // place items left-to-right
                WrapContents = true,                        // wrap to next row when no more horizontal space
                AutoScroll = true,                          // show vertical scrollbar if rows exceed height
                AutoSize = false
            };
            // remove internal spacing so cards align tightly
            featuredFlow.Margin = Padding.Empty;
            featuredFlow.Padding = Padding.Empty;
            featuredCard.Controls.Add(featuredFlow);

            rightColumn.Controls.Add(featuredCard, 0, 1);

            // Add the right column to the RIGHT column (column 1) and span two rows so it fills down
            main.Controls.Add(rightColumn, 1, 1);
            main.SetRowSpan(rightColumn, 2);

            Controls.Add(main);

            // after layout is built - load data-driven content
            try { LoadNotices(); } catch { }
            try { LoadFeatured(); } catch { }

            // fill fees chart from DB totals
            try
            {
                var totals = _tuitionDao.GetTotals();
                decimal totalFee = totals.TotalFee;
                decimal paid = totals.AmountPaid;
                decimal due = Math.Max(0, totalFee - paid);

                sTotal.Points.Clear();
                sPaid.Points.Clear();
                sDue.Points.Clear();

                sTotal.Points.AddXY("Totals", (double)totalFee);
                sPaid.Points.AddXY("Totals", (double)paid);
                sDue.Points.AddXY("Totals", (double)due);

                feesChart.Invalidate();
            }
            catch { }
        }

        private System.Windows.Forms.Panel CreateStatCard(string label, string faIcon, int value, Color accent)
        {
            var card = new System.Windows.Forms.Panel { Width = 220, Height = 90, BackColor = Color.White, Margin = new Padding(8), Padding = new Padding(10) };
            var icon = new IconPictureBox { IconChar = IconChar.Users, IconColor = accent, SizeMode = PictureBoxSizeMode.CenterImage, Size = new Size(36, 36), Location = new Point(8, 18) };
            var lbl = new AntdUI.Label { Text = label, Location = new Point(56, 12), Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(90, 90, 90), AutoSizeMode = AntdUI.TAutoSize.Auto };
            var val = new AntdUI.Label { Text = value.ToString("N0"), Location = new Point(56, 36), Font = new Font("Segoe UI", 16F, FontStyle.Bold), ForeColor = Color.FromArgb(30, 30, 30) };
            card.Controls.Add(icon);
            card.Controls.Add(lbl);
            card.Controls.Add(val);
            return card;
        }

        private void LoadDashboardData()
        {
            LoadNotices();
            LoadFeatured();
            // load fees/collection content is already populated in BuildLayout chart loading,
            // but you can call a separate loader here if you prefer:
            // LoadFeesSummaryToChart();
        }

        private void LoadNotices()
        {
            dgvNotices.Rows.Clear();
            foreach (var n in _noticeService.GetAll())
            {
                dgvNotices.Rows.Add(n.NoticeId, n.Title, n.CreatedAt.ToString("yyyy-MM-dd"));
            }
            ClearNoticeEditor();
        }

        private void NewNotice()
        {
            _editingNoticeId = -1;
            txtNoticeTitle.Text = "";
            txtNoticeContent.Text = "";
            txtNoticeTitle.Focus();
        }

        private void LoadSelectedNoticeForEdit()
        {
            if (dgvNotices.SelectedRows.Count != 1) return;
            var id = Convert.ToInt32(dgvNotices.SelectedRows[0].Cells["NoticeId"].Value);
            var n = _noticeService.GetById(id);
            if (n == null) return;
            _editingNoticeId = n.NoticeId;
            txtNoticeTitle.Text = n.Title;
            txtNoticeContent.Text = n.Content;
        }

        private void SaveNotice()
        {
            var title = txtNoticeTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Title required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNoticeTitle.Focus();
                return;
            }
            var content = txtNoticeContent.Text.Trim();
            if (_editingNoticeId == -1)
            {
                var hn = new HomeNotice { Title = title, Content = content, CreatedAt = DateTime.Now };
                var id = _noticeService.Create(hn);
                if (id > 0) LoadNotices();
            }
            else
            {
                var hn = _noticeService.GetById(_editingNoticeId);
                if (hn == null) { MessageBox.Show("Item not found", "Error"); return; }
                hn.Title = title;
                hn.Content = content;
                if (_noticeService.Update(hn)) LoadNotices();
            }
            ClearNoticeEditor();
        }

        private void DeleteSelectedNotice()
        {
            if (dgvNotices.SelectedRows.Count != 1) return;
            var id = Convert.ToInt32(dgvNotices.SelectedRows[0].Cells["NoticeId"].Value);
            if (MessageBox.Show("Delete selected notice?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            if (_noticeService.Delete(id)) LoadNotices();
        }

        private void ClearNoticeEditor()
        {
            _editingNoticeId = -1;
            txtNoticeTitle.Text = "";
            txtNoticeContent.Text = "";
        }

        private void LoadFeatured()
        {
            featuredFlow.Controls.Clear();
            var list = _featuredDao.GetActive().ToList();
            foreach (var f in list)
            {
                var imgPath = ResolveImagePath(f.ImagePath);
                // pass the summary from DB into the card so the click can show it
                var ctrl = CreateFeaturedTeacherCard(f.FeaturedId, f.Title, imgPath, f.Summary);
                featuredFlow.Controls.Add(ctrl);
            }
        }

        private Control CreateFeaturedTeacherCard(int featuredId, string displayName, string imageFilePath, string summary)
        {
            var card = new System.Windows.Forms.Panel
            {
                Width = 260,
                Height = 120,
                Margin = new Padding(6),
                Padding = new Padding(8),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = featuredId // store id if needed later
            };

            Control pictureCtrl;
            try
            {
                if (!string.IsNullOrEmpty(imageFilePath) && System.IO.File.Exists(imageFilePath))
                {
                    var pb = new PictureBox { Image = Image.FromFile(imageFilePath), SizeMode = PictureBoxSizeMode.Zoom, Size = new Size(96, 96), Location = new Point(8, 12) };
                    pictureCtrl = pb;
                }
                else
                {
                    var ip = new IconPictureBox { IconChar = IconChar.UserGraduate, IconColor = Color.FromArgb(45, 140, 240), IconSize = 64, Size = new Size(96, 96), Location = new Point(8, 12) };
                    pictureCtrl = ip;
                }
            }
            catch
            {
                var ip = new IconPictureBox { IconChar = IconChar.UserGraduate, IconColor = Color.FromArgb(45, 140, 240), IconSize = 64, Size = new Size(96, 96), Location = new Point(8, 12) };
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

            // click handler shows summary from DB (provided via summary parameter)
            void ShowSummaryHandler(object sender, EventArgs e)
            {
                var text = string.IsNullOrWhiteSpace(summary) ? "No summary available." : summary;
                // show in a dialog titled with the teacher name, allow multi-line content
                MessageBox.Show(text, displayName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Attach handler to card and child controls so clicks anywhere trigger it
            card.Click += ShowSummaryHandler;
            pictureCtrl.Click += ShowSummaryHandler;
            lblName.Click += ShowSummaryHandler;
            lblMeta.Click += ShowSummaryHandler;

            card.Controls.Add(pictureCtrl);
            card.Controls.Add(lblName);
            card.Controls.Add(lblMeta);

            return card;
        }

        private string ResolveImagePath(string storedPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(storedPath)) return null;
                var filename = System.IO.Path.GetFileName(storedPath);
                var candidate = System.IO.Path.Combine(Application.StartupPath, "Images", "Featured", filename);
                if (System.IO.File.Exists(candidate)) return candidate;
                candidate = System.IO.Path.Combine(Application.StartupPath, "Images", filename);
                if (System.IO.File.Exists(candidate)) return candidate;
                if (System.IO.Path.IsPathRooted(storedPath) && System.IO.File.Exists(storedPath)) return storedPath;
                return null;
            }
            catch { return null; }
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
