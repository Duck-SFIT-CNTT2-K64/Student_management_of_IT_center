USE QLSV_TrungTamTinHoc;
GO

-- Vô hiệu hóa tạm thời tất cả các ràng buộc FK
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all";
GO

-- XÓA DỮ LIỆU CŨ (Nếu chạy lại nhiều lần)
DELETE FROM Receipts;
DELETE FROM Tuitions;
DELETE FROM Scores;
DELETE FROM Attendances;
DELETE FROM Enrollments;
DELETE FROM ClassSchedules;
DELETE FROM Classes;
DELETE FROM NotificationRecipients;
DELETE FROM Notifications;
DELETE FROM Teachers;
DELETE FROM Students;
DELETE FROM StudentStatuses;
DELETE FROM ActionLogs;
DELETE FROM Users;
DELETE FROM RolePermissions;
DELETE FROM Permissions;
DELETE FROM Roles;
DELETE FROM Courses;
DELETE FROM Rooms;
DELETE FROM ScoreTypes;
GO

/* ================================================================================
 NHÓM 1: CÁC BẢNG DỮ LIỆU "DANH MỤC" (Bảng gốc)
================================================================================
*/

-- 1. Bảng Roles (Vai trò)
SET IDENTITY_INSERT Roles ON;
INSERT INTO Roles (RoleId, RoleName) VALUES
(1, N'Admin'),
(2, N'Giáo vụ'),
(3, N'Giảng viên'),
(4, N'Kế toán'),
(5, N'Sinh viên');
SET IDENTITY_INSERT Roles OFF;
GO

-- 2. Bảng Permissions (Quyền hạn)
SET IDENTITY_INSERT Permissions ON;
INSERT INTO Permissions (PermissionId, PermissionName, Description) VALUES
(1, N'ManageStudents', N'Quản lý thông tin sinh viên'),
(2, N'ManageTeachers', N'Quản lý thông tin giảng viên'),
(3, N'ManageClasses', N'Quản lý lớp học và khóa học'),
(4, N'EnterScores', N'Nhập/sửa điểm số'),
(5, N'ViewReports', N'Xem báo cáo thống kê'),
(6, N'ManageTuition', N'Quản lý học phí và biên lai'),
(7, N'ManageSystem', N'Quản lý người dùng và phân quyền');
SET IDENTITY_INSERT Permissions OFF;
GO

-- 3. Bảng RolePermissions (Phân quyền cho vai trò)
INSERT INTO RolePermissions (RoleId, PermissionId) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7),
(2, 1), (2, 2), (2, 3), (2, 5),
(3, 4), (3, 5),
(4, 6), (4, 5),
(5, 5);
GO

-- 4. Bảng StudentStatuses (Trạng thái sinh viên)
SET IDENTITY_INSERT StudentStatuses ON;
INSERT INTO StudentStatuses (StatusId, StatusName) VALUES
(1, N'Đang học'),
(2, N'Bảo lưu'),
(3, N'Đã tốt nghiệp'),
(4, N'Đã nghỉ học');
SET IDENTITY_INSERT StudentStatuses OFF;
GO

-- 5. Bảng Courses (Khóa học)
SET IDENTITY_INSERT Courses ON;
INSERT INTO Courses (CourseId, CourseCode, CourseName, Description, Duration, TuitionFee) VALUES
(1, N'CSHARP-WF', N'Lập trình C# WinForms', N'Khóa học nền tảng C# và WinForms.', N'3 tháng', 3500000),
(2, N'WEB-API', N'Xây dựng Web API với .NET', N'Phát triển RESTful API chuyên nghiệp.', N'2 tháng', 4000000),
(3, N'PYTHON-AI', N'Lập trình Python và AI', N'Nhập môn AI và Machine Learning.', N'4 tháng', 6000000),
(4, N'SQL-ADV', N'Quản trị CSDL SQL Server', N'Nâng cao kỹ năng T-SQL và quản trị.', N'2 tháng', 3000000),
(5, N'FE-REACT', N'Thiết kế Web Frontend React', N'Xây dựng giao diện web hiện đại.', N'3 tháng', 4500000);
SET IDENTITY_INSERT Courses OFF;
GO

-- 6. Bảng Rooms (Phòng học)
SET IDENTITY_INSERT Rooms ON;
INSERT INTO Rooms (RoomId, RoomName, Capacity) VALUES
(1, N'Phòng Lab 101', 30),
(2, N'Phòng Lab 102', 30),
(3, N'Phòng lý thuyết 201', 50),
(4, N'Phòng máy 202', 40);
SET IDENTITY_INSERT Rooms OFF;
GO

