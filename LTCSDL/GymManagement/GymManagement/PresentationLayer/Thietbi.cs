using PresentationLayer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;
using PresentationLayer.Helpers;

namespace PresentationLayer
{
    public partial class Thietbi : Form
    {
        private ThietBiBL thietbiBL = new ThietBiBL();
        private BaoTriBL baoTriBL = new BaoTriBL();
        private BindingSource ThietBiBindingSource = new BindingSource();
        public Thietbi()
        {
            InitializeComponent();
            DataGridViewStyleHelper.ApplyCustomStyle(dgvThietBi);
            pnThemThietBi.Visible = false;
            pnBaoTri.Visible = false;
        }
        private void KhoiTaoComboBox()
        {
            cbLoaiTB.Items.AddRange(new string[] {
                   "Thiết bị tập tim mạch",
                   "Thiết bị tập sức mạnh",
                   "Thiết bị tập chức năng",
                   "Thiết bị tập cơ bụng",
                   "Thiết bị tập nhóm cơ",
                   "Thiết bị hỗ trợ tập luyện",
                   "Thiết bị tập nhóm thể hình" });
            cbLoaiTB.SelectedIndex = 0;

            cbTinhTrang.Items.AddRange(new string[] { "Tốt", "Cần bảo trì", "Hư hỏng" });
            cbTinhTrang.SelectedIndex = 0;
        }
        private void Thietbi_Load_1(object sender, EventArgs e)
        {
            LoadDanhSachThietBi();
            PhanQuyenTheoVaiTro();
            LoadDanhSachPhongTap();
            KhoiTaoComboBox();
            btThemTB.Visible = false;
            btCapNhatTB.Visible = false;
            btXoaTB.Visible = false;
            btClearTB.Visible = false;
        }
        private void PhanQuyenTheoVaiTro()
        {
            string role = UserSession.Role;
            if (role != "Admin")
            {
                btnChinhSuaThietBi.Visible = false;
                btnBaoTri.Visible = false;
            }
        }
        private void LoadDanhSachPhongTap()
        {
            try
            {
                var gyms = thietbiBL.GetActiveGyms();

                if (gyms == null || gyms.Count == 0)
                {
                    MessageBox.Show("Không có phòng tập đang hoạt động trong hệ thống.");
                    return;
                }
                cbDiaChiTB.DataSource = gyms;
                cbDiaChiTB.DisplayMember = "GymName";
                cbDiaChiTB.ValueMember = "GymId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng tập: " + ex.Message);
            }
        }
       
