using Student_manager.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmStudy : Form
    {
        private readonly CourseService _courseService = new CourseService();
        private readonly ClassService _classService = new ClassService();
        private readonly ScoreTypeService _scoreTypeService = new ScoreTypeService();
        private readonly ScoreService _scoreService = new ScoreService();
        private readonly AttendanceService _attendanceService = new AttendanceService();
        private readonly EnrollmentService _enrollmentService = new EnrollmentService();
        private List<dynamic> allScores = new List<dynamic>();
        private int selectedScoreId = -1;
        private bool isInitializing = true;
        private int currentEnrollmentId = -1;
        private int selectedAttendanceId = -1;
        public frmStudy()
        {
            InitializeComponent();
            this.Load += frmStudy_Load;
            cboCourse.SelectedIndexChanged += cboCourse_SelectedIndexChanged;
            cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
           
        }
        private void LoadScoreTypeCombo()
        {
            isInitializing = true;
            cboScoreType.DataSource = _scoreTypeService.GetAllScoreTypes().ToList();
            cboScoreType.DisplayMember = "ScoreTypeName";
            cboScoreType.ValueMember = "ScoreTypeId";
            cboScoreType.SelectedIndex = -1;
            isInitializing = false;
        }

        private void LoadCourseCombo()
        {
            cboCourse.DataSource = _courseService.GetAllCourses().ToList();
            cboCourse.DisplayMember = "CourseName";
            cboCourse.ValueMember = "CourseId";
            cboCourse.SelectedIndex = -1;
        }

        private void LoadClassCombo(int courseId)
        {
            cboClass.DataSource = _classService.GetClassesByCourseId(courseId).ToList();
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassId";
            cboClass.SelectedIndex = -1;
        }

        private void LoadScores(int enrollmentId)
        {
            try
            {
                // ⚠️ Tạm thời hủy liên kết sự kiện SelectionChanged
                dgvBangDiem.SelectionChanged -= dgvBangDiem_SelectionChanged;

                var scores = _scoreService.GetScoresByEnrollment(enrollmentId).ToList();
                var scoreTypes = _scoreTypeService.GetAllScoreTypes().ToList();

                // 🔹 Lấy thông tin sinh viên
                var enrollment = _enrollmentService.GetById(enrollmentId);
                string studentCode = "";
                string studentName = "";

                if (enrollment != null)
                {
                    var student = enrollment.Student;
                    if (student != null)
                    {
                        studentCode = student.StudentCode ?? "";
                        studentName = student.FullName ?? "";
                    }
                }

                // 🔹 Ghép tên loại điểm
                allScores = (from s in scores
                             join st in scoreTypes on s.ScoreTypeId equals st.ScoreTypeId
                             select new
                             {
                                 ScoreId = s.ScoreId,
                                 StudentCode = studentCode,
                                 StudentName = studentName,
                                 ScoreTypeId = s.ScoreTypeId,
                                 ScoreTypeName = st.ScoreTypeName,
                                 ScoreValue = s.ScoreValue
                             }).Cast<dynamic>().ToList();

                dgvBangDiem.DataSource = null;
                dgvBangDiem.Columns.Clear();

                dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ScoreId",
                    DataPropertyName = "ScoreId",
                    HeaderText = "Mã điểm",
                    Width = 80
                });
                dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "StudentCode",
                    DataPropertyName = "StudentCode",
                    HeaderText = "Mã SV",
                    Width = 100
                });
                dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "StudentName",
                    DataPropertyName = "StudentName",
                    HeaderText = "Họ tên",
                    Width = 160
                });
                dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ScoreTypeName",
                    DataPropertyName = "ScoreTypeName",
                    HeaderText = "Loại điểm",
                    Width = 140
                });
                dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ScoreValue",
                    DataPropertyName = "ScoreValue",
                    HeaderText = "Điểm",
                    Width = 80
                });

                dgvBangDiem.DataSource = allScores;
                dgvBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 🔹 Xóa chọn sau khi nạp
                dgvBangDiem.ClearSelection();
                txtScore.Clear(); // ✅ đảm bảo textbox trống
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading scores:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // ✅ Gắn lại sự kiện SelectionChanged
                dgvBangDiem.SelectionChanged += dgvBangDiem_SelectionChanged;
            }
        }

        private void LoadAttendances(int enrollmentId)
        {
            try
            {
                var attends = _attendanceService.GetByEnrollmentId(enrollmentId).ToList();

                // 🔸 Lấy thông tin sinh viên từ Enrollment
                var enrollment = _enrollmentService.GetById(enrollmentId);
                string studentCode = "";
                string studentName = "";

                if (enrollment != null)
                {
                    var student = enrollment.Student;
                    if (student != null)
                    {
                        studentCode = student.StudentCode ?? "";
                        studentName = student.FullName ?? "";
                    }
                }

                dgvAttendance.DataSource = null;
                dgvAttendance.Columns.Clear();

                // 🔹 Cấu trúc cột DataGridView
                dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "AttendanceId",
                    DataPropertyName = "AttendanceId",
                    HeaderText = "AttendanceId",
                    Width = 100
                });
                dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "StudentCode",
                    DataPropertyName = "StudentCode",
                    HeaderText = "StudentCode",
                    Width = 100
                });
                dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "StudentName",
                    DataPropertyName = "StudentName",
                    HeaderText = "FullName",
                    Width = 160
                });
                dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SessionDate",
                    DataPropertyName = "SessionDate",
                    HeaderText = "SessionDate",
                    Width = 120,
                    DefaultCellStyle = { Format = "dd/MM/yyyy" }
                });
                dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    DataPropertyName = "Status",
                    HeaderText = "Status",
                    Width = 120
                });

                // 🔹 Chuẩn bị dữ liệu hiển thị (⚠️ thêm AttendanceId + SessionDate)
                var data = attends.Select(a => new
                {
                    AttendanceId = a.AttendanceId,
                    StudentCode = studentCode,
                    StudentName = studentName,
                    SessionDate = a.SessionDate, // ✅ Thêm dòng này
                    Status = a.Status
                }).ToList();

                dgvAttendance.DataSource = data;
                dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAttendance.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCourse.SelectedValue is int courseId && courseId > 0)
            {
                LoadClassCombo(courseId);
                dgvBangDiem.DataSource = null;
                dgvAttendance.DataSource = null;
            }
        }
        private void ClearStudyData()
        {
            cboCourse.SelectedIndex = -1;
            cboClass.DataSource = null;
            cboScoreType.SelectedIndex = -1;
            txtScore.Clear();
            dgvBangDiem.DataSource = null;
            dgvAttendance.DataSource = null;
        }
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClass.SelectedValue is int classId && classId > 0)
            {
                // 🔹 Lấy Enrollment đầu tiên trong lớp
                currentEnrollmentId = _enrollmentService.GetFirstEnrollmentIdByClass(classId);

                if (currentEnrollmentId > 0)
                {
                    LoadScores(currentEnrollmentId);
                    LoadAttendances(currentEnrollmentId);
                }
                else
                {
                    dgvBangDiem.DataSource = null;
                    dgvAttendance.DataSource = null;
                }
            }
        }

        //FORM LOAD O DAY
        //
        //
        //
        //
        //
        private void ToggleScoreButtons(bool enabled)
        {
            btnCancel.Enabled = enabled;
            btnSave.Enabled = enabled;
            btnDeleteDiem.Enabled = enabled;
        }

        private void ToggleAttendanceButtons(bool enabled)
        {
            btnSaveAttendance.Enabled = enabled;
            btnDeleteAttendance.Enabled = enabled;
        }
        private void frmStudy_Load(object sender, EventArgs e)
        {
            ToggleScoreButtons(false);
            ToggleAttendanceButtons(false);
            try
            {
                LoadCourseCombo();
                LoadScoreTypeCombo();

                // cấu hình DataGridView mặc định
                dgvBangDiem.AutoGenerateColumns = false;
                dgvAttendance.AutoGenerateColumns = false;

                dgvBangDiem.DataSource = null;
                dgvAttendance.DataSource = null;

                cboClass.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading study form data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvBangDiem_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBangDiem.CurrentRow == null || dgvBangDiem.SelectedRows.Count == 0)
            {
                ToggleScoreButtons(false); // ❌ Không chọn hàng → tắt nút
                txtScore.Clear();
                selectedScoreId = -1;
                return;
            }

            ToggleScoreButtons(true); // ✅ Có chọn hàng → bật nút

            // lấy ScoreId
            if (dgvBangDiem.CurrentRow.Cells["ScoreId"]?.Value is int scoreId)
                selectedScoreId = scoreId;
            else
                selectedScoreId = -1;

            // hiển thị điểm
            var val = dgvBangDiem.CurrentRow.Cells["ScoreValue"]?.Value?.ToString();
            txtScore.Text = val ?? "";
        }
        private void cboScoreType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;
            try
            {
                // ✅ Kiểm tra xem đã chọn course và class chưa
                if (!(cboCourse.SelectedValue is int courseId) || courseId <= 0 ||
                    !(cboClass.SelectedValue is int classId) || classId <= 0)
                {
                    // Chưa chọn course hoặc class → không làm gì
                    return;
                }

                // ✅ Nếu chưa có dữ liệu điểm → không cần lọc
                if (allScores == null || allScores.Count == 0)
                    return;

                if (cboScoreType.SelectedValue is int selectedTypeId && selectedTypeId > 0)
                {
                    // Lọc danh sách theo loại điểm
                    var filtered = allScores
                        .Where(s => s.ScoreTypeId == selectedTypeId)
                        .ToList();

                    dgvBangDiem.DataSource = filtered;
                }
                else
                {
                    // Nếu không chọn gì → hiển thị toàn bộ
                    dgvBangDiem.DataSource = allScores;
                }

                dgvBangDiem.ClearSelection();
                txtScore.Clear(); // ✅ đảm bảo textbox trống
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when load score types:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedScoreId <= 0)
                {
                    MessageBox.Show("Please select a score row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtScore.Text.Trim(), out decimal newScore))
                {
                    MessageBox.Show("Invalid score value. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool ok = _scoreService.UpdateScoreValue(selectedScoreId, newScore);

                if (ok)
                {
                    MessageBox.Show("Score updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // reload lại bảng điểm
                    LoadScores(currentEnrollmentId);

                    // chọn lại hàng vừa sửa
                    foreach (DataGridViewRow row in dgvBangDiem.Rows)
                    {
                        if (row.Cells["ScoreId"].Value != null &&
                            Convert.ToInt32(row.Cells["ScoreId"].Value) == selectedScoreId)
                        {
                            row.Selected = true;
                            dgvBangDiem.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to update score.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving score:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearStudyData();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ClearStudyData();
                ToggleScoreButtons(false);
                ToggleAttendanceButtons(false);
                MessageBox.Show("Data has been refreshed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        private void dgvAttendance_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAttendance.CurrentRow == null || dgvAttendance.SelectedRows.Count == 0)
            {
                ToggleAttendanceButtons(false);
                selectedAttendanceId = -1;
                cboStatus.SelectedIndex = -1;
                return;
            }

            ToggleAttendanceButtons(true);

            // lấy AttendanceId
            if (dgvAttendance.CurrentRow.Cells["AttendanceId"]?.Value is int attId)
                selectedAttendanceId = attId;
            else
                selectedAttendanceId = -1;

            // hiển thị ngày học
            if (dgvAttendance.CurrentRow.Cells["SessionDate"]?.Value is DateTime date)
                dtpSessionDate.Value = date;
            else
                dtpSessionDate.Value = DateTime.Now;

            // hiển thị trạng thái
            var statusVal = dgvAttendance.CurrentRow.Cells["Status"]?.Value?.ToString();
            cboStatus.Text = statusVal ?? "";
        }
        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedAttendanceId <= 0)
                {
                    MessageBox.Show("Please select an attendance record to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return;
                }

                // Lấy giá trị mới từ giao diện
                DateTime newDate = dtpSessionDate.Value;
                string newStatus = cboStatus.Text?.Trim();

                if (string.IsNullOrEmpty(newStatus))
                {
                    MessageBox.Show("Please select an attendance status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi BLL cập nhật
                bool ok = _attendanceService.UpdateAttendance(selectedAttendanceId, newDate, newStatus);

                if (ok)
                {
                    MessageBox.Show("Attendance updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload lại dữ liệu
                    LoadAttendances(currentEnrollmentId);

                    // Chọn lại dòng vừa sửa
                    foreach (DataGridViewRow row in dgvAttendance.Rows)
                    {
                        if (row.Cells["AttendanceId"].Value != null &&
                            Convert.ToInt32(row.Cells["AttendanceId"].Value) == selectedAttendanceId)
                        {
                            row.Selected = true;
                            dgvAttendance.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to update attendance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving attendance:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnDeleteAttendance.Enabled = false;
            btnSaveAttendance.Enabled = false;
            ClearStudyData();
        }
        private void btnDeleteAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedAttendanceId <= 0)
                {
                    MessageBox.Show("Please select an attendance record to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận từ người dùng
                var confirm = MessageBox.Show("Are you sure you want to delete this attendance record?",
                    "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                // Gọi BLL để xóa
                bool ok = _attendanceService.DeleteAttendance(selectedAttendanceId);

                if (ok)
                {
                    MessageBox.Show("Attendance record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload lại bảng điểm danh
                    LoadAttendances(currentEnrollmentId);

                    // Reset giao diện
                    selectedAttendanceId = -1;
                    cboStatus.SelectedIndex = -1;
                    dtpSessionDate.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Failed to delete attendance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting attendance:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteDiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedScoreId <= 0)
                {
                    MessageBox.Show("Please select a score record to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận người dùng
                var confirm = MessageBox.Show("Are you sure you want to delete this score?",
                    "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                // Gọi BLL để xóa
                bool ok = _scoreService.DeleteScore(selectedScoreId);

                if (ok)
                {
                    MessageBox.Show("Score deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload lại bảng điểm
                    LoadScores(currentEnrollmentId);

                    // Reset giao diện
                    selectedScoreId = -1;
                    txtScore.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to delete score.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting score:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtScore.Clear();
            cboStatus.SelectedIndex = -1;
            dgvBangDiem.ClearSelection();
            dgvAttendance.ClearSelection();

            ToggleScoreButtons(false);
            ToggleAttendanceButtons(false);
        }
        private void dgvBangDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblStudentID_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void dgvBangDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
