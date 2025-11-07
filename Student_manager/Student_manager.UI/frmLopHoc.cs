using Student_manager.BLL;
using Student_manager.DAL;
using Student_manager.Models;
using Student_manager.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmLopHoc : Form
    {
        // ----------------------------------------------------
        // I. VARIABLE DECLARATION & DEPENDENCIES
        // ----------------------------------------------------
        private readonly ClassesService _classesService = new ClassesService();
        private readonly ClassSchedulesService _schedulesService = new ClassSchedulesService();
        private readonly RoomsService _roomsService = new RoomsService();

        private readonly LecturesService _lecturesService;
        private readonly CourseService _coursesService;

        private Class _currentClass = null;
        private ClassSchedule _currentSchedule = null; // Used to track the Schedule being edited

        public frmLopHoc()
        {
            InitializeComponent();
            // Initialize other Services (Assuming LecturesDAO and CourseDAO exist)
            _lecturesService = new LecturesService(new LecturesDAO());
            _coursesService = new CourseService(new CourseDAO());
        }

        // ----------------------------------------------------
        // II. SUPPORT METHODS & LOAD DATA
        // ----------------------------------------------------

        private void frmLopHoc_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAllData();
                SetEditingState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllData()
        {
            LoadClassesIntoGrid();

            // Set auxiliary grids to null when loading the form
            dgvSchedules.DataSource = null;
            dgvRooms.DataSource = null;

            LoadTeachersIntoComboBox();
            LoadCoursesIntoComboBox();
        }

        private void LoadClassesIntoGrid()
        {
            var list = _classesService.GetAllClasses();
            dgvClasses.DataSource = list;
        }

        // Load Schedules when a ClassId is present
        private void LoadSchedulesIntoGrid(int? classId = null)
        {
            if (classId.HasValue)
            {
                var list = _schedulesService.GetSchedulesByClass(classId.Value);
                dgvSchedules.DataSource = list;
            }
            else
            {
                dgvSchedules.DataSource = null;
            }
        }

        // Load Rooms (This method is kept but not used when loading the form)
        private void LoadRoomsIntoGrid()
        {
            var list = _roomsService.GetAllRooms();
            dgvRooms.DataSource = list;
        }

        private void LoadTeachersIntoComboBox()
        {
            var list = _lecturesService.GetAllLecturers();
            cboTeacherId.DataSource = list;
            cboTeacherId.DisplayMember = "FirstName";
            cboTeacherId.ValueMember = "TeacherId";
            cboTeacherId.SelectedIndex = -1; // Select nothing
        }

        private void LoadCoursesIntoComboBox()
        {
            var list = _coursesService.GetAllCourses();
            cboCourseId.DataSource = list;
            cboCourseId.DisplayMember = "CourseName";
            cboCourseId.ValueMember = "CourseId";
            cboCourseId.SelectedIndex = -1; // Select nothing
        }

        private void ClearInputFields()
        {
            // --- 1. Class ---
            txtClassCode.Text = string.Empty;
            txtClassName.Text = string.Empty;
            txtMax.Text = string.Empty;

            if (cboTeacherId.DataSource != null) cboTeacherId.SelectedIndex = -1;
            if (cboCourseId.DataSource != null) cboCourseId.SelectedIndex = -1;

            // --- 2. Class Routine ---
            txtScheduleId.Text = string.Empty;
            txtClassId.Text = string.Empty;
            txtWeekday.Text = string.Empty;
            txtStartTime.Text = string.Empty;
            txtEndTime.Text = string.Empty;

            // --- 3. Class Room ---
            txtRoomId.Text = string.Empty;
            txtRoomName.Text = string.Empty;
            txtCapacity.Text = string.Empty;

            dgvSchedules.DataSource = null;
            dgvRooms.DataSource = null;
        }

        // ----------------------------------------------------
        // III. STATE CONTROL LOGIC (SetEditingState)
        // ----------------------------------------------------

        private void SetEditingState(bool enabled)
        {
            // --- INPUT FIELDS ---

            // 🔹 Class
            txtClassCode.Enabled = enabled;
            txtClassName.Enabled = enabled;
            txtMax.Enabled = enabled;
            cboTeacherId.Enabled = enabled;
            cboCourseId.Enabled = enabled;

            // 🔹 Schedule - Use ReadOnly for ID
            // ID is always Enabled to display value, but ReadOnly when not editing
            txtScheduleId.Enabled = true;
            txtScheduleId.ReadOnly = !enabled;

            txtClassId.Enabled = true; // Always Enabled to display
            txtClassId.ReadOnly = true; // Always ReadOnly because value is taken from DGV Classes

            txtWeekday.Enabled = enabled;
            txtStartTime.Enabled = enabled;
            txtEndTime.Enabled = enabled;

            // 🔹 Class Room - Use ReadOnly for ID
            txtRoomId.Enabled = true;
            txtRoomId.ReadOnly = !enabled;

            txtRoomName.Enabled = enabled;
            txtCapacity.Enabled = enabled;

            // 🔹 Search Box
            txtSearch.Enabled = true;
            btnSearch.Enabled = true;

            // --- BUTTONS ---

            if (enabled) // Editing State (Add/Modify)
            {
                btnSave.Enabled = true;
                btnCancel.Enabled = true;

                // Disable other operation buttons
                btnAdd.Enabled = false;
                btnModify.Enabled = false;
                btnDelete.Enabled = false;
            }
            else // Viewing State (Load, Save, Cancel)
            {
                btnSave.Enabled = false;
                btnCancel.Enabled = false;

                // Enable Add and Disable Modify/Delete (will be re-enabled in CellClick)
                btnAdd.Enabled = true;
                btnModify.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        // ----------------------------------------------------
        // IV. DATA GATHERING LOGIC (CREATE FROM INPUT)
        // ----------------------------------------------------

        // Method to get Class data from UI
        private Class CreateClassFromInput()
        {
            var c = _currentClass ?? new Class();

            c.ClassCode = txtClassCode.Text.Trim();
            c.ClassName = txtClassName.Text.Trim();

            // Get TeacherId
            c.TeacherId = (cboTeacherId.SelectedValue != null && cboTeacherId.SelectedValue != DBNull.Value)
                                     ? (int?)cboTeacherId.SelectedValue
                                     : null;

            // Get CourseId (Required)
            if (cboCourseId.SelectedValue == null || cboCourseId.SelectedValue == DBNull.Value)
                throw new Exception("Please select a Course Code.");
            c.CourseId = (int)cboCourseId.SelectedValue;

            // Get MaxStudents
            if (int.TryParse(txtMax.Text.Trim(), out int maxStudents))
            {
                c.MaxStudents = maxStudents;
            }
            else
            {
                c.MaxStudents = null;
            }
            return c;
        }

        // Method to get Room data from UI
        private Room CreateRoomFromInput()
        {
            var r = new Room();

            // RoomId only exists when modifying
            if (int.TryParse(txtRoomId.Text.Trim(), out int roomId) && roomId > 0)
            {
                r.RoomId = roomId;
            }

            if (string.IsNullOrWhiteSpace(txtRoomName.Text))
                throw new Exception("Room name cannot be empty.");

            r.RoomName = txtRoomName.Text.Trim();

            if (int.TryParse(txtCapacity.Text.Trim(), out int capacity) && capacity > 0)
            {
                r.Capacity = capacity;
            }
            else
            {
                throw new Exception("Capacity must be a positive number.");
            }
            return r;
        }

        // Method to get Schedule data from UI
        private ClassSchedule CreateScheduleFromInput(int classId, int? roomId)
        {
            var s = _currentSchedule ?? new ClassSchedule();

            if (int.TryParse(txtScheduleId.Text.Trim(), out int scheduleId) && scheduleId > 0)
            {
                s.ScheduleId = scheduleId;
            }

            s.ClassId = classId;
            s.RoomId = roomId;

            if (string.IsNullOrWhiteSpace(txtWeekday.Text))
                throw new Exception("Weekday cannot be empty.");

            s.Weekday = txtWeekday.Text.Trim();

            if (!TimeSpan.TryParse(txtStartTime.Text, out TimeSpan startTime))
                throw new Exception("Invalid Start Time format.");

            if (!TimeSpan.TryParse(txtEndTime.Text, out TimeSpan endTime))
                throw new Exception("Invalid End Time format.");

            s.StartTime = startTime;
            s.EndTime = endTime;

            if (s.EndTime <= s.StartTime)
                throw new Exception("End time must be after start time.");

            return s;
        }


        // ----------------------------------------------------
        // V. EVENT HANDLERS LOGIC
        // ----------------------------------------------------

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = (Class)dgvClasses.Rows[e.RowIndex].DataBoundItem;

            _currentClass = row;

            if (btnSave.Enabled == false) // If in View mode
            {
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
            }

            // Assign data to TextBoxes and ComboBoxes
            // --- RESTORE MISSING CODE HERE ---
            txtClassCode.Text = row.ClassCode?.ToString();
            txtClassName.Text = row.ClassName?.ToString();
            txtMax.Text = row.MaxStudents?.ToString();

            // Assign comboBox
            cboTeacherId.SelectedValue = row.TeacherId;
            cboCourseId.SelectedValue = row.CourseId;
            // ------------------------------------

            // Load schedules by ClassId
            var schedules = _schedulesService.GetSchedulesByClass(row.ClassId);
            dgvSchedules.DataSource = schedules;

            // Initialize Room Inputs to empty
            txtRoomId.Text = string.Empty;
            txtRoomName.Text = string.Empty;
            txtCapacity.Text = string.Empty;
            dgvRooms.DataSource = null; // Always set to null initially

            // ------------------------------------------------
            // ⚠️ ROOM ASSIGNMENT LOGIC: Based on the first schedule
            // ------------------------------------------------
            if (schedules != null && schedules.Any())
            {
                var firstSchedule = schedules.First();

                // Ensure txtClassId is assigned even if Schedule is not clicked
                txtClassId.Text = firstSchedule.ClassId.ToString();

                if (firstSchedule.RoomId.HasValue)
                {
                    var room = _roomsService.GetAllRooms()
                                              .FirstOrDefault(r => r.RoomId == firstSchedule.RoomId.Value);

                    if (room != null)
                    {
                        // Assign directly to TextBox when Room is found
                        txtRoomId.Text = room.RoomId.ToString();
                        txtRoomName.Text = room.RoomName;
                        txtCapacity.Text = room.Capacity.ToString();

                        // Display this Room in the DGV Rooms grid (or a list of 1 room)
                        dgvRooms.DataSource = new List<Room> { room };
                    }
                }
            }
        }

        private void dgvSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedSchedule = (ClassSchedule)dgvSchedules.Rows[e.RowIndex].DataBoundItem;
            _currentSchedule = selectedSchedule;

            // Fill schedule information
            txtScheduleId.Text = selectedSchedule.ScheduleId.ToString();
            txtClassId.Text = selectedSchedule.ClassId.ToString();
            txtWeekday.Text = selectedSchedule.Weekday;
            txtStartTime.Text = selectedSchedule.StartTime.ToString(@"hh\:mm");
            txtEndTime.Text = selectedSchedule.EndTime.ToString(@"hh\:mm");

            // If RoomId exists, load the corresponding room (Assuming dgvRooms only displays the selected room)
            if (selectedSchedule.RoomId.HasValue)
            {
                var room = _roomsService.GetAllRooms().FirstOrDefault(r => r.RoomId == selectedSchedule.RoomId.Value);
                if (room != null)
                {
                    txtRoomId.Text = room.RoomId.ToString();
                    txtRoomName.Text = room.RoomName;
                    txtCapacity.Text = room.Capacity.ToString();

                    // Only display this room in the DGV Rooms grid (or a list of 1 room)
                    dgvRooms.DataSource = new List<Room> { room };
                }
                else
                {
                    txtRoomId.Text = string.Empty;
                    dgvRooms.DataSource = null;
                }
            }
            else
            {
                txtRoomId.Text = string.Empty;
                dgvRooms.DataSource = null;
            }
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedRoom = (Room)dgvRooms.Rows[e.RowIndex].DataBoundItem;

            txtRoomId.Text = selectedRoom.RoomId.ToString();
            txtRoomName.Text = selectedRoom.RoomName;
            txtCapacity.Text = selectedRoom.Capacity.ToString();

            // Update _currentSchedule.RoomId if currently in Schedule editing mode?
            // (Depends on your business logic)
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a class name to search!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var classes = _classesService.GetAllClasses() ?? new List<Class>();
            var foundClass = classes
                 .FirstOrDefault(c => !string.IsNullOrEmpty(c.ClassName)
                    && c.ClassName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);

            if (foundClass == null)
            {
                MessageBox.Show("No class found with a matching name!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Automatically select and trigger CellClick for the found row
            foreach (DataGridViewRow row in dgvClasses.Rows)
            {
                var current = row.DataBoundItem as Class;
                if (current != null && current.ClassId == foundClass.ClassId)
                {
                    row.Selected = true;
                    dgvClasses.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvClasses.CurrentCell = row.Cells[0];
                    dgvClasses_CellClick(dgvClasses, new DataGridViewCellEventArgs(0, row.Index));
                    break;
                }
            }
            txtSearch.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            _currentClass = new Class();
            _currentSchedule = new ClassSchedule(); // Initialize empty Schedule for adding new
            SetEditingState(true);
            txtClassCode.Focus();
            dgvClasses.Enabled = false; // Disable main grid while adding new
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvClasses.CurrentRow == null || dgvClasses.CurrentRow.Index < 0 || _currentClass == null)
            {
                MessageBox.Show("Please select a Class from the list to modify.", "Notification",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the first selected Schedule (if any) to set as _currentSchedule
            if (dgvSchedules.CurrentRow != null && dgvSchedules.CurrentRow.Index >= 0)
            {
                _currentSchedule = (ClassSchedule)dgvSchedules.CurrentRow.DataBoundItem;
            }
            else
            {
                _currentSchedule = new ClassSchedule();
            }

            SetEditingState(true);
            dgvClasses.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Declare and determine state
            bool isAddingNewClass = (_currentClass == null || _currentClass.ClassId <= 0);
            int finalClassId = 0;
            int? finalRoomId = null;

            try
            {
                // ------------------------- 1. SAVE ROOM DATA (ROOM) -------------------------
                // *Assume RoomsService.AddRoom/UpdateRoom returns the new ID or true*

                Room roomToSave = CreateRoomFromInput();

                if (roomToSave.RoomId > 0)
                {
                    if (!_roomsService.UpdateRoom(roomToSave)) throw new Exception("Failed to update Room information.");
                    finalRoomId = roomToSave.RoomId;
                }
                else
                {
                    int newRoomId = _roomsService.AddRoom(roomToSave); // ⚠️ Requires RoomsService to return the new int ID
                    if (newRoomId > 0)
                    {
                        finalRoomId = newRoomId;
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new Room, continuing to save Class.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // ------------------------- 2. SAVE CLASS DATA (CLASS) -------------------------

                Class classToSave = CreateClassFromInput();
                bool classSuccess;

                if (isAddingNewClass)
                {
                    finalClassId = _classesService.AddClass(classToSave); // ⚠️ Requires ClassesService to return the new int ID
                    classSuccess = (finalClassId > 0);
                }
                else
                {
                    classToSave.ClassId = _currentClass.ClassId;
                    classSuccess = _classesService.UpdateClass(classToSave);
                    finalClassId = classToSave.ClassId;
                }

                if (!classSuccess) throw new Exception("Failed to save Class information.");

                // ------------------------- 3. SAVE SCHEDULE DATA (SCHEDULE) -------------------------

                ClassSchedule scheduleToSave = CreateScheduleFromInput(finalClassId, finalRoomId);
                bool scheduleSuccess;

                if (scheduleToSave.ScheduleId > 0)
                {
                    scheduleSuccess = _schedulesService.UpdateSchedule(scheduleToSave);
                }
                else
                {
                    scheduleSuccess = _schedulesService.AddSchedule(scheduleToSave);
                }

                if (!scheduleSuccess) throw new Exception("Failed to save Schedule.");

                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during data saving: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ------------------------- 4. UPDATE INTERFACE -------------------------
            LoadClassesIntoGrid();
            ClearInputFields();
            SetEditingState(false);

            _currentClass = null;
            _currentSchedule = null;
            dgvClasses.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetEditingState(false);

            ClearInputFields();

            _currentClass = null;
            _currentSchedule = null;

            dgvClasses.Enabled = true;

            LoadClassesIntoGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentClass == null || _currentClass.ClassId <= 0)
            {
                MessageBox.Show("Please select a valid Class from the list to delete.", "Notification",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show($"Are you sure you want to delete class '{_currentClass.ClassName}'? This action cannot be undone.",
                                              "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // Logic to delete Class, Schedule, and Room needs to be handled here
                    // Depending on foreign key constraints, deleting Class might automatically delete Schedule
                    bool success = _classesService.DeleteClass(_currentClass.ClassId);

                    if (success)
                    {
                        MessageBox.Show("Class deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadClassesIntoGrid();
                        ClearInputFields();
                        SetEditingState(false);
                        _currentClass = null;
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete class. There might be data constraints.", "Deletion Error",
MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during deletion: " + ex.Message, "Error",
MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to exit the Class Management Form?",
                                              "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}