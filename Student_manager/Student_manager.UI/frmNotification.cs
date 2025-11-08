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
using Student_manager.Models;

namespace Student_manager.UI
{
    public partial class frmNotification : Form
    {
        private readonly NotificationService _notificationService = new NotificationService();
        private int _currentUserId = 1; // giả sử Admin đang đăng nhập
        public frmNotification()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSubject.Clear();
            txtMessage.Clear();
            radStudents.Checked = false;
            radTeachers.Checked = false;
            radUsers.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có gì để xóa không
                if (string.IsNullOrWhiteSpace(txtSubject.Text) && string.IsNullOrWhiteSpace(txtMessage.Text))
                {
                    MessageBox.Show("There is no content to delete.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    return;
                }

                // Hỏi người dùng muốn xóa phần nào
                var choice = MessageBox.Show(
                    "What would you like to delete?\n\n" +
                    "Yes - Delete subject (txtSubject)\n" +
                    "No - Delete message (txtMessage)\n" +
                    "Cancel - Delete both",
                    "Delete confirmation",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                switch (choice)
                {
                    case DialogResult.Yes:
                        if (!string.IsNullOrWhiteSpace(txtSubject.Text))
                            txtSubject.Clear();
                        MessageBox.Show("Subject has been deleted.","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case DialogResult.No:
                        if (!string.IsNullOrWhiteSpace(txtMessage.Text))
                            txtMessage.Clear();
                        MessageBox.Show("Message content has been deleted.",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case DialogResult.Cancel:
                        txtSubject.Clear();
                        txtMessage.Clear();
                        MessageBox.Show("Both subject and message have been deleted.",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting content:\n" + ex.Message,
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





            /////////////////////// Đây là cách xóa thông báo khỏi DB (bao gồm cả nội dung và người nhận)
            //try
            //{
            //    // Nếu có nội dung nhập
            //    if (!string.IsNullOrWhiteSpace(txtSubject.Text) || !string.IsNullOrWhiteSpace(txtMessage.Text))
            //    {
            //        var choice = MessageBox.Show(
            //            "Bạn muốn xóa phần nào?\n\n" +
            //            "Yes - Xóa tiêu đề\n" +
            //            "No - Xóa nội dung\n" +
            //            "Cancel - Xóa cả hai",
            //            "Xác nhận xóa nội dung",
            //            MessageBoxButtons.YesNoCancel,
            //            MessageBoxIcon.Question);

            //        switch (choice)
            //        {
            //            case DialogResult.Yes:
            //                txtSubject.Clear();
            //                MessageBox.Show("Đã xóa tiêu đề.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            case DialogResult.No:
            //                txtMessage.Clear();
            //                MessageBox.Show("Đã xóa nội dung.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            case DialogResult.Cancel:
            //                txtSubject.Clear();
            //                txtMessage.Clear();
            //                MessageBox.Show("Đã xóa cả hai phần.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //        }
            //    }

            //    // ✅ Hỏi người dùng có muốn xóa khỏi cơ sở dữ liệu không
            //    if (selectedNotificationId > 0)
            //    {
            //        var confirm = MessageBox.Show(
            //            "Bạn có chắc muốn xóa thông báo này khỏi hệ thống?",
            //            "Xác nhận xóa khỏi DB",
            //            MessageBoxButtons.YesNo,
            //            MessageBoxIcon.Warning);

            //        if (confirm == DialogResult.Yes)
            //        {
            //            bool ok = _notificationService.DeleteNotification(selectedNotificationId);
            //            if (ok)
            //            {
            //                MessageBox.Show("Đã xóa thông báo khỏi hệ thống.",
            //                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                // Làm mới form
            //                txtSubject.Clear();
            //                txtMessage.Clear();
            //                selectedNotificationId = -1;
            //            }
            //            else
            //            {
            //                MessageBox.Show("Không thể xóa thông báo.",
            //                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không có thông báo nào được chọn để xóa.",
            //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi xóa thông báo:\n" + ex.Message,
            //        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void groupBoxRecipients_Enter(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string subject = txtSubject.Text.Trim();
                string message = txtMessage.Text.Trim();
                string roleTarget = "";

                if (rdoUser.Checked) roleTarget = "user";
                else if (rdoTeacher.Checked) roleTarget = "teacher";
                else if (rdoStudent.Checked) roleTarget = "student";
                else
                {
                    MessageBox.Show("Please select a recipient group.",
                        "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(subject))
                {
                    MessageBox.Show("Please enter a subject.",
                         "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(message))
                {
                    MessageBox.Show("Please enter the message content.",
                       "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var recipients = _notificationService.GetRecipientsByRole(roleTarget);
                if (recipients == null || recipients.Count == 0)
                {
                    MessageBox.Show("No recipients found for the selected group.",
                        "No recipients", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var notification = new Notification
                {
                    CreatorId = _currentUserId,
                    Title = subject,
                    Content = message,
                    CreatedDate = DateTime.Now
                };

                bool ok = _notificationService.SendNotification(notification, recipients);

                if (ok)
                {
                    MessageBox.Show($"Notification sent successfully to {recipients.Count} recipient(s).",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // reset form
                    txtSubject.Clear();
                    txtMessage.Clear();
                    rdoUser.Checked = rdoTeacher.Checked = rdoStudent.Checked = false;
                }
                else
                {
                    MessageBox.Show("Failed to send notification.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending notification:\n" + ex.Message,
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