-- 7. Bảng ScoreTypes (Loại điểm)
SET IDENTITY_INSERT ScoreTypes ON;
INSERT INTO ScoreTypes (ScoreTypeId, ScoreTypeName, Weight) VALUES
(1, N'Chuyên cần', 0.1),
(2, N'Giữa kỳ', 0.3),
(3, N'Cuối kỳ', 0.6);
SET IDENTITY_INSERT ScoreTypes OFF;
GO

/* ================================================================================
 NHÓM 2: TÀI KHOẢN VÀ CÁC ĐỐI TƯỢNG NGƯỜI DÙNG
 (Mật khẩu mặc định cho tất cả là '123456'. 
 Hash: $2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92s.ag/iHjO8MYL/7o7i.)
================================================================================
*/
DECLARE @DefaultPasswordHash NVARCHAR(256) = N'$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92s.ag/iHjO8MYL/7o7i.';

-- 8. Bảng Users (Người dùng)
SET IDENTITY_INSERT Users ON;
INSERT INTO Users (UserId, RoleId, Username, PasswordHash, FullName, Email, PhoneNumber, Status) VALUES
(1, 1, N'admin', @DefaultPasswordHash, N'Bùi Hải Đức', N'duc.bh@itcenter.edu', '0911111111', N'Active'),
(2, 2, N'giao.vu', @DefaultPasswordHash, N'Trần Thị Giáo Vụ', N'giaovu@itcenter.edu', '0922222222', N'Active'),
(3, 4, N'ke.toan', @DefaultPasswordHash, N'Lê Văn Kế Toán', N'ketoan@itcenter.edu', '0933333333', N'Active'),
(4, 3, N'hung.dq', @DefaultPasswordHash, N'Đinh Quang Hưng', N'hung.dq@itcenter.edu', '0944444444', N'Active'),
(5, 3, N'huy.dh', @DefaultPasswordHash, N'Đặng Hoàng Huy', N'huy.dh@itcenter.edu', '0955555555', N'Active'),
(6, 5, N'tien.nm', @DefaultPasswordHash, N'Nguyễn Mạnh Tiến', N'tien.nm@itcenter.edu', '0966666666', N'Active'),
(7, 5, N'van.a', @DefaultPasswordHash, N'Nguyễn Văn A', N'a.nv@itcenter.edu', '0977777777', N'Active'),
(8, 5, N'thi.b', @DefaultPasswordHash, N'Trần Thị B', N'b.tt@itcenter.edu', '0988888888', N'Active'),
(9, 5, N'minh.c', @DefaultPasswordHash, N'Lê Minh C', N'c.lm@itcenter.edu', '0999999999', N'Active'),
(10, 5, N'hoang.d', @DefaultPasswordHash, N'Phạm Hoàng D', N'd.ph@itcenter.edu', '0912345678', N'Active');
SET IDENTITY_INSERT Users OFF;
GO

-- 9. Bảng ActionLogs (Nhật ký)
INSERT INTO ActionLogs (UserId, Action, Details, LogDate) VALUES
(1, N'Login', N'Admin đăng nhập thành công', '2025-10-25 08:00:00'),
(2, N'Create Student', N'Giáo vụ thêm sinh viên Nguyễn Văn A', '2025-10-25 09:15:00');
GO

-- 10. Bảng Students (Thông tin chi tiết của Sinh viên)
SET IDENTITY_INSERT Students ON;
INSERT INTO Students (StudentId, UserId, StatusId, StudentCode, FullName, DateOfBirth, Gender, Address, PhoneNumber, Email) VALUES
(1, 6, 1, N'SV001', N'Nguyễn Mạnh Tiến', '2004-10-20', N'Nam', N'123 Hà Nội', '0966666666', N'tien.nm@itcenter.edu'),
(2, 7, 1, N'SV002', N'Nguyễn Văn A', '2003-05-15', N'Nam', N'456 Hưng Yên', '0977777777', N'a.nv@itcenter.edu'),
(3, 8, 1, N'SV003', N'Trần Thị B', '2004-02-10', N'Nữ', N'789 Hải Dương', '0988888888', N'b.tt@itcenter.edu'),
(4, 9, 2, N'SV004', N'Lê Minh C', '2002-11-30', N'Nam', N'101 Nam Định', '0999999999', N'c.lm@itcenter.edu'),
(5, 10, 1, N'SV005', N'Phạm Hoàng D', '2004-07-07', N'Nữ', N'202 Thái Bình', '0912345678', N'd.ph@itcenter.edu');
SET IDENTITY_INSERT Students OFF;
GO