        private void LoadDanhSachThietBi()
        {
            List<Equipment> data = thietbiBL.XemTatCaThietBi();
            ThietBiBindingSource.DataSource = data;

            dgvThietBi.DataSource = ThietBiBindingSource;
            DataGridViewStyleHelper.DinhDangDanhSachThietBi(dgvThietBi);

            dgvChinhSuaTB.DataSource = ThietBiBindingSource;
            dgvChinhSuaTB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChinhSuaTB.Columns["EquipmentId"].HeaderText = "Mã thiết bị";
            dgvChinhSuaTB.Columns["Name"].HeaderText = "Tên thiết bị";
            dgvChinhSuaTB.Columns["Type"].HeaderText = "Loại";
            dgvChinhSuaTB.Columns["PurchaseDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvChinhSuaTB.Columns["Status"].HeaderText = "Tình trạng";
            dgvChinhSuaTB.Columns["GymName"].HeaderText = "Thuộc cơ sở";
            dgvChinhSuaTB.DefaultCellStyle.ForeColor = Color.Black;

            dgvChinhSuaTB.DataBindingComplete += (object s, DataGridViewBindingCompleteEventArgs e) =>
            {
                if (dgvChinhSuaTB.Columns.Contains("GymId"))
                    dgvChinhSuaTB.Columns["GymId"].Visible = false;
            };
        }

        private void btnDanhSachThietBi_Click(object sender, EventArgs e)
        {
            pnDSTB.Visible = true;
            pnThemThietBi.Visible = false;
            pnBaoTri.Visible = false;
            LoadDanhSachThietBi();
            btThemTB.Visible = false;
            btCapNhatTB.Visible = false;
            btXoaTB.Visible = false;
            btClearTB.Visible = false;
        }

        private void btnChinhSuaThietBi_Click(object sender, EventArgs e)
        {
            pnThemThietBi.Visible = true;
            pnBaoTri.Visible = false;
            pnDSTB.Visible = false;
            LoadDanhSachThietBi();
            btThemTB.Visible = true;
            btCapNhatTB.Visible = true;
            btXoaTB.Visible = true;
            btClearTB.Visible = true;
        }

        private void btnBaoTri_Click(object sender, EventArgs e)
        {
            pnBaoTri.Visible = true;
            pnThemThietBi.Visible = false;
            pnDSTB.Visible = false;
            LoadDanhSachQuanLyBaoTri();
            btThemTB.Visible = false;
            btCapNhatTB.Visible = false;
            btXoaTB.Visible = false;
            btClearTB.Visible = false;
        }
        private void LoadDanhSachQuanLyBaoTri()
        {
            int dinhKyBaoTriNgay = 180; // định kỳ mỗi 6 tháng
            var data = baoTriBL.LayBaoTriTongHop(dinhKyBaoTriNgay);

            var allDevices = thietbiBL.XemTatCaThietBi(); // List<EquipmentView>

            foreach (var item in data)
            {
                var match = allDevices.FirstOrDefault(x => x.EquipmentId == item.EquipmentId);
                if (match != null)
                {
                    item.PurchaseDate = match.PurchaseDate;

                }
            }

            dvgTheoDoiTB.DataSource = data;
            DataGridViewStyleHelper.DinhDangQuanLyBaoTri(dvgTheoDoiTB);

            // Làm mới cảnh báo đúng với status thực tế
            foreach (DataGridViewRow row in dvgTheoDoiTB.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; // Reset màu trước

                var status = row.Cells["Status"]?.Value?.ToString();
                if (status == "Tốt")
                {
                    continue; // Không cảnh báo nếu đã tốt
                }
                bool canhBao = false;

                if (status == "Cần bảo trì" || status == "Hư hỏng") canhBao = true;

                // Kiểm tra sự tồn tại của cột "DuKienBaoTriKeTiep" trong dòng trước khi truy cập
                if (row.Cells["NextMaintenanceDate"] != null && row.Cells["NextMaintenanceDate"].Value != DBNull.Value)
                {
                    var duKienCell = row.Cells["NextMaintenanceDate"];
                    if (DateTime.TryParse(duKienCell?.Value?.ToString(), out DateTime ngayDuKien))
                    {
                        if ((ngayDuKien - DateTime.Today).TotalDays <= 7)
                            canhBao = true;
                    }
                }

                if (canhBao)
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
            }
        }

        private void dgvChinhSuaTB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvChinhSuaTB.Rows[e.RowIndex].DataBoundItem as Equipment;
                if (row == null) return;

                txtTenTB.Text = row.Name;
                cbLoaiTB.Text = row.Type;
                dpNgayMua.Value = row.PurchaseDate;
                cbTinhTrang.Text = row.Status;
                cbDiaChiTB.Text = row.GymName;

                btCapNhatTB.Tag = row.EquipmentId;
            }
        }
        private Equipment LayThongTinThietBiTuForm()
        {
            return new Equipment
            {
                Name = txtTenTB.Text.Trim(),
                Type = cbLoaiTB.Text.Trim(),
                PurchaseDate = dpNgayMua.Value,
                Status = cbTinhTrang.Text.Trim(),
                GymId = Convert.ToInt32(cbDiaChiTB.SelectedValue)
            };
        }

        private void btThemTB_Click(object sender, EventArgs e)
        {
            // Lấy thông tin thiết bị từ form
            Equipment newEquipment = LayThongTinThietBiTuForm();

            int result = thietbiBL.ThemThietBi(newEquipment);
            if (result>0)
            {
                MessageBox.Show("Thêm thiết bị thành công.");
                LoadDanhSachThietBi();
            }
            else
            {
                MessageBox.Show("Thêm thiết bị thất bại.");
            }
        }

        private void btCapNhatTB_Click(object sender, EventArgs e)
        {
            if (btCapNhatTB.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị để cập nhật!", "Thông báo");
                return;
            }

            Equipment updatedEq = new Equipment
            {
                EquipmentId = Convert.ToInt32(btCapNhatTB.Tag),
                Name = txtTenTB.Text.Trim(),
                Type = cbLoaiTB.Text.Trim(),
                PurchaseDate = dpNgayMua.Value,
                Status = cbTinhTrang.Text.Trim(),
                GymId = Convert.ToInt32(cbDiaChiTB.SelectedValue) // Giá trị thực (Gym_id)
            };

            int result = thietbiBL.CapNhatThietBi(updatedEq);
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thiết bị thành công.");
                LoadDanhSachThietBi(); // Làm mới danh sách
            }
            else
            {
                MessageBox.Show("Cập nhật thiết bị thất bại.");
            }
        }

        private void btXoaTB_Click(object sender, EventArgs e)
        {
            if (dgvChinhSuaTB.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn học viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvChinhSuaTB.CurrentRow.Cells["EquipmentId"].Value);
            string tenTB = dgvChinhSuaTB.CurrentRow.Cells["Name"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thiết bị \"{tenTB}\" không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                bool success = thietbiBL.XoaThietBi(id);
                if (success)
                {
                    MessageBox.Show("Xóa thiết bị thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachThietBi();
                }
                else
                {
                    MessageBox.Show("Xóa thiết bị thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btClearTB_Click(object sender, EventArgs e)
        {
            txtTenTB.Clear();
            if (cbLoaiTB.Items.Count > 0)
                cbLoaiTB.SelectedIndex = 0;

            if (cbTinhTrang.Items.Count > 0)
                cbTinhTrang.SelectedIndex = 0;

            if (cbDiaChiTB.Items.Count > 0)
                cbDiaChiTB.SelectedIndex = 0;
            dpNgayMua.Value = DateTime.Now;
        }
        private void ToMauCanhBao(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString();
                if (status == "Cần bảo trì" || status == "Hư hỏng")
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }
        
        private void DinhDangLichSuBaoTri()
        {
            dvgLichSuTB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dvgLichSuTB.Columns.Contains("MaintenanceDate"))
                dvgLichSuTB.Columns["MaintenanceDate"].HeaderText = "Lịch bảo trì";
            if (dvgLichSuTB.Columns.Contains("Status"))
                dvgLichSuTB.Columns["Status"].HeaderText = "Tình trạng";
            if (dvgLichSuTB.Columns.Contains("ActualMaintenanceDate"))
                dvgLichSuTB.Columns["ActualMaintenanceDate"].HeaderText = "Ngày thực tế";
            if (dvgLichSuTB.Columns.Contains("NextMaintenanceDate"))
                dvgLichSuTB.Columns["NextMaintenanceDate"].HeaderText = "Ngày bảo trì tiếp theo";

            if (dvgLichSuTB.Columns.Contains("MaintenanceId"))
                dvgLichSuTB.Columns["MaintenanceId"].Visible = false;
            if (dvgLichSuTB.Columns.Contains("EquipmentName"))
                dvgLichSuTB.Columns["EquipmentName"].Visible = false;
            if (dvgLichSuTB.Columns.Contains("PurchaseDate"))
                dvgLichSuTB.Columns["PurchaseDate"].Visible = false;

            // Xóa nếu đã tồn tại
            if (dvgLichSuTB.Columns.Contains("btnHoanTat"))
            {
                dvgLichSuTB.Columns.Remove("btnHoanTat");
            }
            // Thêm cột nút Hoàn tất nếu chưa có
            if (!dvgLichSuTB.Columns.Contains("btnHoanTat"))
            {
                DataGridViewButtonColumn btnHoanTat = new DataGridViewButtonColumn();
                btnHoanTat.Name = "btnHoanTat";
                btnHoanTat.HeaderText = "Thao tác";
                btnHoanTat.Text = "Hoàn tất";
                btnHoanTat.UseColumnTextForButtonValue = true;
                btnHoanTat.DefaultCellStyle.BackColor = Color.LightGreen;
                dvgLichSuTB.Columns.Add(btnHoanTat);
            }

            // Disable nút Hoàn tất nếu trạng thái đã hoàn thành
            foreach (DataGridViewRow row in dvgLichSuTB.Rows)
            {
                var status = row.Cells["Status"]?.Value?.ToString();
                if (status == "Đã hoàn thành" && row.Cells["btnHoanTat"] != null)
                {
                    row.Cells["btnHoanTat"].ReadOnly = true;
                    row.Cells["btnHoanTat"].Style.BackColor = Color.LightGray;
                }
            }
        }

        private void dvgTheoDoiTB_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewStyleHelper.DinhDanglichSuBaoTri(dvgTheoDoiTB);

            if (dvgTheoDoiTB.CurrentRow != null)
            {
                int equipmentId = Convert.ToInt32(dvgTheoDoiTB.CurrentRow.Cells["EquipmentId"].Value);
                LoadLichSuBaoTriToiGian(equipmentId);
            }
        }
        private void LoadLichSuBaoTri(int equipmentId)
        {
            var data = baoTriBL.LayLichSuBaoTriTheoThietBi(equipmentId);
            dvgLichSuTB.DataSource = data;
            DinhDangLichSuBaoTri();
        }

        private void btThemBaoTri_Click(object sender, EventArgs e)
        {
            using (FormThemBaoTri form = new FormThemBaoTri())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachQuanLyBaoTri();
                    // Hiển thị lịch sử của thiết bị vừa thêm
                    if (form.Tag != null && form.Tag is DataRow selectedRow)
                    {
                        int equipmentId = Convert.ToInt32(selectedRow["EquipmentId"]);
                        string tenThietBi = selectedRow["Name"].ToString();

                        var lichSu = baoTriBL.LayLichSuBaoTriTheoThietBi(equipmentId);
                        dvgLichSuTB.DataSource = lichSu;
                        DinhDangLichSuBaoTri();

                    }
                }

            }
        }

        private void btXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dvgTheoDoiTB.CurrentRow != null)
            {
                int id = Convert.ToInt32(dvgTheoDoiTB.CurrentRow.Cells["EquipmentId"].Value);
                string tenTB = dvgTheoDoiTB.CurrentRow.Cells["EquipmentName"].Value.ToString();

                var lichSu = baoTriBL.LayLichSuBaoTriTheoThietBi(id);

                dvgLichSuTB.DataSource = lichSu;
                DinhDangLichSuBaoTri();
            }
        }

        private void btCapNhatBaoTri_Click(object sender, EventArgs e)
        {
            if (dvgLichSuTB.CurrentRow != null)
            {
                int maintenanceId = Convert.ToInt32(dvgLichSuTB.CurrentRow.Cells["MaintenanceId"].Value);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lịch sử bảo trì này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    bool success = baoTriBL.XoaBaoTri(maintenanceId);
                    if (success)
                    {
                        MessageBox.Show("Xóa lịch sử bảo trì thành công!", "Thông báo");

                        // Reload lại dữ liệu sau khi xóa
                        if (dvgTheoDoiTB.CurrentRow != null)
                        {
                            int equipmentId = Convert.ToInt32(dvgTheoDoiTB.CurrentRow.Cells["EquipmentId"].Value);
                            LoadLichSuBaoTri(equipmentId);
                        }
                        LoadDanhSachQuanLyBaoTri();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lịch sử bảo trì để xóa!", "Thông báo");
            }
        }
        private void LoadLichSuBaoTriToiGian(int equipmentId)
        {
            var lichSu = baoTriBL.LayLichSuBaoTriTheoThietBi(equipmentId);

            if (lichSu.Any())
            {
                // Lọc: Ưu tiên lấy Đang bảo trì
                var dangBaoTri = lichSu.FirstOrDefault(r => r.Status == "Đang bảo trì");
                if (dangBaoTri != null)
                {
                    dvgLichSuTB.DataSource = new List<Maintenance> { dangBaoTri };
                    DinhDangLichSuBaoTri();
                }
                else
                {
                    // Nếu không có, tìm bảo trì gần nhất đã hoàn thành
                    var hoanThanhGanNhat = lichSu
                        .Where(r => r.Status == "Đã hoàn thành" && r.MaintenanceDate != default)
                        .OrderByDescending(r => r.MaintenanceDate)
                        .FirstOrDefault();

                    if (hoanThanhGanNhat != null)
                    {
                        dvgLichSuTB.DataSource = new List<Maintenance> { hoanThanhGanNhat };
                        DinhDangLichSuBaoTri();
                    }
                    else
                    {
                        dvgLichSuTB.DataSource = null;
                    }
                }
            }
            else
            {
                dvgLichSuTB.DataSource = null;
            }
        }

        private void dvgLichSuTB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewStyleHelper.DinhDanglichSuBaoTri(dvgTheoDoiTB);
           
            // Bỏ qua nếu bấm ngoài dòng hợp lệ hoặc ngoài cột
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex >= 0 && dvgLichSuTB.Columns[e.ColumnIndex].Name == "btnHoanTat")
            {
                string status = dvgLichSuTB.Rows[e.RowIndex].Cells["Status"].Value?.ToString();

                if (status == "Đã hoàn thành")
                {
                    MessageBox.Show("Bảo trì này đã hoàn thành, không thể thao tác thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Nếu chưa hoàn thành thì cho bấm hoàn tất
                int maintenanceId = Convert.ToInt32(dvgLichSuTB.Rows[e.RowIndex].Cells["MaintenanceId"].Value);


                DialogResult result = MessageBox.Show("Bạn muốn hoàn tất lần bảo trì này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool success = baoTriBL.HoanTatBaoTri(maintenanceId);
                    if (success)
                    {
                        MessageBox.Show("Đã hoàn tất bảo trì thành công!", "Thông báo");

                        int equipmentId = -1;

                        // Cập nhật lại tình trạng thiết bị
                        if (dvgTheoDoiTB.CurrentRow != null)
                        {
                            equipmentId = Convert.ToInt32(dvgTheoDoiTB.CurrentRow.Cells["EquipmentId"].Value);
                            baoTriBL.CapNhatTinhTrangThietBi(equipmentId, "Tốt");
                        }

                        // Gọi lại toàn bộ danh sách và lịch sử sau khi cập nhật
                        LoadDanhSachQuanLyBaoTri();

                        if (equipmentId != -1)
                            LoadLichSuBaoTri(equipmentId);
                    }
                    else
                    {
                        MessageBox.Show("Thao tác thất bại.", "Thông báo");
                    }
                }
            }
        }

        private void btnSearchTB_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemTB.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            string loaiTimKiem = rdoLoaiTB.Checked ? "loai" : "ten";

            List<Equipment> result = thietbiBL.TimKiemThietBi(tuKhoa, loaiTimKiem);
            ThietBiBindingSource.DataSource = result;
            dgvThietBi.DataSource = ThietBiBindingSource;
            dgvChinhSuaTB.DataSource = ThietBiBindingSource;
        }
    }
}
