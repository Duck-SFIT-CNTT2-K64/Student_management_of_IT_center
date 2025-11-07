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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Student_manager.UI
{
    public partial class frmStudent : Form
    {
        private readonly StudentService _studentService = new StudentService();
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            
            try
            {
                LoadStudentData();
                LoadStatusCombo();
                ClearForm(); // reset tất cả textbox, combobox
                dgvQLSV.ClearSelection(); // không chọn hàng nào
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student list:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🟢 Hàm load danh sách sinh viên (có cả UserId)
        private void LoadStudentData()
        {
            var students = _studentService.GetAllStudents();

            dgvQLSV.DataSource = null;
            dgvQLSV.AutoGenerateColumns = false;
            dgvQLSV.Columns.Clear();

            // 🔹 Tạo cột hiển thị thủ công để kiểm soát thứ tự và tiêu đề
            dgvQLSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentId",
                DataPropertyName = "StudentId",
                HeaderText = "Student ID",
                Width = 80
            });
            dgvQLSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UserId",
                DataPropertyName = "UserId",
                HeaderText = "User ID",
                Width = 80
            });
            dgvQLSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentCode",
                DataPropertyName = "StudentCode",
                HeaderText = "StudentCode",
                Width = 100
            });
            dgvQLSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                DataPropertyName = "FullName",
                HeaderText = "FullName",
                Width = 160
            });
            dgvQLSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Gender",
                DataPropertyName = "Gender",
                HeaderText = "Gender",
                Width = 80
            });
            dgvQLSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateOfBirth",
                DataPropertyName = "DateOfBirth",
                HeaderText = "DateOfBirth",
                Width = 110,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });
            dgvQLSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                DataPropertyName = "Email",
                HeaderText = "Email",
                Width = 200
            });
            dgvQLSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                DataPropertyName = "PhoneNumber",
                HeaderText = "Phone Number",
                Width = 120
            });
            dgvQLSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Address",
                DataPropertyName = "Address",
                HeaderText = "Address",
                Width = 250
            });
            dgvQLSV.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StatusName",
                DataPropertyName = "StatusName",
                HeaderText = "Status",
                Width = 100
            });

            // 🔹 Gán dữ liệu vào DataGridView
            dgvQLSV.DataSource = students.ToList();

            // 🔹 Cấu hình hiển thị
            dgvQLSV.ReadOnly = true;
            dgvQLSV.AllowUserToAddRows = false;
            dgvQLSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQLSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadStatusCombo()
        {
            // bạn có thể dùng DAO riêng cho StudentStatus nếu có
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Đang học");
            cboStatus.Items.Add("Bảo lưu");
            cboStatus.Items.Add("Tốt nghiệp");
            cboStatus.Items.Add("Đã thôi học");


            cboSex.Items.Add("Nam");
            cboSex.Items.Add("Nữ");
        }

        private void ClearForm()
        {
            txtStudentID.Text = "";
            txtUserID.Text = "";
            txtStudentCode.Text = "";
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPhoneNum.Text = "";
            cboSex.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
            dtpBirth.Value = DateTime.Today;
        }
        private int? GetStatusIdByName(string statusName)
        {
            switch (statusName)
            {
                case "Đang học": return 1;
                case "Bảo lưu": return 2;
                case "Tốt nghiệp": return 3;
                case "Đã thôi học": return 4;
                default: return null;
            }
        }

        private void ExportToExcel(string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            worksheet.Name = "Danh sách sinh viên";

            // 🟢 Ghi tiêu đề
            worksheet.Cells[1, 1] = "DANH SÁCH SINH VIÊN";
            Excel.Range titleRange = worksheet.Range["A1", "J1"];
            titleRange.Merge();
            titleRange.Font.Size = 16;
            titleRange.Font.Bold = true;
            titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // 🟢 Ghi tên cột (dòng 3)
            for (int i = 0; i < dgvQLSV.Columns.Count; i++)
            {
                worksheet.Cells[3, i + 1] = dgvQLSV.Columns[i].HeaderText;
                worksheet.Cells[3, i + 1].Font.Bold = true;
                worksheet.Cells[3, i + 1].Interior.Color = ColorTranslator.ToOle(Color.LightGray);
            }

            // 🟢 Ghi dữ liệu (bắt đầu từ dòng 4)
            for (int i = 0; i < dgvQLSV.Rows.Count; i++)
            {
                for (int j = 0; j < dgvQLSV.Columns.Count; j++)
                {
                    worksheet.Cells[i + 4, j + 1] = dgvQLSV.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // 🟢 Tự động căn chỉnh độ rộng cột
            worksheet.Columns.AutoFit();

            // 🟢 Lưu file
            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            // 🧹 Giải phóng COM
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }


        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Kiểm tra dữ liệu hợp lệ
                if (string.IsNullOrWhiteSpace(txtUserID.Text))
                {
                    MessageBox.Show("Please enter User ID.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 🟢 Kiểm tra UserId có tồn tại trong bảng Users không
                var userService = new UserService();
                int userIdToCheck = int.Parse(txtUserID.Text);

                var existingUser = userService.GetUser(userIdToCheck);
                if (existingUser == null)
                {
                    MessageBox.Show("User ID does not exist in the Users table. Please enter a valid User ID.",
                            "Foreign key error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Please enter the student's full name.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Tạo đối tượng Student mới
                var s = new Student_manager.Models.Student
                {
                    UserId = int.Parse(txtUserID.Text),
                    FullName = txtFullName.Text.Trim(),
                    StudentCode = txtStudentCode.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    PhoneNumber = txtPhoneNum.Text.Trim(),
                    Gender = cboSex.Text.Trim(),
                    DateOfBirth = dtpBirth.Value,
                    StatusId = GetStatusIdByName(cboStatus.Text.Trim()) // ánh xạ từ tên trạng thái sang ID
                };

                // 🔹 Gọi BLL để thêm
                var newId = _studentService.CreateStudent(s);

                if (newId > 0)
                {
                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentData();      // tải lại danh sách
                    ClearForm();            // xóa trắng các ô nhập
                    dgvQLSV.ClearSelection(); // không chọn hàng nào sau khi thêm
                }
                else
                {
                    MessageBox.Show("Unable to add student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding student:\nn" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvQLSV_SelectionChanged(object sender, EventArgs e)
        {

            // Nếu không có dòng nào được chọn → bật lại nút Add
            if (dgvQLSV.SelectedRows.Count == 0)
            {
                btnAdd.Enabled = true;
                ClearForm(); // xóa trắng form để chuẩn bị thêm mới
                return;
            }

            // Nếu đang chọn dòng nào đó → tắt nút Add
            btnAdd.Enabled = false;

            if (dgvQLSV.CurrentRow == null) return;

            var row = dgvQLSV.CurrentRow;

            // Gán dữ liệu sang các control tương ứng
            txtStudentID.Text = row.Cells["StudentId"].Value?.ToString() ?? "";
            txtUserID.Text = row.Cells["UserId"].Value?.ToString() ?? "";
            txtStudentCode.Text = row.Cells["StudentCode"].Value?.ToString() ?? "";
            txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? "";
            txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtPhoneNum.Text = row.Cells["PhoneNumber"].Value?.ToString() ?? "";

            // Giới tính
            string gender = row.Cells["Gender"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(gender))
                cboSex.Text = gender;
            else
                cboSex.SelectedIndex = -1;

            // Ngày sinh
            if (DateTime.TryParse(row.Cells["DateOfBirth"].Value?.ToString(), out DateTime dob))
                dtpBirth.Value = dob;
            else
                dtpBirth.Value = DateTime.Today;

            // Trạng thái (StatusName)
            string status = row.Cells["StatusName"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(status))
                cboStatus.Text = status;
            else
                cboStatus.SelectedIndex = -1;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                // 🧹 1️⃣ Xóa nội dung tìm kiếm
                txtSearch.Text = string.Empty;

                // 🧹 2️⃣ Làm trống các ô nhập liệu
                ClearForm();

                // 🧹 3️⃣ Nạp lại toàn bộ danh sách sinh viên
                LoadStudentData();

                // 🧹 4️⃣ Không chọn hàng nào trong DataGridView
                dgvQLSV.ClearSelection();

                // 🧹 5️⃣ Bật lại nút Thêm
                //btnAdd.Enabled = true;

                MessageBox.Show("Data has been refreshed and search filter cleared.",
                    "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // 🟢 Kiểm tra có chọn dòng nào chưa
                if (string.IsNullOrWhiteSpace(txtStudentID.Text))
                {
                    MessageBox.Show("Please select a student to edit.",
                "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🟢 Xác nhận
                var confirm = MessageBox.Show("Are you sure you want to update this student's information?",
                                              "Confirm edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No)
                    return;

                // 🟢 Lấy dữ liệu từ form
                var s = new Student_manager.Models.Student
                {
                    StudentId = int.Parse(txtStudentID.Text),
                    UserId = int.Parse(txtUserID.Text),
                    FullName = txtFullName.Text.Trim(),
                    StudentCode = txtStudentCode.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    PhoneNumber = txtPhoneNum.Text.Trim(),
                    Gender = cboSex.Text.Trim(),
                    DateOfBirth = dtpBirth.Value,
                    StatusId = GetStatusIdByName(cboStatus.Text.Trim())
                };

                // 🟢 Gọi BLL cập nhật
                var updated = _studentService.UpdateStudent(s);

                if (updated)
                {
                    MessageBox.Show("Student information updated successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadStudentData();
                    ClearForm();
                    dgvQLSV.ClearSelection();
                    btnAdd.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Unable to update student. Please check the data again.",
                        "Update error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // 🟢 Kiểm tra xem có chọn sinh viên nào chưa
                if (string.IsNullOrWhiteSpace(txtStudentID.Text))
                {
                    MessageBox.Show("Please select a student to delete.",
                        "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int studentId = int.Parse(txtStudentID.Text);

                // 🟢 Hỏi xác nhận trước khi xóa
                var confirm = MessageBox.Show("Are you sure you want to delete this student?",
                                              "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No)
                    return;

                // 🟢 Gọi BLL để xóa sinh viên
                bool deleted = _studentService.DeleteStudent(studentId);

                if (deleted)
                {
                    MessageBox.Show("Student deleted successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadStudentData();      // Tải lại danh sách
                    ClearForm();            // Làm trống các textbox/combobox
                    dgvQLSV.ClearSelection(); // Bỏ chọn các hàng
                    btnAdd.Enabled = true;  // Bật lại nút thêm
                }
                else
                {
                    MessageBox.Show("Unable to delete student. Please check the data again.",
                "Delete error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting student:\n" + ex.Message,
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvQLSV.Rows.Count == 0)
                {
                    MessageBox.Show("No data available to export to Excel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return;
                }

                // 🟢 Hộp thoại chọn nơi lưu file
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    FileName = "Danh_sach_sinh_vien.xlsx"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportToExcel(sfd.FileName);
                        MessageBox.Show("Student list successfully exported to Excel!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();

                // Nếu trống → hiển thị lại toàn bộ danh sách
                var results = _studentService.SearchStudents(keyword);

                dgvQLSV.DataSource = null;
                dgvQLSV.AutoGenerateColumns = false;
                dgvQLSV.DataSource = results.ToList();

                if (results.Any())
                {
                    dgvQLSV.ClearSelection();
                    btnAdd.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No matching students found.",
                "No results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching students:\n" + ex.Message,
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvQLSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