-- 11. Bảng Teachers (Thông tin chi tiết của Giảng viên)
SET IDENTITY_INSERT Teachers ON;
INSERT INTO Teachers (TeacherId, UserId, TeacherCode, FirstName, LastName, Specialization, PhoneNumber, Email) VALUES
(1, 4, N'GV001', N'Quang Hưng', N'Đinh', N'Lập trình .NET, Web API', '0944444444', N'hung.dq@itcenter.edu'),
(2, 5, N'GV002', N'Hoàng Huy', N'Đặng', N'Python, AI, SQL Server', '0955555555', N'huy.dh@itcenter.edu');
SET IDENTITY_INSERT Teachers OFF;
GO

/* ================================================================================
 NHÓM 3: NGHIỆP VỤ LỚP HỌC VÀ LỊCH HỌC
================================================================================
*/

-- 12. Bảng Classes (Lớp học)
SET IDENTITY_INSERT Classes ON;
INSERT INTO Classes (ClassId, CourseId, TeacherId, ClassCode, ClassName, MaxStudents) VALUES
(1, 1, 1, N'CSHARP.K25.T24', N'C# WinForms Tối 2-4 K25', 30),
(2, 2, 1, N'API.K10.T35', N'Web API .NET Tối 3-5 K10', 30),
(3, 3, 2, N'PYTHON.K15.T24', N'Python AI Tối 2-4 K15', 30),
(4, 4, 2, N'SQL.K20.T7', N'SQL Server Sáng T7 K20', 40),
(5, 5, 1, N'REACT.K5.CN', N'ReactJS Chiều CN K5', 30);
SET IDENTITY_INSERT Classes OFF;
GO

-- 13. Bảng ClassSchedules (Lịch học chi tiết)
INSERT INTO ClassSchedules (ClassId, RoomId, Weekday, StartTime, EndTime) VALUES
(1, 1, N'Tuesday', '18:00:00', '20:30:00'),
(1, 1, N'Thursday', '18:00:00', '20:30:00'),
(2, 2, N'Wednesday', '18:00:00', '20:30:00'),
(2, 2, N'Friday', '18:00:00', '20:30:00'),
(3, 1, N'Tuesday', '18:30:00', '21:00:00'),
(3, 1, N'Thursday', '18:30:00', '21:00:00'),
(4, 4, N'Saturday', '08:30:00', '11:30:00'),
(5, 2, N'Sunday', '14:00:00', '17:00:00');
GO

/* ================================================================================
 NHÓM 4: NGHIỆP VỤ CỐT LÕI (GHI DANH, ĐIỂM, HỌC PHÍ)
================================================================================
*/

-- 14. Bảng Enrollments (Ghi danh)
SET IDENTITY_INSERT Enrollments ON;
INSERT INTO Enrollments (EnrollmentId, StudentId, ClassId, EnrollmentDate, Status) VALUES
(1, 1, 1, '2025-09-01 09:00:00', N'Enrolled'),
(2, 1, 2, '2025-09-01 09:05:00', N'Enrolled'),
(3, 2, 1, '2025-09-02 10:00:00', N'Enrolled'),
(4, 2, 4, '2025-09-02 10:01:00', N'Enrolled'),
(5, 3, 3, '2025-09-03 14:00:00', N'Enrolled'),
(6, 3, 5, '2025-09-03 14:02:00', N'Enrolled'),
(7, 4, 4, '2025-09-04 11:00:00', N'Dropped'),
(8, 5, 3, '2025-09-05 15:00:00', N'Enrolled');
SET IDENTITY_INSERT Enrollments OFF;
GO

-- 15. Bảng Attendances (Điểm danh)
INSERT INTO Attendances (EnrollmentId, SessionDate, Status) VALUES
(1, '2025-09-10', N'Present'),
(1, '2025-09-12', N'Present'),
(1, '2025-09-17', N'Absent'),
(1, '2025-09-19', N'Present'),
(3, '2025-09-10', N'Present'),
(3, '2025-09-12', N'Late'),
(3, '2025-09-17', N'Present'),
(3, '2025-09-19', N'Present');
GO

-- 16. Bảng Scores (Điểm số)
INSERT INTO Scores (EnrollmentId, ScoreTypeId, ScoreValue) VALUES
(1, 1, 9.0),  
(1, 2, 8.5), 
(1, 3, 8.0), 
(3, 1, 10.0),
(3, 2, 7.0), 
(3, 3, 7.5), 
(5, 1, 8.0), 
(5, 2, 8.5), 
(5, 3, 9.0), 
(8, 1, 7.0), 
(8, 2, 6.0), 
(8, 3, 5.0); 
GO

