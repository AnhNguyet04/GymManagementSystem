using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using PresentationLayer.Helpers;

namespace PresentationLayer
{
    public partial class Lophoc : Form
    {
        private enum ViewMode { Classes, Students}
        private ViewMode currentMode = ViewMode.Classes;
        private bool isSelectClass = false;
        private int SelectedClassId = -1;
        private int selectedTrainerId = 0;
        public Lophoc()
        {
            InitializeComponent();
            panel7.Hide();
           
        }
        private void Lophoc_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            btnThemlop.Visible = false;
            btnSualop.Visible = false;
            btnXoalop.Visible = false;
            btnThemhocvien.Visible = false;
            btnHuy.Visible = false;

            string role = UserSession.Role;
            if (role =="Admin")
            {
                btnLopcuaban.Visible = false;
            }    
            else if (role =="Lễ tân")
            {
                btnLopcuaban.Visible=false;
                btnCapNhatLop.Visible=false;
            }
            else if (role =="Huấn luyện viên")
            {
                btnCapNhatLop.Visible = false;
                btnHuy.Visible = false;
                btnThemhocvien.Visible = false;
            }    
        }
        private void btnDanhsachlop_Click(object sender, EventArgs e)
        {
            panel4.Visible=false;
            ClassesBL classBL = new ClassesBL();
            var classes = classBL.GetAllClasses();

            dgvClass.DataSource = classes;
            DataGridViewStyleHelper.FormatClassDGV(dgvClass);
           
            dgvClass.Columns["SelectColumn"].Visible = true;
            isSelectClass = false;

            btnThemlop.Visible = false;
            btnSualop.Visible = false;
            btnXoalop.Visible = false;
            btnHuy.Visible = false;
            if (UserSession.Role == "Admin" || UserSession.Role == "Lễ tân")
            { 
                btnThemhocvien.Visible = true; 
            }
        }
        //Xem danh sách học viên
        private void btnDanhsachhocvien_Click(object sender, EventArgs e)
        {
            panel4.Visible=false;
            LoadClasses();
            dgvClass.Columns["SelectColumn"].Visible = false;
            isSelectClass = true;

            btnThemlop.Visible = false;
            btnSualop.Visible = false;
            btnXoalop.Visible = false;
            btnThemhocvien.Visible = false;
            if (UserSession.Role == "Admin" || UserSession.Role == "Lễ tân")
            {
                btnHuy.Visible = true;
            }
        }
        private void LoadClasses()
        {
            currentMode = ViewMode.Classes;
            ClassesBL classBL = new ClassesBL();
            var classes = classBL.GetAllClasses();

            if (UserSession.Role == "Huấn luyện viên")
            {
                classes = classes.FindAll(c => c.TrainerID == UserSession.UserId);
            }
            dgvClass.DataSource = classes;
            DataGridViewStyleHelper.FormatClassDGV(dgvClass);
           
        }

        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentMode == ViewMode.Classes && isSelectClass && e.RowIndex >= 0)
            {
                SelectedClassId = Convert.ToInt32(dgvClass.Rows[e.RowIndex].Cells["ClassID"].Value);
                LoadStudents(SelectedClassId);
            }
        }
        private void LoadStudents(int classId)
        {
            currentMode = ViewMode.Students;
            StudentsBL studentBL = new StudentsBL();
            var students = studentBL.GetStudentsByClassId(classId);

            dgvClass.DataSource = students;
            dgvClass.Columns["SelectColumn"].Visible = true;

            DataGridViewStyleHelper.FormatStudentDGV(dgvClass);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Students_ClassBL studentClassBL = new Students_ClassBL();
            bool hasSelection = false;
            try
            {
                foreach (DataGridViewRow row in dgvClass.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["SelectColumn"].Value);
                    if (isChecked)
                    {
                        hasSelection = true;
                        int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
                        int classId = SelectedClassId;

                        string studentName = row.Cells["FullName"].Value.ToString();
                        DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn hủy học viên {studentName} khỏi lớp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            studentClassBL.HuyDangKy(studentId, classId);
                        }
                    }
                }
                if (hasSelection)
                {
                    MessageBox.Show("Hủy học viên khỏi lớp thành công!");
                    LoadStudents(SelectedClassId);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một học viên cần hủy!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTrainer()
        {
            TrainerBL trainerBL = new TrainerBL();
            var trainers = trainerBL.GetAllTrainers();

            var displayList = trainers.Select(t => new
            {
                ID = t.TrainerID,
                HoTen = t.FullName,
                SĐT = t.Phone,
                Email = t.Email,
                LopDangday = string.Join(", ", t.Classes)
            }).ToList();
            dgvClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClass.DataSource = displayList;
            dgvClass.Columns["ID"].HeaderText = "ID";
            dgvClass.Columns["HoTen"].HeaderText = "Họ tên";
            dgvClass.Columns["LopDangday"].HeaderText = "Lớp đang dạy";
        }
        private void btnHLV_Click(object sender, EventArgs e)
        {
            LoadTrainer();
            dgvClass.Columns["SelectColumn"].Visible = false;
            panel4.Visible = false;

            btnThemlop.Visible = false;
            btnSualop.Visible = false;
            btnXoalop.Visible = false;
            btnHuy.Visible = false;
            btnThemhocvien.Visible = false;
        }
        
        private void btnLopcuaban_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;

            btnThemlop.Visible = false;
            btnSualop.Visible = false;
            btnXoalop.Visible = false;
            btnHuy.Visible = false;
            btnThemhocvien.Visible = false;

            string role = UserSession.Role;
            int userID = UserSession.UserId;
            ClassesBL classBL = new ClassesBL();
            List<Classes> classes = new List<Classes>();
              
            if (role == "Huấn luyện viên")
            {
                classes = classBL.GetClassesByTrainer(userID);
            }    
            if (classes.Count == 0)
            {
                MessageBox.Show("Bạn chưa có lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
            else
            {
                dgvClass.DataSource = classes;
                DataGridViewStyleHelper.FormatClassDGV(dgvClass);
            }    
        }

        private void btnThemhocvien_Click(object sender, EventArgs e)
        {
            List<int> selectedClassId = new List<int>();
            foreach (DataGridViewRow row in dgvClass.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["SelectColumn"].Value);
                if (isChecked)
                {
                    int classId = Convert.ToInt32(row.Cells["ClassID"].Value);
                    selectedClassId.Add(classId);
                }
            }
            if (selectedClassId.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một lớp để thêm học viên.");
                return;
            }
            Form student = new ChonHocVien(selectedClassId);
            if (student.ShowDialog() == DialogResult.OK)
            {
                LoadClasses();
                MessageBox.Show("Danh sách học viên đã được cập nhật.");
            }
        }
        
        private void Clear()
        {
            txtTenLop.Clear();
            txtSchedule.Clear();
            txtGia.Clear();
            txtHLV.Clear();
            txtSoLuongHv.Clear();
            txtMota.Clear();
        }
        private void btnThemlop_Click(object sender, EventArgs e)
        {
            string schedule = txtSchedule.Text.Trim();
            if (string.IsNullOrWhiteSpace(schedule))
            {
                MessageBox.Show("Vui lòng nhập lịch học");
                return;
            }    
            if (string.IsNullOrWhiteSpace(txtHLV.Text))
            {
                MessageBox.Show("Vui lòng phân công huấn luyện viên");
                return;
            }
            if (!NgayBatDauVaKetThuc(dtStartDate.Value, dtEndDate.Value))
                return;
            int trainerId = 0;
            foreach (DataGridViewRow row in dgvHLV.Rows)
            {
                if (row.Cells["FullName"].Value.ToString() == txtHLV.Text)
                {
                    trainerId = Convert.ToInt32(row.Cells["TrainerID"].Value);
                    break;
                }
            }
            if (trainerId == 0)
            {
                MessageBox.Show("Không tìm thấy HLV phù hợp");
                return;
            }
            Classes newClass = new Classes()
            {
                ClassName = txtTenLop.Text.Trim(),
                Category = Convert.ToInt32(cbLoaihinh.SelectedValue),
                TrainerID = trainerId,
                Schedule = schedule,
                MaxStudent = int.TryParse(txtSoLuongHv.Text, out int max) ? max : 20,
                Price = decimal.TryParse(txtGia.Text, out decimal price) ? price : 0,
                StartDate = dtStartDate.Value,
                EndDate = dtEndDate.Value,
                Description = txtMota.Text.Trim()
            };
            try
            {
                ClassesBL classesBL = new ClassesBL();
                int result = classesBL.AddClass(newClass);
                if (result > 0)
                {
                    MessageBox.Show("Thêm lớp học thành công!");
                    panel7.Hide();
                    dgvCapNhat.DataSource = classesBL.GetAllClasses();
                    DataGridViewStyleHelper.FormatClassDGV(dgvCapNhat);

                    Clear();
                }
                else
                {
                    MessageBox.Show("Không thể thêm lớp học.");
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+ ex.Message);
            }   
        }
        private void btnSualop_Click(object sender, EventArgs e)
        {
            
            if (SelectedClassId == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp học cần chỉnh sửa.");
                return;
            }
            string schedule = txtSchedule.Text.Trim();
            if (string.IsNullOrWhiteSpace(schedule))
            {
                MessageBox.Show("Vui lòng nhập lịch học.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtHLV.Text))
            {
                MessageBox.Show("Vui lòng phân công huấn luyện viên.");
                return;
            }

            //tìm trainerId theo tên
            int trainerId = 0;
            foreach (DataGridViewRow row in dgvCapNhat.Rows)
            {
                if (Convert.ToInt32(row.Cells["ClassID"].Value) == SelectedClassId)
                {
                    trainerId = Convert.ToInt32(row.Cells["TrainerID"].Value);
                    break;
                }
            }

            if (trainerId == 0)
            {
                // Nếu không tìm được trong lưới (trường hợp người dùng đã sửa lại HLV bằng tay)
                TrainerBL trainerBL = new TrainerBL();
                var trainer = trainerBL.GetTrainerByName(txtHLV.Text.Trim());
                if (trainer != null)
                    trainerId = trainer.TrainerID;
                else
                {
                    MessageBox.Show("Không tìm thấy huấn luyện viên tương ứng.");
                    return;
                }
            }

            //Lấy ClassID từ dòng được chọn
            DataGridViewRow selectedRow = dgvCapNhat.SelectedRows[0];
            if (!int.TryParse(selectedRow.Cells["ClassID"].Value.ToString(), out int classId))
            {
                MessageBox.Show("Không thể xác định lớp học cần cập nhật.");
                return;
            }
            
            Classes updatedClass = new Classes()
            {
                ClassID = classId,
                ClassName = txtTenLop.Text.Trim(),
                Category = Convert.ToInt32(cbLoaihinh.SelectedValue),
                TrainerID = selectedTrainerId,
                Schedule = schedule,
                MaxStudent = int.TryParse(txtSoLuongHv.Text, out int max) ? max : 20,
                Price = decimal.TryParse(txtGia.Text, out decimal price) ? price : 0,
                StartDate = dtStartDate.Value,
                EndDate = dtEndDate.Value,
                Description = txtMota.Text.Trim()
            };

            try
            {
                ClassesBL classesBL = new ClassesBL();
                int result = classesBL.UpdateClass(updatedClass);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật lớp học thành công!");
                    panel7.Hide();
                    dgvCapNhat.DataSource = classesBL.GetAllClasses();
                    DataGridViewStyleHelper.FormatClassDGV(dgvCapNhat);
                   
                    SelectedClassId = -1;
                    Clear();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật lớp học.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoalop_Click(object sender, EventArgs e)
        {
            if (dgvCapNhat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp học cần xóa.");
                return;
            }
            // Lấy thông tin lớp được chọn
            DataGridViewRow selectedRow = dgvCapNhat.SelectedRows[0];
            int classId = Convert.ToInt32(selectedRow.Cells["ClassID"].Value);

            // Kiểm tra xem lớp có học viên không
            int maxStudent = Convert.ToInt32(selectedRow.Cells["MaxStudent"].Value);
            int soLuongHV = maxStudent - new Students_ClassBL().AvailableSlots(classId);

            if (soLuongHV > 0)
            {
                MessageBox.Show("Không thể xóa lớp học vì có học viên đang tham gia lớp.");
                return;
            }
            // Hỏi người dùng có chắc chắn muốn xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            // Tiến hành xóa
            ClassesBL classesBL = new ClassesBL();
            Classes clsToDelete = new Classes { ClassID = classId };
            int deleted = classesBL.DeleteClass(clsToDelete);

            if (deleted > 0)
            {
                MessageBox.Show("Đã xóa lớp học thành công.");
                dgvCapNhat.DataSource = classesBL.GetAllClasses();
                DataGridViewStyleHelper.FormatClassDGV(dgvCapNhat);
                //FormatDGV(dgvCapNhat);
                SelectedClassId = -1;
            }
            else
            {
                MessageBox.Show("Xóa lớp học thất bại.");
            }

        }
        private void btnCapNhatLop_Click(object sender, EventArgs e)
        {
            ThoiGianHoc();
            panel7.Hide();
            panel4.Visible = true;
            ClassesBL classBL = new ClassesBL();
            var classes = classBL.GetAllClasses();

            dgvCapNhat.DataSource = classes;
            DataGridViewStyleHelper.FormatClassDGV(dgvCapNhat);
            //FormatDGV(dgvCapNhat);

            btnThemlop.Visible = true;
            btnSualop.Visible = true;
            btnXoalop.Visible = true;
            btnThemhocvien.Visible = false;
            btnHuy.Visible = false;

            cbLoaihinh.DataSource = new CategoryBL().GetAllCategories();
            cbLoaihinh.DisplayMember = "CategoryName";
            cbLoaihinh.ValueMember = "CategoryID";
        }
        private void cbLoaihinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaihinh.Text == "Personal Trainer")
            {
                txtSoLuongHv.Text = "1";
                txtSoLuongHv.ReadOnly = true;
            }    
            else
            {
                txtSoLuongHv.Text = "20";
                txtSoLuongHv.ReadOnly = false;
            }    
        }
        private List<string> NgayHoc()
        {
            List<string> selectedDays = new List<string>();
            if (chkT2.Checked) selectedDays.Add("Mon");
            if (chkT3.Checked) selectedDays.Add("Tue");
            if (chkT4.Checked) selectedDays.Add("Wed");
            if (chkT5.Checked) selectedDays.Add("Thu");
            if (chkT6.Checked) selectedDays.Add("Fri");
            if (chkT7.Checked) selectedDays.Add("Sat");
            if (chkCN.Checked) selectedDays.Add("Sun");
            return selectedDays;
        }
        private void ThoiGianHoc()
        {
            cbGioBD.Items.Clear();
            cbGioKT.Items.Clear();

            TimeSpan start = new TimeSpan(7, 0, 0);
            TimeSpan end = new TimeSpan(20, 0, 0);

            while (start<=end)
            {
                string time = start.ToString(@"hh\:mm");
                cbGioBD.Items.Add(time);
                cbGioKT.Items.Add(time);
                start = start.Add(TimeSpan.FromMinutes(30));
            }
            if (cbGioBD.Items.Count > 0)
                cbGioBD.SelectedIndex = 0;
            if (cbGioKT.Items.Count >1)
                cbGioKT.SelectedIndex = 1;
        }
        private bool NgayBatDauVaKetThuc(DateTime startDate, DateTime endDate)
        {
            DateTime today = DateTime.Today;
            if (startDate <today.AddDays(15))
            {
                MessageBox.Show("Lớp học được mở sau ít nhất 15 ngày.");
                return false;
            }    
            if (startDate >= endDate)
            {
                MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc.");
                return false;
            }
            return true;
        }
        private void btnThemlich_Click(object sender, EventArgs e)
        {
            var selectedDays = NgayHoc();
            if (selectedDays.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 ngày!");
                return;
            }    
            if (selectedDays.Count >3)
            {
                MessageBox.Show("Chỉ được chọn tối đa 3 ngày cho 1 lớp học.");
                return;
            }
            string start = cbGioBD.Text;
            string end = cbGioKT.Text;

            if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
            {
                MessageBox.Show("Vui lòng chọn giờ bắt đầu và giờ kết thúc.");
                return;
            }
            TimeSpan startTime = TimeSpan.Parse(start);
            TimeSpan endTime = TimeSpan.Parse(end);
            if (startTime >= endTime)
            {
                MessageBox.Show("Giờ bắt đầu phải trước giờ kết thúc.");
                return;
            }

            foreach (var day in selectedDays)
            {
                if (day == "Sun")
                {
                    if (startTime.Hours <9 || endTime.Hours >18)
                    {
                        MessageBox.Show("Các lớp Chủ nhật mở từ 09:00 đến 18:00");
                        return; 
                    }    
                }    
            }
            List<string> chuoiLichHoc = new List<string>();
            foreach (var day in selectedDays)
            {
                chuoiLichHoc.Add($"{day} {start}-{end}");
            }
            string newSchedule = string.Join("; ", chuoiLichHoc);
            if (!string.IsNullOrWhiteSpace(txtSchedule.Text))
            {
                txtSchedule.Text += "; " + newSchedule;
            }
            else
            {
                txtSchedule.Text = newSchedule;
            }    
        }

        private void dgvHLV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHLV.Rows[e.RowIndex];
                selectedTrainerId = Convert.ToInt32(row.Cells["TrainerID"].Value);
                txtHLV.Text = row.Cells["FullName"].Value.ToString();
            }
        }
        private void btnPhanCongHLV_Click(object sender, EventArgs e)
        {
            panel7.Show();
            string schedule = txtSchedule.Text.Trim();
            DateTime startDate = dtStartDate.Value;
            DateTime endDate = dtEndDate.Value;

            if (string.IsNullOrWhiteSpace(schedule))
            {
                MessageBox.Show("Vui lòng nhập lịch học trước khi phân công HLV");
                return;
            }
            if (!NgayBatDauVaKetThuc(startDate, endDate))
                return;

            TrainerBL trainerBL = new TrainerBL();
            var availableTrainers = trainerBL.GetAvailableTrainers(startDate, endDate, schedule);
            if (availableTrainers.Count ==  0)
            {
                MessageBox.Show("Không có huấn luyện viên nào phù hợp với lịch học.");
                return;
            }
            //gán ds HLV lên dgvCapNhat
            dgvHLV.DataSource = availableTrainers;
            dgvHLV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvCapNhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCapNhat.Rows[e.RowIndex];
                SelectedClassId = Convert.ToInt32(row.Cells["ClassID"].Value);

                txtTenLop.Text = row.Cells["ClassName"].Value.ToString();
                cbLoaihinh.SelectedValue = Convert.ToInt32(row.Cells["Category"].Value);

                int trainerId = Convert.ToInt32(row.Cells["TrainerID"].Value);
                TrainerBL trainerBL = new TrainerBL();
                var trainer = trainerBL.GetTrainerById(trainerId);
                txtHLV.Text = trainer != null ? trainer.FullName : "";

                txtSchedule.Text = row.Cells["Schedule"].Value.ToString();
                txtSoLuongHv.Text = row.Cells["MaxStudent"].Value.ToString();
                txtGia.Text = row.Cells["Price"].Value.ToString();

                dtStartDate.Value = Convert.ToDateTime(row.Cells["StartDate"].Value);
                dtEndDate.Value = Convert.ToDateTime(row.Cells["EndDate"].Value);

                txtMota.Text = row.Cells["Description"].Value.ToString();
            }
        }

        private void SearchClasses()
        {
            string keyword = txtTimkiem.Text.Trim().ToLower();
            ClassesBL classBL = new ClassesBL();
            var classes = classBL.GetAllClasses();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvClass.DataSource = classes;
                DataGridViewStyleHelper.FormatClassDGV(dgvClass);
                return;
            }

            List<Classes> filtered = classes;

            if (rdLoaihinh.Checked)
            {
                var categories = new CategoryBL().GetAllCategories();
                var match = categories.FirstOrDefault(c => c.CategoryName.ToLower().Contains(keyword));
                filtered = match != null ? classes.Where(c => c.Category == match.CategoryId).ToList() : new List<Classes>();
            }
            else if (rdHLV.Checked)
            {
                var trainers = new TrainerBL().GetAllTrainers();
                var match = trainers.FirstOrDefault(t => t.FullName.ToLower().Contains(keyword));
                filtered = match != null ? classes.Where(c => c.TrainerID == match.TrainerID).ToList() : new List<Classes>();
            }
            else if (rdThoigian.Checked)
            {
                string dateString = txtTimkiem.Text.Trim();

                if (!DateTime.TryParseExact(dateString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime targetDate))
                {
                    MessageBox.Show("Vui lòng nhập ngày theo định dạng dd/MM/yyyy (VD: 15/05/2025).", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                filtered = classes.Where(c => c.StartDate.Date == targetDate || c.EndDate.Date == targetDate).ToList();
            }
            else if (rdGia.Checked)
            {
                if (decimal.TryParse(keyword, out decimal price))
                {
                    filtered = classes.Where(c => c.Price == price).ToList();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số cho giá tiền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            dgvClass.DataSource = filtered;
            DataGridViewStyleHelper.FormatClassDGV(dgvClass);
        }


        private void btTimKiem_Click(object sender, EventArgs e)
        {
            SearchClasses();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenLop.Clear();
            txtGia.Clear();
            txtHLV.Clear();
            txtMota.Clear();
            txtSchedule.Clear();
            txtSoLuongHv.Clear();          
        }
    }
}
