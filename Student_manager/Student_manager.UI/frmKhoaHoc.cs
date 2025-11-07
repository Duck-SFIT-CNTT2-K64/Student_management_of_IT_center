using Student_manager.BLL;
using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_manager.BLL;
using Student_manager.DAL;
using Student_manager.Models;
using System.Globalization;

namespace Student_manager.UI
{
    public partial class frmKhoaHoc : Form
    {
        private readonly CourseService _courseService;
        private List<Course> _courses;
        private readonly ErrorProvider _errorProvider = new ErrorProvider();
        private int _editingCourseId = 0;
        private Course _originalCourseSnapshot = null;
        public frmKhoaHoc()
        {
            InitializeComponent();
            // Khởi tạo service sử dụng DAO mặc định, bọc try/catch để hiển thị lỗi khởi tạo nếu có
            try
            {
                _courseService = new CourseService(new CourseDAO());
            }
            catch (Exception ex)
            {
                // Hiển thị thông tin lỗi chi tiết để debug
                // Converted: "Lỗi khi khởi tạo CourseService/CourseDAO:\r\n" -> "Error initializing CourseService/CourseDAO:\r\n"
                // Converted: "Lỗi khởi tạo" -> "Initialization Error"
                MessageBox.Show("Error initializing CourseService/CourseDAO:\r\n" + ex.ToString(), "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _courseService = null;
            }

            // wire load
            Load += frmKhoaHoc_Load;

            // Attach validating handlers for display textboxes (exclude search textbox)
            AttachValidationHandlers();
            var btnDelete = this.Controls.Find("btnDelete", true).FirstOrDefault() as Button;
            if (btnDelete != null)
            {
                btnDelete.Click -= btnDelete_Click;
                btnDelete.Click += btnDelete_Click;
            }
        }

        private void AttachValidationHandlers()
        {
            // If your textbox names differ, change these names to match your Designer
            var tbCode = this.Controls.Find("txtCourseCode", true).FirstOrDefault() as TextBox;
            var tbName = this.Controls.Find("txtCourseName", true).FirstOrDefault() as TextBox;
            var tbFee = this.Controls.Find("txtFee", true).FirstOrDefault() as TextBox;

            if (tbCode != null) { tbCode.Validating -= TextBox_Validating; tbCode.Validating += TextBox_Validating; }
            if (tbName != null) { tbName.Validating -= TextBox_Validating; tbName.Validating += TextBox_Validating; }
            if (tbFee != null) { tbFee.Validating -= TextBox_Validating; tbFee.Validating += TextBox_Validating; }

            // Configure ErrorProvider
            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void frmKhoaHoc_Load(object sender, EventArgs e)
        {
            LoadCoursesIntoGrid();
            txtCourseCode.Enabled = false;
            txtCourseName.Enabled = false;
            txtDescription.Enabled = false;
            txtDuration.Enabled = false;
            txtFee.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnModify.Enabled = false;
        }

        private void LoadCoursesIntoGrid()
        {
            try
            {
                if (_courseService == null)
                {
                    // Converted: "Course service không khởi tạo được. Kiểm tra kết nối CSDL hoặc cấu hình." -> "Course service failed to initialize. Check database connection or configuration."
                    // Converted: "Lỗi" -> "Error"
                    MessageBox.Show("Course service failed to initialize. Check database connection or configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _courses = _courseService.GetAllCourses() ?? new List<Course>();

                var dgv = FindFirstDataGridView(this.Controls);
                if (dgv == null)
                {
                    // Converted: "Không tìm thấy DataGridView trên form để hiển thị dữ liệu." -> "DataGridView not found on the form to display data."
                    // Converted: "Lỗi" -> "Error"
                    MessageBox.Show("DataGridView not found on the form to display data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // đảm bảo DataGridView chiếm toàn bộ form con và hiển thị trước
                dgv.Dock = DockStyle.Fill;
                dgv.BringToFront();
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.AllowUserToAddRows = false; // optional

                var binding = new BindingList<Course>(_courses);
                dgv.DataSource = binding;

                if (dgv.Columns.Contains("CourseId"))
                    dgv.Columns["CourseId"].Visible = false;

                if (dgv.Columns.Contains("CourseCode"))
                    dgv.Columns["CourseCode"].HeaderText = "Course Code";
                if (dgv.Columns.Contains("CourseName"))
                    dgv.Columns["CourseName"].HeaderText = "Course Name";
                if (dgv.Columns.Contains("Description"))
                    dgv.Columns["Description"].HeaderText = "Description";
                if (dgv.Columns.Contains("Duration"))
                    dgv.Columns["Duration"].HeaderText = "Duration";
                if (dgv.Columns.Contains("TuitionFee"))
                    dgv.Columns["TuitionFee"].HeaderText = "Tuition Fee";

                dgv.AutoResizeColumns();
                dgv.Refresh();

                // Nếu danh sách rỗng, hiển thị thông báo nhẹ (tuỳ chọn)
                if (binding.Count == 0)
                {
                    // Converted: "Không có dữ liệu khóa học để hiển thị." -> "No course data to display."
                    // MessageBox.Show("No course data to display.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Converted: "Lỗi khi nạp dữ liệu khóa học: " -> "Error loading course data: "
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("Error loading course data: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm đệ quy tìm DataGridView đầu tiên trong Controls (hữu ích khi DataGridView nằm trong Panel/GroupBox...)
        private DataGridView FindFirstDataGridView(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is DataGridView dgv) return dgv;
                if (c.HasChildren)
                {
                    var child = FindFirstDataGridView(c.Controls);
                    if (child != null) return child;
                }
            }
            return null;
        }

        private void dgvKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModify.Enabled = true;
            if (e.RowIndex < 0) return;

            var dgv = sender as DataGridView;
            if (dgv == null) return;

            var row = dgv.Rows[e.RowIndex];
            FillFormFromRow(row);
        }
        private void FillFormFromRow(DataGridViewRow row)
        {
            try
            {
                // Nếu DataSource là BindingList<Course> thì DataBoundItem là Course
                var bound = row.DataBoundItem;
                if (bound is Course c)
                {
                    // Giả sử bạn có TextBox tên tương ứng; đổi tên nếu khác
                    if (this.Controls.Find("txtCourseCode", true).FirstOrDefault() is TextBox tbCode)
                        tbCode.Text = c.CourseCode ?? "";
                    if (this.Controls.Find("txtCourseName", true).FirstOrDefault() is TextBox tbName)
                        tbName.Text = c.CourseName ?? "";
                    if (this.Controls.Find("txtDescription", true).FirstOrDefault() is TextBox tbDesc)
                        tbDesc.Text = c.Description ?? "";
                    if (this.Controls.Find("txtDuration", true).FirstOrDefault() is TextBox tbDur)
                        tbDur.Text = c.Duration ?? "";
                    if (this.Controls.Find("txtFee", true).FirstOrDefault() is TextBox tbFee)
                        tbFee.Text = c.TuitionFee.ToString();
                    return;
                }

                // Nếu không có binding object (ví dụ bạn clear AutoGenerateColumns và dùng columns thiết kế sẵn),
                // lấy giá trị từ các cell theo tên cột
                string courseCode = GetCellString(row, "CourseCode");
                string courseName = GetCellString(row, "CourseName");
                string description = GetCellString(row, "Description");
                string duration = GetCellString(row, "Duration");
                string tuitionFee = GetCellString(row, "TuitionFee");

                if (this.Controls.Find("txtCourseCode", true).FirstOrDefault() is TextBox tbCode2)
                    tbCode2.Text = courseCode;
                if (this.Controls.Find("txtCourseName", true).FirstOrDefault() is TextBox tbName2)
                    tbName2.Text = courseName;
                if (this.Controls.Find("txtDescription", true).FirstOrDefault() is TextBox tbDesc2)
                    tbDesc2.Text = description;
                if (this.Controls.Find("txtDuration", true).FirstOrDefault() is TextBox tbDur2)
                    tbDur2.Text = duration;
                if (this.Controls.Find("txtFee", true).FirstOrDefault() is TextBox tbFee2)
                    tbFee2.Text = tuitionFee;
            }
            catch (Exception ex)
            {
                // Converted: "Lỗi khi điền dữ liệu từ dòng: " -> "Error filling data from row: "
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("Error filling data from row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCellString(DataGridViewRow row, string columnName)
        {
            if (row.DataGridView.Columns.Contains(columnName))
            {
                var val = row.Cells[columnName].Value;
                return val == null || val == DBNull.Value ? "" : val.ToString();
            }

            // fallback: nếu cột không tồn tại theo tên, thử index tương ứng (không cứng mã index ở đây)
            return "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Tìm textbox tìm kiếm theo một số tên phổ biến; nếu khác thì đổi tên trong danh sách
            var searchBox = FindFirstTextBox(new[] { "txtSearch", "txtSearchCourse", "txtCourseSearch", "txtCourse" });
            if (searchBox == null)
            {
                // Converted: "Không tìm thấy ô tìm kiếm (txtSearch / txtCourseSearch)." -> "Search box (txtSearch / txtCourseSearch) not found."
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("Search box (txtSearch / txtCourseSearch) not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = searchBox.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                // Converted: "Vui lòng nhập tên khóa học để tìm." -> "Please enter a course name to search."
                // Converted: "Thông báo" -> "Notification"
                MessageBox.Show("Please enter a course name to search.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Lấy DataGridView hiện tại
                var dgv = FindFirstDataGridView(this.Controls);
                if (dgv == null)
                {
                    // Converted: "Không tìm thấy DataGridView trên form." -> "DataGridView not found on the form."
                    // Converted: "Lỗi" -> "Error"
                    MessageBox.Show("DataGridView not found on the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuẩn bị: bỏ chọn tất cả và reset màu các dòng về mặc định
                dgv.ClearSelection();
                var defaultBack = dgv.DefaultCellStyle.BackColor;
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    r.DefaultCellStyle.BackColor = defaultBack;
                }

                // Tô màu các dòng có chứa tên (không ẩn các dòng khác)
                bool any = false;
                int firstMatchIndex = -1;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    var row = dgv.Rows[i];
                    if (row.IsNewRow) continue;

                    string courseName = "";

                    // Nếu DataBoundItem là Course, dùng property để so sánh (an toàn hơn)
                    if (row.DataBoundItem is Course boundCourse)
                    {
                        courseName = boundCourse.CourseName ?? "";
                    }
                    else
                    {
                        // fallback: lấy từ ô có tên cột "CourseName" nếu tồn tại
                        if (dgv.Columns.Contains("CourseName"))
                        {
                            var val = row.Cells["CourseName"].Value;
                            courseName = val == null || val == DBNull.Value ? "" : val.ToString();
                        }
                        else
                        {
                            // nếu không có column theo tên, thử cột 1 (thay đổi tuỳ Designer)
                            if (row.Cells.Count > 1)
                            {
                                var val = row.Cells[1].Value;
                                courseName = val == null || val == DBNull.Value ? "" : val.ToString();
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(courseName) &&
                        courseName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        // match -> tô màu
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        any = true;
                        if (firstMatchIndex == -1) firstMatchIndex = i;
                    }
                }

                if (any && firstMatchIndex >= 0)
                {
                    // chọn và cuộn tới dòng đầu tiên tìm thấy
                    var matchRow = dgv.Rows[firstMatchIndex];
                    dgv.Rows[firstMatchIndex].Selected = true;
                    try { dgv.FirstDisplayedScrollingRowIndex = Math.Max(0, firstMatchIndex); } catch { }

                    // Đồng thời fill dữ liệu dòng khớp đầu tiên lên các textbox
                    FillFormFromRow(matchRow);
                }
                else
                {
                    // Converted: "Không có khóa học \"{name}\" trong cơ sở dữ liệu." -> "No course named \"{name}\" found in the database."
                    // Converted: "Thông báo" -> "Notification"
                    MessageBox.Show($"No course named \"{name}\" found in the database.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Converted: "Lỗi khi tìm kiếm: " -> "Error during search: "
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("Error during search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private TextBox FindFirstTextBox(string[] possibleNames)
        {
            foreach (var n in possibleNames)
            {
                var tb = this.Controls.Find(n, true).FirstOrDefault() as TextBox;
                if (tb != null) return tb;
            }

            // fallback: trả TextBox đầu tiên trên form (nếu muốn)
            var anyTb = this.Controls.OfType<TextBox>().FirstOrDefault();
            return anyTb;
        }

        private void FillFormFromCourse(Course c)
        {
            if (c == null) return;
            if (this.Controls.Find("txtCourseCode", true).FirstOrDefault() is TextBox tbCode)
                tbCode.Text = c.CourseCode ?? "";
            if (this.Controls.Find("txtCourseName", true).FirstOrDefault() is TextBox tbName)
                tbName.Text = c.CourseName ?? "";
            if (this.Controls.Find("txtDescription", true).FirstOrDefault() is TextBox tbDesc)
                tbDesc.Text = c.Description ?? "";
            if (this.Controls.Find("txtDuration", true).FirstOrDefault() is TextBox tbDur)
                tbDur.Text = c.Duration ?? "";
            if (this.Controls.Find("txtFee", true).FirstOrDefault() is TextBox tbFee)
                tbFee.Text = c.TuitionFee.ToString();
        }
        // --- Add / Save handlers ---

        // Khi người dùng nhấn Add: xóa TextBox và đặt focus cho CourseCode
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _editingCourseId = 0;
            _originalCourseSnapshot = null;

            SetEditingControlsEnabled(true);
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnModify.Enabled = false;
            btnAdd.Enabled = false;

            txtCourseCode.Text = "";
            txtCourseName.Text = "";
            txtDescription.Text = "";
            txtDuration.Text = "";
            txtFee.Text = "";
            _errorProvider.Clear();
            txtCourseCode.Focus();
            // Clear input fields
            if (this.Controls.Find("txtCourseCode", true).FirstOrDefault() is TextBox tbCode)
                tbCode.Text = "";
            if (this.Controls.Find("txtCourseName", true).FirstOrDefault() is TextBox tbName)
                tbName.Text = "";
            if (this.Controls.Find("txtDescription", true).FirstOrDefault() is TextBox tbDesc)
                tbDesc.Text = "";
            if (this.Controls.Find("txtDuration", true).FirstOrDefault() is TextBox tbDur)
                tbDur.Text = "";
            if (this.Controls.Find("txtFee", true).FirstOrDefault() is TextBox tbFee)
                tbFee.Text = "";

            // Clear previous errors
            _errorProvider.Clear();

            // Set focus to first input
            if (this.Controls.Find("txtCourseCode", true).FirstOrDefault() is TextBox tbFocus)
                tbFocus.Focus();
        }
        // Khi người dùng nhấn Save: validate, gọi BLL để thêm vào DB và cập nhật dgv

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (!ValidateInputFields(out string validationMsg))
            {
                MessageBox.Show(validationMsg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tbCodeObj = this.Controls.Find("txtCourseCode", true).FirstOrDefault() as TextBox;
            var tbNameObj = this.Controls.Find("txtCourseName", true).FirstOrDefault() as TextBox;
            var tbDescObj = this.Controls.Find("txtDescription", true).FirstOrDefault() as TextBox;
            var tbDurObj = this.Controls.Find("txtDuration", true).FirstOrDefault() as TextBox;
            var tbFeeObj = this.Controls.Find("txtFee", true).FirstOrDefault() as TextBox;

            string courseCode = tbCodeObj.Text.Trim();
            string courseName = tbNameObj.Text.Trim();
            string description = tbDescObj?.Text.Trim();
            string duration = tbDurObj?.Text.Trim();
            string feeText = tbFeeObj.Text.Trim();

            // Converted: "Học phí phải là số hợp lệ." -> "Tuition Fee must be a valid number."
            if (!decimal.TryParse(feeText, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out decimal tuitionFee))
            {
                MessageBox.Show("Tuition Fee must be a valid number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFeeObj.Focus();
                return;
            }

            if (_editingCourseId > 0)
            {
                // Update existing
                var upd = new Course
                {
                    CourseId = _editingCourseId,
                    CourseCode = courseCode,
                    CourseName = courseName,
                    Description = string.IsNullOrWhiteSpace(description) ? null : description,
                    Duration = string.IsNullOrWhiteSpace(duration) ? null : duration,
                    TuitionFee = tuitionFee
                };

                var resultMessage = _courseService.UpdateCourse(upd);
                // Converted: "Kết quả" -> "Result"
                MessageBox.Show(resultMessage, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Assuming "thành công" means success
                if (!string.IsNullOrEmpty(resultMessage) && resultMessage.IndexOf("thành công", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    LoadCoursesIntoGrid();
                    SelectRowByCourseId(upd.CourseId);
                }

                // exit edit mode
                _editingCourseId = 0;
            }
            else
            {
                // Add new
                var newCourse = new Course
                {
                    CourseCode = courseCode,
                    CourseName = courseName,
                    Description = string.IsNullOrWhiteSpace(description) ? null : description,
                    Duration = string.IsNullOrWhiteSpace(duration) ? null : duration,
                    TuitionFee = tuitionFee
                };

                var resultMessage = _courseService.AddCourse(newCourse);
                // Converted: "Kết quả" -> "Result"
                MessageBox.Show(resultMessage, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Assuming "thành công" means success
                if (!string.IsNullOrEmpty(resultMessage) && resultMessage.IndexOf("thành công", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    LoadCoursesIntoGrid();
                    SelectRowByCourseCode(newCourse.CourseCode);
                }
            }

            // Restore UI state
            SetEditingControlsEnabled(false);
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
            btnModify.Enabled = false;
            _errorProvider.Clear();
        }
        private void SelectRowByCourseCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return;

            var dgv = FindFirstDataGridView(this.Controls);
            if (dgv == null) return;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var row = dgv.Rows[i];
                if (row.IsNewRow) continue;

                string rowCode = "";

                // ưu tiên DataBoundItem nếu binding là Course
                if (row.DataBoundItem is Course bound)
                {
                    rowCode = bound.CourseCode ?? "";
                }
                else if (dgv.Columns.Contains("CourseCode"))
                {
                    var val = row.Cells["CourseCode"].Value;
                    rowCode = val == null || val == DBNull.Value ? "" : val.ToString();
                }
                else if (row.Cells.Count > 0) // fallback: thử cột đầu
                {
                    var val = row.Cells[0].Value;
                    rowCode = val == null || val == DBNull.Value ? "" : val.ToString();
                }

                if (string.Equals(rowCode, code, StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        dgv.ClearSelection();
                        row.Selected = true;
                        dgv.FirstDisplayedScrollingRowIndex = Math.Max(0, i);
                    }
                    catch
                    {
                        // ignore scrolling exceptions on small grids
                    }
                    break;
                }
            }
        }
        // Validation helpers

        private bool ValidateInputFields(out string errorMessage)
        {
            errorMessage = null;
            _errorProvider.Clear();

            var tbCode = this.Controls.Find("txtCourseCode", true).FirstOrDefault() as TextBox;
            var tbName = this.Controls.Find("txtCourseName", true).FirstOrDefault() as TextBox;
            var tbFee = this.Controls.Find("txtFee", true).FirstOrDefault() as TextBox;
            var tbDesc = this.Controls.Find("txtDescription", true).FirstOrDefault() as TextBox;
            var tbDur = this.Controls.Find("txtDuration", true).FirstOrDefault() as TextBox;

            if (tbCode == null || tbName == null || tbFee == null)
            {
                // Converted: "Không tìm thấy các ô nhập cần thiết trên form." -> "Required input fields not found on the form."
                errorMessage = "Required input fields not found on the form.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbCode.Text))
            {
                // Converted: "Mã khóa học không được để trống." -> "Course Code cannot be empty."
                _errorProvider.SetError(tbCode, "Course Code cannot be empty.");
                errorMessage = "Course Code cannot be empty.";
                tbCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                // Converted: "Tên khóa học không được để trống." -> "Course Name cannot be empty."
                _errorProvider.SetError(tbName, "Course Name cannot be empty.");
                errorMessage = "Course Name cannot be empty.";
                tbName.Focus();
                return false;
            }

            // Optional length checks
            if (tbCode.Text.Length > 50)
            {
                // Converted: "Mã khóa học quá dài (tối đa 50 ký tự)." -> "Course Code is too long (max 50 characters)."
                _errorProvider.SetError(tbCode, "Course Code is too long (max 50 characters).");
                errorMessage = "Course Code is too long (max 50 characters).";
                tbCode.Focus();
                return false;
            }
            if (tbName.Text.Length > 200)
            {
                // Converted: "Tên khóa học quá dài (tối đa 200 ký tự)." -> "Course Name is too long (max 200 characters)."
                _errorProvider.SetError(tbName, "Course Name is too long (max 200 characters).");
                errorMessage = "Course Name is too long (max 200 characters).";
                tbName.Focus();
                return false;
            }
            if (tbDesc != null && tbDesc.Text.Length > 1000)
            {
                // Converted: "Mô tả quá dài (tối đa 1000 ký tự)." -> "Description is too long (max 1000 characters)."
                _errorProvider.SetError(tbDesc, "Description is too long (max 1000 characters).");
                errorMessage = "Description is too long (max 1000 characters).";
                tbDesc.Focus();
                return false;
            }
            if (tbDur != null && tbDur.Text.Length > 200)
            {
                // Converted: "Duration quá dài (tối đa 200 ký tự)." -> "Duration is too long (max 200 characters)."
                _errorProvider.SetError(tbDur, "Duration is too long (max 200 characters).");
                errorMessage = "Duration is too long (max 200 characters).";
                tbDur.Focus();
                return false;
            }

            // Tuition fee parse
            if (!decimal.TryParse(tbFee.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal fee))
            {
                // Converted: "Học phí phải là số hợp lệ." -> "Tuition Fee must be a valid number."
                _errorProvider.SetError(tbFee, "Tuition Fee must be a valid number.");
                errorMessage = "Tuition Fee must be a valid number.";
                tbFee.Focus();
                return false;
            }
            if (fee < 0)
            {
                // Converted: "Học phí không thể là số âm." -> "Tuition Fee cannot be negative."
                _errorProvider.SetError(tbFee, "Tuition Fee cannot be negative.");
                errorMessage = "Tuition Fee cannot be negative.";
                tbFee.Focus();
                return false;
            }

            return true;
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!(sender is TextBox tb)) return;

            _errorProvider.SetError(tb, string.Empty);

            string name = tb.Name;
            if (string.Equals(name, "txtCourseCode", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    // Converted: "Mã khóa học không được để trống." -> "Course Code cannot be empty."
                    _errorProvider.SetError(tb, "Course Code cannot be empty.");
                    e.Cancel = true;
                    return;
                }
                if (tb.Text.Length > 50)
                {
                    // Converted: "Mã khóa học quá dài (tối đa 50 ký tự)." -> "Course Code is too long (max 50 characters)."
                    _errorProvider.SetError(tb, "Course Code is too long (max 50 characters).");
                    e.Cancel = true;
                    return;
                }
            }
            else if (string.Equals(name, "txtCourseName", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    // Converted: "Tên khóa học không được để trống." -> "Course Name cannot be empty."
                    _errorProvider.SetError(tb, "Course Name cannot be empty.");
                    e.Cancel = true;
                    return;
                }
                if (tb.Text.Length > 200)
                {
                    // Converted: "Tên khóa học quá dài (tối đa 200 ký tự)." -> "Course Name is too long (max 200 characters)."
                    _errorProvider.SetError(tb, "Course Name is too long (max 200 characters).");
                    e.Cancel = true;
                    return;
                }
            }
            else if (string.Equals(name, "txtFee", StringComparison.OrdinalIgnoreCase))
            {
                if (!decimal.TryParse(tb.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal val))
                {
                    // Converted: "Học phí phải là số hợp lệ." -> "Tuition Fee must be a valid number."
                    _errorProvider.SetError(tb, "Tuition Fee must be a valid number.");
                    e.Cancel = true;
                    return;
                }
                if (val < 0)
                {
                    // Converted: "Học phí không thể là số âm." -> "Tuition Fee cannot be negative."
                    _errorProvider.SetError(tb, "Tuition Fee cannot be negative.");
                    e.Cancel = true;
                    return;
                }
            }

            // no error
            e.Cancel = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                // Converted: "Bạn có chắc muốn thoát form Khoa Học?" -> "Are you sure you want to exit the Course form?"
                "Are you sure you want to exit the Course form?",
                // Converted: "Xác nhận Thoát" -> "Confirm Exit"
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            var dgv = FindFirstDataGridView(this.Controls);
            if (dgv == null)
            {
                // Converted: "Không tìm thấy DataGridView trên form." -> "DataGridView not found on the form."
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("DataGridView not found on the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selRow = null;
            if (dgv.SelectedRows != null && dgv.SelectedRows.Count == 1)
                selRow = dgv.SelectedRows[0];
            else if (dgv.CurrentRow != null && !dgv.CurrentRow.IsNewRow)
                selRow = dgv.CurrentRow;
            else if (dgv.SelectedCells != null && dgv.SelectedCells.Count > 0)
                selRow = dgv.SelectedCells[0].OwningRow;

            if (selRow == null)
            {
                // Converted: "Vui lòng chọn một khóa học để chỉnh sửa." -> "Please select a course to modify."
                // Converted: "Thông báo" -> "Notification"
                MessageBox.Show("Please select a course to modify.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int courseId = 0;
            Course boundCourse = null;
            if (selRow.DataBoundItem is Course bc)
            {
                boundCourse = bc;
                courseId = bc.CourseId;
            }
            else if (dgv.Columns.Contains("CourseId"))
            {
                var val = selRow.Cells["CourseId"].Value;
                if (val != null && int.TryParse(val.ToString(), out int id)) courseId = id;
            }

            if (courseId <= 0)
            {
                // Converted: "Không xác định được CourseId của dòng chọn." -> "Could not determine CourseId of the selected row."
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("Could not determine CourseId of the selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lưu snapshot (clone) để có thể khôi phục khi Cancel
            if (boundCourse != null)
            {
                _originalCourseSnapshot = new Course
                {
                    CourseId = boundCourse.CourseId,
                    CourseCode = boundCourse.CourseCode,
                    CourseName = boundCourse.CourseName,
                    Description = boundCourse.Description,
                    Duration = boundCourse.Duration,
                    TuitionFee = boundCourse.TuitionFee
                };
            }
            else
            {
                // nếu không bound, tạo snapshot từ ô
                _originalCourseSnapshot = new Course
                {
                    CourseId = courseId,
                    CourseCode = GetCellString(selRow, "CourseCode"),
                    CourseName = GetCellString(selRow, "CourseName"),
                    Description = GetCellString(selRow, "Description"),
                    Duration = GetCellString(selRow, "Duration"),
                    TuitionFee = decimal.TryParse(GetCellString(selRow, "TuitionFee"), out var f) ? f : 0m
                };
            }

            _editingCourseId = courseId;
            SetEditingControlsEnabled(true);
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnModify.Enabled = false;

            FillFormFromRow(selRow);

            var tbName = this.Controls.Find("txtCourseName", true).FirstOrDefault() as TextBox;
            if (tbName != null) tbName.Focus();
        }
        private void SetEditingControlsEnabled(bool enabled)
        {
            // Nếu các control không tồn tại trong Designer, gọi Find để tránh NullReferenceException
            void SetEnabled(string name, bool value)
            {
                var ctrl = this.Controls.Find(name, true).FirstOrDefault() as Control;
                if (ctrl != null) ctrl.Enabled = value;
            }

            SetEnabled("txtCourseCode", enabled);
            SetEnabled("txtCourseName", enabled);
            SetEnabled("txtDescription", enabled);
            SetEnabled("txtDuration", enabled);
            SetEnabled("txtFee", enabled);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;

            try
            {
                var dgv = FindFirstDataGridView(this.Controls);

                // 1. Phục hồi dữ liệu hoặc xóa sạch
                if (_editingCourseId > 0 && _originalCourseSnapshot != null)
                {
                    // Trường hợp Modify: Phục hồi snapshot
                    FillFormFromCourse(_originalCourseSnapshot);
                    SelectRowByCourseId(_editingCourseId);
                }
                else
                {
                    // Trường hợp Add: Xóa sạch inputs
                    if (this.Controls.Find("txtCourseCode", true).FirstOrDefault() is TextBox tbCode) tbCode.Text = "";
                    if (this.Controls.Find("txtCourseName", true).FirstOrDefault() is TextBox tbName) tbName.Text = "";
                    if (this.Controls.Find("txtDescription", true).FirstOrDefault() is TextBox tbDesc) tbDesc.Text = "";
                    if (this.Controls.Find("txtDuration", true).FirstOrDefault() is TextBox tbDur) tbDur.Text = "";
                    if (this.Controls.Find("txtFee", true).FirstOrDefault() is TextBox tbFee) tbFee.Text = "";

                    // Xóa chọn dòng hiện tại nếu đang ở chế độ Add
                    if (dgv != null) dgv.ClearSelection();
                }

                // 2. Reset trạng thái chỉnh sửa về chế độ xem
                _editingCourseId = 0;
                _originalCourseSnapshot = null;
                _errorProvider.Clear(); // Xóa mọi lỗi hiển thị

                // 3. Điều khiển trạng thái nút và Controls
                SetEditingControlsEnabled(false);
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;

                // 4. Bật lại nút Modify/Delete nếu có dòng được chọn
                if (dgv != null)
                {
                    bool rowSelected = (dgv.SelectedRows != null && dgv.SelectedRows.Count == 1) || (dgv.CurrentRow != null && !dgv.CurrentRow.IsNewRow);

                    btnModify.Enabled = rowSelected;

                    var btnDelete = this.Controls.Find("btnDelete", true).FirstOrDefault() as Button;
                    if (btnDelete != null) btnDelete.Enabled = rowSelected;
                }
                else
                {
                    btnModify.Enabled = false;
                }

                // Load lại lưới (chỉ để đảm bảo form hiển thị đúng dữ liệu DB nếu không có lỗi)
                LoadCoursesIntoGrid();

            }
            catch (Exception ex)
            {
                // Converted: "Lỗi khi hủy thao tác: " -> "Error cancelling operation: "
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("Error cancelling operation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // ⚠️ BẬT LẠI AutoValidate sau khi hủy hoàn tất.
                // Đây là thiết lập quan trọng để validation hoạt động khi Save.
                this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            }
        }
        private void SelectRowByCourseId(int courseId)
        {
            var dgv = FindFirstDataGridView(this.Controls);
            if (dgv == null) return;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var row = dgv.Rows[i];
                if (row.IsNewRow) continue;

                int id = 0;
                if (row.DataBoundItem is Course bound)
                {
                    id = bound.CourseId;
                }
                else if (dgv.Columns.Contains("CourseId"))
                {
                    var val = row.Cells["CourseId"].Value;
                    if (val != null && int.TryParse(val.ToString(), out int parsed))
                        id = parsed;
                }

                if (id == courseId)
                {
                    try
                    {
                        dgv.ClearSelection();
                        row.Selected = true;
                        dgv.FirstDisplayedScrollingRowIndex = Math.Max(0, i);
                    }
                    catch
                    {
                        // ignore scroll exceptions on very small grids
                    }
                    break;
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dgv = FindFirstDataGridView(this.Controls);
            if (dgv == null)
            {
                // Converted: "Không tìm thấy DataGridView trên form." -> "DataGridView not found on the form."
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("DataGridView not found on the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgv.SelectedRows == null || dgv.SelectedRows.Count == 0)
            {
                // Converted: "Vui lòng chọn ít nhất một khóa học để xóa." -> "Please select at least one course to delete."
                // Converted: "Thông báo" -> "Notification"
                MessageBox.Show("Please select at least one course to delete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Thu thập CourseId từ các dòng được chọn
            var ids = new List<int>();
            foreach (DataGridViewRow sel in dgv.SelectedRows)
            {
                if (sel.IsNewRow) continue;
                int id = 0;
                if (sel.DataBoundItem is Course bound)
                {
                    id = bound.CourseId;
                }
                else if (dgv.Columns.Contains("CourseId"))
                {
                    var val = sel.Cells["CourseId"].Value;
                    if (val != null && int.TryParse(val.ToString(), out int parsed)) id = parsed;
                }

                if (id > 0) ids.Add(id);
            }

            if (ids.Count == 0)
            {
                // Converted: "Không tìm thấy CourseId hợp lệ để xóa." -> "No valid CourseId found to delete."
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("No valid CourseId found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Converted: "Bạn có chắc muốn xóa {ids.Count} khóa học đã chọn?" -> "Are you sure you want to delete {ids.Count} selected courses?"
            // Converted: "Xác nhận" -> "Confirmation"
            var confirm = MessageBox.Show($"Are you sure you want to delete {ids.Count} selected courses?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            var failed = new List<string>();
            foreach (var id in ids)
            {
                try
                {
                    var result = _courseService.DeleteCourse(id); // BLL trả message
                                                                  // Nếu muốn kiểm tra success chính xác, kiểm tra kết quả chứa "thành công"
                                                                  // Converted: "thành công" -> "success"
                    if (string.IsNullOrEmpty(result) || result.IndexOf("thành công", StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        failed.Add($"Id={id}: {result}");
                    }
                }
                catch (Exception ex)
                {
                    failed.Add($"Id={id}: {ex.Message}");
                }
            }

            // Cập nhật lại lưới và form
            LoadCoursesIntoGrid();
            txtCourseCode.Text = "";
            txtCourseName.Text = "";
            txtDescription.Text = "";
            txtDuration.Text = "";
            txtFee.Text = "";
            btnModify.Enabled = false;

            if (failed.Count == 0)
            {
                // Converted: "Xóa thành công." -> "Delete successful."
                // Converted: "Kết quả" -> "Result"
                MessageBox.Show("Delete successful.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Converted: "Một số mục không xóa được:\n" -> "Some items could not be deleted:\n"
                // Converted: "Kết quả" -> "Result"
                MessageBox.Show("Some items could not be deleted:\n" + string.Join("\n", failed), "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}