-- 17. Bảng Tuitions (Học phí)
SET IDENTITY_INSERT Tuitions ON;
INSERT INTO Tuitions (TuitionId, EnrollmentId, TotalFee, AmountPaid, DueDate, Status) VALUES
(1, 1, 3500000, 3500000, '2025-09-15', N'Paid'),
(2, 2, 4000000, 2000000, '2025-09-15', N'Pending'),
(3, 3, 3500000, 3500000, '2025-09-15', N'Paid'),
(4, 4, 3000000, 0, '2025-09-15', N'Pending'),
(5, 5, 6000000, 6000000, '2025-09-15', N'Paid'),
(6, 6, 4500000, 4500000, '2025-09-15', N'Paid'),
(7, 7, 3000000, 0, '2025-09-15', N'Pending'),
(8, 8, 6000000, 3000000, '2025-09-15', N'Pending');
SET IDENTITY_INSERT Tuitions OFF;
GO

-- 18. Bảng Receipts (Biên lai thu tiền)
INSERT INTO Receipts (TuitionId, CashierId, ReceiptCode, Amount, PaymentDate, Note) VALUES
(1, 3, N'BL0001', 3500000, '2025-09-01 09:01:00', N'Thu học phí C# cho SV001'),
(2, 3, N'BL0002', 2000000, '2025-09-01 09:06:00', N'Thu học phí API (đợt 1) cho SV001'),
(3, 3, N'BL0003', 3500000, '2025-09-02 10:00:30', N'Thu học phí C# cho SV002'),
(5, 3, N'BL0004', 6000000, '2025-09-03 14:01:00', N'Thu học phí Python cho SV003'),
(6, 3, N'BL0005', 4500000, '2025-09-03 14:03:00', N'Thu học phí React cho SV003'),
(8, 3, N'BL0006', 3000000, '2025-09-05 15:01:00', N'Thu học phí Python (đợt 1) cho SV005');
GO

/* ================================================================================
 NHÓM 5: NGHIỆP VỤ THÔNG BÁO
================================================================================
*/

-- 19. Bảng Notifications (Tạo thông báo)
SET IDENTITY_INSERT Notifications ON;
INSERT INTO Notifications (NotificationId, CreatorId, Title, Content, CreatedDate) VALUES
(1, 1, N'Chào mừng thành viên mới!', N'Chào mừng các bạn đến với Trung tâm Tin học!', '2025-09-01 08:00:00'),
(2, 2, N'Lịch nghỉ lễ Quốc Khánh', N'Trung tâm thông báo nghỉ lễ 2/9. Lịch học bù sẽ được thông báo sau.', '2025-08-30 10:00:00');
SET IDENTITY_INSERT Notifications OFF;
GO

-- 20. Bảng NotificationRecipients (Gửi thông báo)
INSERT INTO NotificationRecipients (NotificationId, RecipientId, IsRead) VALUES
(1, 1, 1), (1, 2, 1), (1, 3, 1), (1, 4, 1), (1, 5, 1), (1, 6, 1), (1, 7, 0), (1, 8, 0), (1, 9, 0), (1, 10, 0),
(2, 4, 1), (2, 5, 1), (2, 6, 1), (2, 7, 1), (2, 8, 1), (2, 9, 0), (2, 10, 0);
GO

/* ================================================================================
 HOÀN TẤT: BẬT LẠI TẤT CẢ RÀNG BUỘC
================================================================================
*/
-- Bật lại tất cả các ràng buộc FK và KIỂM TRA chúng
EXEC sp_msforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all";
GO

--PRINT N'HOÀN TẤT CHÈN DỮ LIỆU ẢO!';
--GO

SELECT * FROM Roles;
SELECT * FROM Permissions;
SELECT * FROM RolePermissions;
SELECT * FROM StudentStatuses;
SELECT * FROM Courses;
SELECT * FROM Rooms;
SELECT * FROM ScoreTypes;
SELECT * FROM Users;
SELECT * FROM ActionLogs;
SELECT * FROM Students;
SELECT * FROM Teachers;
SELECT * FROM Notifications;
SELECT * FROM NotificationRecipients;
SELECT * FROM Classes;
SELECT * FROM ClassSchedules;
SELECT * FROM Enrollments;
SELECT * FROM Attendances;
SELECT * FROM Scores;
SELECT * FROM Tuitions;
SELECT * FROM Receipts;
GO

USE QLSV_TrungTamTinHoc;
GO

-- Mật khẩu hash mặc định (123456)
DECLARE @DefaultPasswordHash NVARCHAR(256) = N'$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92s.ag/iHjO8MYL/7o7i.';

