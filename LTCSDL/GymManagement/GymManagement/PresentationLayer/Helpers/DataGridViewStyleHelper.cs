using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer.Helpers
{
    public static class DataGridViewStyleHelper
    {
        public static void ApplyCustomStyle(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 96, 144);
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }
        public static void FormatClassDGV(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns["ClassID"].HeaderText = "Mã lớp";
            dataGridView.Columns["ClassName"].HeaderText = "Tên lớp";
            dataGridView.Columns["Category"].HeaderText = "Loại hình lớp học";
            dataGridView.Columns["TrainerId"].HeaderText = "Mã HLV phụ trách";
            dataGridView.Columns["Schedule"].HeaderText = "Lịch học";
            dataGridView.Columns["MaxStudent"].HeaderText = "Số học viên tối đa";
            dataGridView.Columns["AvailableSlots"].HeaderText = "Số lượng còn trống";
            dataGridView.Columns["Price"].HeaderText = "Giá";
            dataGridView.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
            dataGridView.Columns["EndDate"].HeaderText = "Ngày kết thúc";
            dataGridView.Columns["Description"].HeaderText = "Mô tả";
        }
        public static void FormatStudentDGV(DataGridView dataGridView)
        {

            dataGridView.Columns["StudentId"].HeaderText = "Mã học viên";
            dataGridView.Columns["FullName"].HeaderText = "Họ tên học viên";
            dataGridView.Columns["DOB"].HeaderText = "Ngày sinh";
            dataGridView.Columns["Gender"].HeaderText = "Giới tính";
            dataGridView.Columns["Phone"].HeaderText = "Số điện thoại";
            dataGridView.Columns["Email"].HeaderText = "Email";
            dataGridView.Columns["Address"].HeaderText = "Địa chỉ";
            dataGridView.Columns["RegisteredDate"].HeaderText = "Ngày đăng ký";
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public static void FormatMembershipDGV(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns["UserId"].HeaderText = "Mã HV";
            dataGridView.Columns["Fullname"].HeaderText = "Họ tên";
            dataGridView.Columns["Packagetype"].HeaderText = "Gói tập";
            dataGridView.Columns["Price"].HeaderText = "Giá";
            dataGridView.Columns["Startdate"].HeaderText = "Ngày bắt đầu";
            dataGridView.Columns["Enddate"].HeaderText = "Ngày kết thúc";
            dataGridView.Columns["ClassNames"].Visible = false;
        }
        public static void DinhDangDanhSachNhanVien(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns[nameof(User.UserId)].HeaderText = "Mã nhân viên";
                dataGridView.Columns[nameof(User.Username)].HeaderText = "Tên đăng nhập";
                dataGridView.Columns[nameof(User.FullName)].HeaderText = "Họ tên";
                dataGridView.Columns[nameof(User.DOB)].HeaderText = "Ngày sinh";
                dataGridView.Columns[nameof(User.Phone)].HeaderText = "Số điện thoại";
                dataGridView.Columns[nameof(User.Email)].HeaderText = "Email";
                dataGridView.Columns[nameof(User.Address)].HeaderText = "Địa chỉ";
                dataGridView.Columns[nameof(User.Role)].HeaderText = "Vị trí";
            }
        }
        public static void DinhDangDanhSachThietBi( DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dataGridView.Columns.Contains("GymId"))
                dataGridView.Columns["GymId"].Visible = false;

            if (dataGridView.Columns["Equipment_id"] != null)
                dataGridView.Columns["Equipment_id"].HeaderText = "Mã thiết bị";

            if (dataGridView.Columns["Name"] != null)
                dataGridView.Columns["Name"].HeaderText = "Tên thiết bị";

            if (dataGridView.Columns["Type"] != null)
                dataGridView.Columns["Type"].HeaderText = "Loại";

            if (dataGridView.Columns["Purchase_date"] != null)
            {
                dataGridView.Columns["Purchase_date"].HeaderText = "Ngày mua";
                dataGridView.Columns["Purchase_date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dataGridView.Columns["Status"] != null)
                dataGridView.Columns["Status"].HeaderText = "Tình trạng";

            if (dataGridView.Columns["Gym_name"] != null)
                dataGridView.Columns["Gym_name"].HeaderText = "Thuộc cơ sở";

            //dataGridView.DefaultCellStyle.ForeColor = Color.Black;
        }
        public static void DinhDangThanhToan( DataGridView dataGridView )
        {
            dataGridView.Columns["ReferenceId"].Visible = false;
            dataGridView.Columns["Loai"].HeaderText = "Loại";
            dataGridView.Columns["Ten"].HeaderText = "Tên";
            dataGridView.Columns["Gia"].HeaderText = "Giá";
            dataGridView.Columns["TinhTrang"].HeaderText = "Tình trạng";
            dataGridView.Columns["TransactionDate"].HeaderText = "Ngày thanh toán";
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static void DinhDangQuanLyBaoTri(DataGridView dataGridView )
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Kiểm tra và đặt tiêu đề cột
            if (dataGridView.Columns.Contains("EquipmentName"))
                dataGridView.Columns["EquipmentName"].HeaderText = "Thiết bị";

            if (dataGridView.Columns.Contains("MaintenanceDate"))
                dataGridView.Columns["MaintenanceDate"].HeaderText = "Lịch dự định bảo trì";

            if (dataGridView.Columns.Contains("ActualMaintenanceDate"))
                dataGridView.Columns["ActualMaintenanceDate"].HeaderText = "Bảo trì gần nhất";

            if (dataGridView.Columns.Contains("NextMaintenanceDate"))
                dataGridView.Columns["NextMaintenanceDate"].HeaderText = "Dự kiến bảo trì kế tiếp";

            if (dataGridView.Columns.Contains("Status"))
                dataGridView.Columns["Status"].HeaderText = "Tình trạng";

            if (dataGridView.Columns.Contains("PurchaseDate"))
                dataGridView.Columns["PurchaseDate"].HeaderText = "Ngày mua";

            if (dataGridView.Columns.Contains("MaintenanceId"))
                dataGridView.Columns["MaintenanceId"].Visible = false;
        }
        public static void DinhDanglichSuBaoTri(DataGridView dataGridView)
        {
            if (dataGridView.Columns.Contains("EquipmentName"))
                dataGridView.Columns["EquipmentName"].HeaderText = "Thiết bị";

            if (dataGridView.Columns.Contains("MaintenanceDate"))
                dataGridView.Columns["MaintenanceDate"].HeaderText = "Ngày bảo trì";

            if (dataGridView.Columns.Contains("NextMaintenanceDate"))
                dataGridView.Columns["NextMaintenanceDate"].HeaderText = "Bảo trì tiếp theo";
        }
        
    }
}

