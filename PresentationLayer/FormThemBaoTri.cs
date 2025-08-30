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

namespace PresentationLayer
{
    public partial class FormThemBaoTri : Form
    {
        private ThietBiBL thietBiBL = new ThietBiBL();
        private BaoTriBL baoTriBL = new BaoTriBL();
        private List<Equipment> danhSachThietBi = new List<Equipment>();
        public FormThemBaoTri()
        {
            InitializeComponent();
            LoadThietBiVaoComboBox();
            SetupComboBoxStatus();
            dpBaoTriTiepTheo.Value = DateTime.Today;

            // Gắn sự kiện thay đổi ngày
            dpBaoTriTiepTheo.ValueChanged += dpBaoTriTiepTheo_ValueChanged;
        }
        private void LoadThietBiVaoComboBox()
        {
            danhSachThietBi = thietBiBL.XemTatCaThietBi();
            cbChonTB.DisplayMember = "Name";
            cbChonTB.ValueMember = "Equipment_id";
            cbChonTB.DataSource = danhSachThietBi;
        }
        private void SetupComboBoxStatus()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.AddRange(new string[] { "Đang bảo trì", "Đã hoàn thành" });
            if (cbTrangThai.Items.Count > 0)
                cbTrangThai.SelectedIndex = 0;
        }

        private void dpBaoTriTiepTheo_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dpBaoTriTiepTheo.Value.Date;
            DateTime today = DateTime.Today;

            if (selectedDate < today)
            {
                cbTrangThai.SelectedItem = "Đã hoàn thành";
                cbTrangThai.Enabled = false; // Khóa combobox, không cho tự chỉnh nữa
            }
            else
            {
                cbTrangThai.SelectedItem = "Đang bảo trì";
                cbTrangThai.Enabled = false; // Khóa combobox, không cho tự chỉnh nữa
            }
        }

        private void btLuuBaoTri_Click(object sender, EventArgs e)
        {
            if (cbChonTB.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị.");
                return;
            }
            Equipment selectedTB = cbChonTB.SelectedItem as Equipment;
            if (selectedTB == null) return;

            int equipmentId = selectedTB.EquipmentId;
            DateTime maintenanceDate = dpBaoTriTiepTheo.Value.Date;
            string status = cbTrangThai.Text;

            // Kiểm tra lịch trùng
            if (baoTriBL.KiemTraTrungLichBaoTri(equipmentId, maintenanceDate))
            {
                MessageBox.Show("Thiết bị này đã có lịch bảo trì vào ngày " + maintenanceDate.ToString("dd/MM/yyyy") + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (maintenanceDate > DateTime.Today.AddYears(2))
            {
                MessageBox.Show("Ngày bảo trì không thể quá xa trong tương lai!", "Thông báo");
                return;
            }
            bool result = baoTriBL.ThemBaoTriMoi(equipmentId, maintenanceDate, status);


            if (result)
            {
                MessageBox.Show("Thêm bảo trì thành công.", "Thông báo");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Thêm bảo trì thất bại.", "Lỗi");
            }
        }

        private void btHuyBaoTri_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbChonTB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