-- 1. Thêm User mới cho Giảng viên
-- (Giả sử UserId tiếp theo là 11)
SET IDENTITY_INSERT Users ON;
INSERT INTO Users (UserId, RoleId, Username, PasswordHash, FullName, Email, PhoneNumber, Status) VALUES
(11, 3, N'huong.nt', @DefaultPasswordHash, N'Nguyễn Thị Hường', N'huong.nt@itcenter.edu', '0915556666', N'Active');
SET IDENTITY_INSERT Users OFF;

-- 2. Thêm thông tin Giảng viên
-- (Giả sử TeacherId tiếp theo là 3)
SET IDENTITY_INSERT Teachers ON;
INSERT INTO Teachers (TeacherId, UserId, TeacherCode, FirstName, LastName, Specialization, PhoneNumber, Email) VALUES
(3, 11, N'GV003', N'Thị Hường', N'Nguyễn', N'Thiết kế Web, ReactJS', '0915556666', N'huong.nt@itcenter.edu');
SET IDENTITY_INSERT Teachers OFF;

-- 3. Thêm User mới cho Sinh viên
-- (Giả sử UserId tiếp theo là 12)
SET IDENTITY_INSERT Users ON;
INSERT INTO Users (UserId, RoleId, Username, PasswordHash, FullName, Email, PhoneNumber, Status) VALUES
(12, 5, N'em.nv', @DefaultPasswordHash, N'Nguyễn Văn Em', N'em.nv@itcenter.edu', '0917778888', N'Active');
SET IDENTITY_INSERT Users OFF;

-- 4. Thêm thông tin Sinh viên
-- (Giả sử StudentId tiếp theo là 6)
SET IDENTITY_INSERT Students ON;
INSERT INTO Students (StudentId, UserId, StatusId, StudentCode, FullName, DateOfBirth, Gender, Address, PhoneNumber, Email) VALUES
(6, 12, 1, N'SV006', N'Nguyễn Văn Em', '2005-01-01', N'Nam', N'555 Bắc Ninh', '0917778888', N'em.nv@itcenter.edu');
SET IDENTITY_INSERT Students OFF;

-- 5. Thêm Lớp học mới (do GV mới dạy)
-- (Giả sử ClassId tiếp theo là 6, dạy khóa React CourseId=5, GV mới TeacherId=3)
SET IDENTITY_INSERT Classes ON;
INSERT INTO Classes (ClassId, CourseId, TeacherId, ClassCode, ClassName, MaxStudents) VALUES
(6, 5, 3, N'REACT.K6.T35', N'ReactJS Tối 3-5 K6', 30);
SET IDENTITY_INSERT Classes OFF;

-- 6. Thêm Lịch học cho lớp mới
INSERT INTO ClassSchedules (ClassId, RoomId, Weekday, StartTime, EndTime) VALUES
(6, 3, N'Wednesday', '19:00:00', '21:30:00'),
(6, 3, N'Friday', '19:00:00', '21:30:00');

-- 7. Thêm Ghi danh mới (SV mới vào Lớp mới)
-- (Giả sử EnrollmentId tiếp theo là 9)
SET IDENTITY_INSERT Enrollments ON;
INSERT INTO Enrollments (EnrollmentId, StudentId, ClassId, EnrollmentDate, Status) VALUES
(9, 6, 6, '2025-10-28 10:00:00', N'Enrolled');
SET IDENTITY_INSERT Enrollments OFF;

-- 8. Thêm Điểm cho ghi danh mới
INSERT INTO Scores (EnrollmentId, ScoreTypeId, ScoreValue) VALUES
(9, 1, 10.0), -- Chuyên cần
(9, 2, 8.0);  -- Giữa kỳ
-- (Chưa có điểm cuối kỳ)

-- 9. Thêm Học phí cho ghi danh mới
-- (Giả sử TuitionId tiếp theo là 9, học phí React là 4500000)
SET IDENTITY_INSERT Tuitions ON;
INSERT INTO Tuitions (TuitionId, EnrollmentId, TotalFee, AmountPaid, DueDate, Status) VALUES
(9, 9, 4500000, 4500000, '2025-11-10', N'Paid');
SET IDENTITY_INSERT Tuitions OFF;

-- 10. Thêm Biên lai
INSERT INTO Receipts (TuitionId, CashierId, ReceiptCode, Amount, PaymentDate, Note) VALUES
(9, 3, N'BL0007', 4500000, '2025-10-28 10:01:00', N'Thu học phí React cho SV006');

PRINT N'Đã generate thêm 1 GV, 1 SV, 1 Lớp, 1 Ghi danh và các dữ liệu liên quan.';
GO



SELECT * FROM Users