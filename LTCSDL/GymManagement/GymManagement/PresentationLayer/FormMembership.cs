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
    public partial class FormMembership : Form
    {
        private HocVienBL hocvienBL = new HocVienBL();
        public Membership MembershipMoi { get; private set; }
        private int studentId;
        private List<PackageTypeInfo> danhSachGoi;

        public FormMembership(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadDanhSachGoiTap();
            dpBatDauGoiTap.MinDate = DateTime.Today;
            cbGoiTap.SelectedIndexChanged += cbGoiTap_SelectedIndexChanged;
        }
        private void LoadDanhSachGoiTap()
        {
            try
            {
                danhSachGoi = hocvienBL.LayDanhSachGoiTap();
                cbGoiTap.DataSource = danhSachGoi;
                cbGoiTap.DisplayMember = "PackageType";
                cbGoiTap.ValueMember = "PackageType";

                if (danhSachGoi.Count > 0)
                {
                    cbGoiTap.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Không có gói tập nào trong hệ thống.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load gói tập: " + ex.Message);
            }
        }

        private void FormMembership_Load(object sender, EventArgs e)
        {
            
        }

        private void cbGoiTap_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbGoiTap.SelectedItem as PackageTypeInfo;
            if (selected == null) return;

            DateTime startDate = dpBatDauGoiTap.Value;
            dpKetThucGoiTap.Value = startDate.AddMonths(selected.DurationInMonths);
            txtGia.Text = selected.Price.ToString("N0");
        }

        private void btLuuGoiTap_Click(object sender, EventArgs e)
        {
            var selected = cbGoiTap.SelectedItem as PackageTypeInfo;
            if (selected == null) return;

            MembershipMoi = new Membership
            {
                StudentId = studentId,
                Packagetype = selected.PackageType,
                Startdate = dpBatDauGoiTap.Value.Date,
                Enddate = dpKetThucGoiTap.Value.Date,
                Price = selected.Price
            };
            DialogResult = DialogResult.OK;
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
