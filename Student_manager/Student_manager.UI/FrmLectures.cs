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
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmLectures : Form
    {
        private readonly LecturesService _lectureService;
        private List<Teacher> _lecturers;
        private readonly ErrorProvider _errorProvider = new ErrorProvider();
        private int _editingTeacherId = 0;
        private Teacher _originalTeacherSnapshot = null;

        public frmLectures()
        {
            InitializeComponent();
            try
            {
                _lectureService = new LecturesService(new LecturesDAO());
            }
            catch (Exception ex)
            {
                // Converted: "Lỗi khi khởi tạo LecturesService/LecturesDAO:\r\n" -> "Error initializing LecturesService/LecturesDAO:\r\n"
                // Converted: "Lỗi khởi tạo" -> "Initialization Error"
                MessageBox.Show("Error initializing LecturesService/LecturesDAO:\r\n" + ex.ToString(),
                    "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _lectureService = null;
            }

            Load += frmLectures_Load;
            AttachValidationHandlers();

            var btnDelete = this.Controls.Find("btnDelete", true).FirstOrDefault() as Button;
            if (btnDelete != null)
            {
                btnDelete.Click -= btnDelete_Click;
                btnDelete.Click += btnDelete_Click;
            }
        }

        private void frmLectures_Load(object sender, EventArgs e)
        {
            LoadLecturesIntoGrid();
            SetEditingControlsEnabled(false);
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnModify.Enabled = false;
        }

        private void AttachValidationHandlers()
        {
            var tbCode = this.Controls.Find("txtTeacherCode", true).FirstOrDefault() as TextBox;
            var tbFirst = this.Controls.Find("txtFirstName", true).FirstOrDefault() as TextBox;
            var tbLast = this.Controls.Find("txtLastName", true).FirstOrDefault() as TextBox;
            var tbEmail = this.Controls.Find("txtEmail", true).FirstOrDefault() as TextBox;
            if (tbCode != null) tbCode.Validating += TextBox_Validating;
            if (tbFirst != null) tbFirst.Validating += TextBox_Validating;
            if (tbLast != null) tbLast.Validating += TextBox_Validating;
            if (tbEmail != null) tbEmail.Validating += TextBox_Validating;
            _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void LoadLecturesIntoGrid()
        {
            try
            {
                if (_lectureService == null)
                {
                    // Converted: "Không khởi tạo được service." -> "Service failed to initialize."
                    // Converted: "Lỗi" -> "Error"
                    MessageBox.Show("Service failed to initialize.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _lecturers = _lectureService.GetAllLecturers() ?? new List<Teacher>();
                var dgv = FindFirstDataGridView(this.Controls);
                if (dgv == null)
                {
                    // Converted: "Không tìm thấy DataGridView." -> "DataGridView not found."
                    // Converted: "Lỗi" -> "Error"
                    MessageBox.Show("DataGridView not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgv.DataSource = new BindingList<Teacher>(_lecturers);
                dgv.Dock = DockStyle.Fill;
                dgv.BringToFront();
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.AllowUserToAddRows = false;

                if (dgv.Columns.Contains("TeacherId")) dgv.Columns["TeacherId"].Visible = false;
                if (dgv.Columns.Contains("TeacherCode")) dgv.Columns["TeacherCode"].HeaderText = "Teacher Code";
                if (dgv.Columns.Contains("FirstName")) dgv.Columns["FirstName"].HeaderText = "First Name";
                if (dgv.Columns.Contains("LastName")) dgv.Columns["LastName"].HeaderText = "Last Name";
                if (dgv.Columns.Contains("Email")) dgv.Columns["Email"].HeaderText = "Email";
                if (dgv.Columns.Contains("Specialization")) dgv.Columns["Specialization"].HeaderText = "Specialization";
                if (dgv.Columns.Contains("PhoneNumber")) dgv.Columns["PhoneNumber"].HeaderText = "Phone Number";

                dgv.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                // Converted: "Lỗi khi nạp giảng viên: " -> "Error loading lecturers: "
                MessageBox.Show("Error loading lecturers: " + ex.Message);
            }
        }

        private DataGridView FindFirstDataGridView(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is DataGridView dgv) return dgv;
                if (c.HasChildren)
                {
                    var found = FindFirstDataGridView(c.Controls);
                    if (found != null) return found;
                }
            }
            return null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _editingTeacherId = 0;
            _originalTeacherSnapshot = null;
            SetEditingControlsEnabled(true);
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            ClearInputFields();
            txtTeacherCode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputFields(out string msg))
            {
                MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var teacher = new Teacher
            {
                TeacherCode = txtTeacherCode.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Specialization = txtSpecialization.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim()
            };

            try
            {
                string result;
                if (_editingTeacherId > 0)
                {
                    teacher.TeacherId = _editingTeacherId;
                    result = _lectureService.UpdateLecturer(teacher);
                }
                else
                {
                    result = _lectureService.AddLecturer(teacher);
                }

                // Converted: "Kết quả" -> "Result"
                MessageBox.Show(result, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLecturesIntoGrid();

                SetEditingControlsEnabled(false);
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                btnModify.Enabled = false;
            }
            catch (Exception ex)
            {
                // Converted: "Lỗi khi lưu giảng viên:\r\n" -> "Error saving lecturer:\r\n"
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("Error saving lecturer:\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputFields(out string msg)
        {
            msg = null;
            _errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtTeacherCode.Text))
            {
                // Converted: "Teacher Code không được để trống." -> "Teacher Code cannot be empty."
                msg = "Teacher Code cannot be empty."; _errorProvider.SetError(txtTeacherCode, msg); return false;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                // Converted: "First Name không được để trống." -> "First Name cannot be empty."
                msg = "First Name cannot be empty."; _errorProvider.SetError(txtFirstName, msg); return false;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                // Converted: "Last Name không được để trống." -> "Last Name cannot be empty."
                msg = "Last Name cannot be empty."; _errorProvider.SetError(txtLastName, msg); return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                // Converted: "Email không được để trống." -> "Email cannot be empty."
                msg = "Email cannot be empty."; _errorProvider.SetError(txtEmail, msg); return false;
            }
            if (!txtEmail.Text.Contains("@"))
            {
                // Converted: "Email không hợp lệ." -> "Invalid Email format."
                msg = "Invalid Email format."; _errorProvider.SetError(txtEmail, msg); return false;
            }
            return true;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            var dgv = FindFirstDataGridView(this.Controls);
            if (dgv?.CurrentRow == null) return;

            if (dgv.CurrentRow.DataBoundItem is Teacher t)
            {
                _editingTeacherId = t.TeacherId;
                _originalTeacherSnapshot = new Teacher
                {
                    TeacherId = t.TeacherId,
                    TeacherCode = t.TeacherCode,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Email = t.Email,
                    Specialization = t.Specialization,
                    PhoneNumber = t.PhoneNumber
                };

                FillFormFromTeacher(t);
                SetEditingControlsEnabled(true);
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                btnAdd.Enabled = false;
                btnModify.Enabled = false;
            }
        }

        private void FillFormFromTeacher(Teacher t)
        {
            txtTeacherCode.Text = t.TeacherCode;
            txtFirstName.Text = t.FirstName;
            txtLastName.Text = t.LastName;
            txtEmail.Text = t.Email;
            txtSpecialization.Text = t.Specialization;
            txtPhoneNumber.Text = t.PhoneNumber;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;

            try
            {
                // 1. Xóa tất cả thông báo lỗi hiện tại -> Clear all current error messages
                _errorProvider.Clear();

                // 2. Phục hồi dữ liệu (nếu đang ở chế độ Modify) hoặc xóa sạch (nếu đang ở chế độ Add)
                // -> Restore data (if in Modify mode) or clear all (if in Add mode)
                if (_originalTeacherSnapshot != null)
                {
                    // Nếu là Modify, phục hồi dữ liệu ban đầu -> If Modify, restore original data
                    FillFormFromTeacher(_originalTeacherSnapshot);
                }
                else
                {
                    // Nếu là Add, xóa sạch các trường -> If Add, clear fields
                    ClearInputFields();
                }

                // 3. Đặt lại trạng thái Form về chế độ xem an toàn -> Reset Form state to safe view mode
                SetEditingControlsEnabled(false);

                // 4. Reset các biến trạng thái -> Reset state variables
                _editingTeacherId = 0;
                _originalTeacherSnapshot = null;

                // 5. Điều khiển trạng thái nút -> Control button states
                btnAdd.Enabled = true;
                btnModify.Enabled = false; // Tắt Modify -> Disable Modify
                btnSave.Enabled = false;
                btnCancel.Enabled = false;

                // 6. Tải lại lưới giảng viên -> Reload lecturer grid
                LoadLecturesIntoGrid();
            }
            catch (Exception ex)
            {
                // Converted: "Lỗi khi hủy thao tác: " -> "Error cancelling operation: "
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("Error cancelling operation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // BẬT LẠI AutoValidate sau khi hủy hoàn tất.
                // Điều này đảm bảo validation sẽ hoạt động trở lại khi người dùng cố gắng Save.
                // Re-ENABLE AutoValidate after cancellation is complete.
                // This ensures validation will work again when the user attempts to Save.
                this.AutoValidate = AutoValidate.EnablePreventFocusChange;
                // Hoặc sử dụng EnableAllowFocusChange tùy thuộc vào thiết lập ban đầu của bạn.
                // Or use EnableAllowFocusChange depending on your initial setting.
                // Nếu không rõ, có thể dùng lại this.AutoValidate = AutoValidate.EnablePreventFocusChange;
                // If unsure, you can reuse this.AutoValidate = AutoValidate.EnablePreventFocusChange;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dgv = FindFirstDataGridView(this.Controls);
            if (dgv == null || dgv.SelectedRows.Count == 0)
            {
                // Converted: "Vui lòng chọn giảng viên để xóa." -> "Please select a lecturer to delete."
                // Converted: "Thông báo" -> "Notification"
                MessageBox.Show("Please select a lecturer to delete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = dgv.SelectedRows[0];
            if (selected.DataBoundItem is Teacher t)
            {
                // Converted: "Bạn có chắc muốn xóa giảng viên {t.FirstName} {t.LastName}?" -> "Are you sure you want to delete lecturer {t.FirstName} {t.LastName}?"
                // Converted: "Xác nhận" -> "Confirmation"
                var confirm = MessageBox.Show($"Are you sure you want to delete lecturer {t.FirstName} {t.LastName}?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                string result = _lectureService.DeleteLecturer(t.TeacherId);
                // Converted: "Kết quả" -> "Result"
                MessageBox.Show(result, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLecturesIntoGrid();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Converted: "Bạn có chắc muốn thoát?" -> "Are you sure you want to exit?"
            // Converted: "Xác nhận" -> "Confirmation"
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Close();
            }
        }
        private void dgvLectures_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bật nút Sửa -> Enable Modify button
            btnModify.Enabled = true;

            // Nếu click vào tiêu đề cột thì bỏ qua -> Ignore if column header is clicked
            if (e.RowIndex < 0) return;

            // Lấy DataGridView đang gọi sự kiện -> Get the DataGridView raising the event
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            // Lấy dòng được chọn -> Get the selected row
            var row = dgv.Rows[e.RowIndex];

            // Đổ dữ liệu từ dòng vào form -> Fill form with data from the row
            FillFormFromRow(row);
        }

        private void FillFormFromRow(DataGridViewRow row)
        {
            if (row == null) return;

            txtTeacherCode.Text = row.Cells["TeacherCode"].Value?.ToString() ?? string.Empty;
            txtFirstName.Text = row.Cells["FirstName"].Value?.ToString() ?? string.Empty;
            txtLastName.Text = row.Cells["LastName"].Value?.ToString() ?? string.Empty;
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
            txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value?.ToString() ?? string.Empty;
            txtSpecialization.Text = row.Cells["Specialization"].Value?.ToString() ?? string.Empty;
        }


        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            if (sender is TextBox tb && string.IsNullOrWhiteSpace(tb.Text))
            {
                // Converted: "Không được để trống" -> "Cannot be empty"
                _errorProvider.SetError(tb, "Cannot be empty");
                e.Cancel = true;
            }
        }

        private void SetEditingControlsEnabled(bool enabled)
        {
            txtTeacherCode.Enabled = enabled;
            txtFirstName.Enabled = enabled;
            txtLastName.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtSpecialization.Enabled = enabled;
            txtPhoneNumber.Enabled = enabled;
        }

        private void ClearInputFields()
        {
            txtTeacherCode.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtSpecialization.Text = "";
            txtPhoneNumber.Text = "";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Tìm textbox tìm kiếm theo tên phổ biến -> Find search textbox by common name
            var searchBox = FindFirstTextBox(new[] { "txtSearch", "txtSearchTeacher", "txtTeacherSearch", "txtTeacherCode" });
            if (searchBox == null)
            {
                // Converted: "Không tìm thấy ô tìm kiếm (txtSearch / txtTeacherSearch)." -> "Search box (txtSearch / txtTeacherSearch) not found."
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("Search box (txtSearch / txtTeacherSearch) not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string keyword = searchBox.Text?.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Converted: "Vui lòng nhập mã hoặc tên giảng viên để tìm." -> "Please enter lecturer code or name to search."
                // Converted: "Thông báo" -> "Notification"
                MessageBox.Show("Please enter lecturer code or name to search.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Lấy DataGridView hiển thị danh sách giảng viên -> Get the DataGridView displaying the list of lecturers
                var dgv = FindFirstDataGridView(this.Controls);
                if (dgv == null)
                {
                    // Converted: "Không tìm thấy DataGridView trên form." -> "DataGridView not found on the form."
                    // Converted: "Lỗi" -> "Error"
                    MessageBox.Show("DataGridView not found on the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xóa chọn và reset màu dòng -> Clear selection and reset row color
                dgv.ClearSelection();
                var defaultBack = dgv.DefaultCellStyle.BackColor;
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    r.DefaultCellStyle.BackColor = defaultBack;
                }

                bool any = false;
                int firstMatchIndex = -1;

                // Duyệt tất cả các dòng để tìm theo TeacherCode hoặc Họ tên -> Iterate all rows to search by TeacherCode or Full Name
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    var row = dgv.Rows[i];
                    if (row.IsNewRow) continue;

                    string teacherCode = "";
                    string fullName = "";

                    // Nếu DataBoundItem là Teacher model -> If DataBoundItem is Teacher model
                    if (row.DataBoundItem is Teacher t)
                    {
                        teacherCode = t.TeacherCode ?? "";
                        fullName = (t.FirstName + " " + t.LastName).Trim();
                    }
                    else
                    {
                        // fallback: lấy theo tên cột -> fallback: get by column name
                        if (dgv.Columns.Contains("TeacherCode"))
                        {
                            var val = row.Cells["TeacherCode"].Value;
                            teacherCode = val == null ? "" : val.ToString();
                        }
                        if (dgv.Columns.Contains("FullName"))
                        {
                            var val = row.Cells["FullName"].Value;
                            fullName = val == null ? "" : val.ToString();
                        }
                    }

                    // So sánh theo mã hoặc họ tên -> Compare by code or full name
                    if ((!string.IsNullOrEmpty(teacherCode) && teacherCode.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrEmpty(fullName) && fullName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        any = true;
                        if (firstMatchIndex == -1) firstMatchIndex = i;
                    }
                }

                if (any && firstMatchIndex >= 0)
                {
                    // Chọn dòng đầu tiên khớp -> Select the first matching row
                    var matchRow = dgv.Rows[firstMatchIndex];
                    matchRow.Selected = true;
                    try { dgv.FirstDisplayedScrollingRowIndex = Math.Max(0, firstMatchIndex); } catch { }

                    // Fill dữ liệu dòng tìm thấy vào textbox -> Fill data of the found row into textboxes
                    FillFormFromRow(matchRow);
                }
                else
                {
                    // Converted: "Không tìm thấy giảng viên với mã hoặc tên \"{keyword}\"." -> "No lecturer found with code or name \"{keyword}\"."
                    // Converted: "Thông báo" -> "Notification"
                    MessageBox.Show($"No lecturer found with code or name \"{keyword}\".", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Converted: "Lỗi khi tìm kiếm giảng viên: " -> "Error searching for lecturer: "
                // Converted: "Lỗi" -> "Error"
                MessageBox.Show("Error searching for lecturer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private TextBox FindFirstTextBox(string[] possibleNames)
        {
            foreach (var n in possibleNames)
            {
                var tb = this.Controls.Find(n, true).FirstOrDefault() as TextBox;
                if (tb != null) return tb;
            }
            return this.Controls.OfType<TextBox>().FirstOrDefault();
        }
    }
}