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
using System.Windows.Forms.DataVisualization.Charting;

namespace PresentationLayer
{
    public partial class BaoCaoThongKe : Form
    {
        private ThongKeBL thongKeBL = new ThongKeBL();
        public BaoCaoThongKe()
        {
            InitializeComponent();
        }

        private void BaoCaoThongKe_Load(object sender, EventArgs e)
        {
            BieuDoTron();
            BieuDoCot();
            BieuDoDoanhThu();
            BieuDoPieMembership();
        }
        private void BieuDoTron()
        {
            var data = thongKeBL.GetStudentCountByCategory();

            chart1.Series.Clear();
            chart1.Titles.Clear();
            Title title = new Title("Tỉ lệ học viên theo loại hình lớp học", Docking.Top, new Font("Microsoft Sans Serif",20,FontStyle.Bold),Color.Black);
            chart1.Titles.Add(title);

            Series series = new Series
            {
                Name = "LoaiHinh",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new Font("Microsoft Sans Serif",16,FontStyle.Bold),
                LabelForeColor = Color.Black
            };

            chart1.Series.Add(series);

            foreach (var item in data)
            {
                series.Points.AddXY(item.CategoryName, item.StudentCount);
            }
            // Cấu hình font hiển thị chú thích (legend)
            chart1.Legends[0].Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.Legends[0].ForeColor = Color.Black;
            series.Label = "#PERCENT{P1}";
            series.LegendText = "#VALX";
        }
        private void BieuDoCot()
        {
            DataTable dt = thongKeBL.GetStudentCountByMonth();
            chart2.Series.Clear();
            chart2.Titles.Clear();

            chart2.Titles.Add(new Title("Số lượng học viên theo tháng", Docking.Top, new Font("Microsoft Sans Serif", 20, FontStyle.Bold), Color.Black));
            Series series = new Series("Số lượng")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue,
                Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold),
                IsValueShownAsLabel = true
            };
            chart2.Series.Add(series);
            foreach (DataRow row in dt.Rows)
            {
                string thang = "Tháng" + row["Thang"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                series.Points.AddXY(thang, soLuong);
            }
            chart2.ChartAreas[0].AxisX.Title = "Tháng";
            chart2.ChartAreas[0].AxisY.Title = "Số lượng học viên";
            chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            chart2.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
        }
        private void BieuDoDoanhThu()
        {
            DataTable dt = thongKeBL.GetDoanhThuTheoThang();
            chart3.Series.Clear();
            chart3.Titles.Clear();

            chart3.Titles.Add(new Title("Doanh thu thực tế theo tháng", Docking.Top, new Font("Microsoft Sans Serif", 20, FontStyle.Bold), Color.DarkGreen));

            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.OrangeRed,
                Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold),
                IsValueShownAsLabel = true
            };

            chart3.Series.Add(series);

            foreach (DataRow row in dt.Rows)
            {
                string thang = "Tháng " + row["Thang"].ToString();
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                series.Points.AddXY(thang, doanhThu);
            }

            chart3.ChartAreas[0].AxisX.Title = "Tháng";
            chart3.ChartAreas[0].AxisY.Title = "Doanh thu (VND)";
            chart3.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            chart3.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
        }
        private void BieuDoPieMembership()
        {
            DataTable dt = thongKeBL.GetTiLeMembershipPackage();
            chart4.Series.Clear();
            chart4.Titles.Clear();

            chart4.Titles.Add(new Title("Tỉ lệ đăng ký gói Membership", Docking.Top, new Font("Microsoft Sans Serif", 20, FontStyle.Bold), Color.Black));

            Series series = new Series("Gói Membership")
            {
                ChartType = SeriesChartType.Pie,
                Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold),
                LabelForeColor = Color.Black
            };

            chart4.Series.Add(series);

            foreach (DataRow row in dt.Rows)
            {
                string packageType = row["Package_type"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                series.Points.AddXY(packageType, soLuong);
            }

            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";
            series.IsValueShownAsLabel = true;
            series.Label = "#VALX: #PERCENT";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
           
            tableLayoutPanel1.Visible = false;
            //cấu hình form con
            Form form = new FormThongKe();
            pnThongKe.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            //thêm vào panel
            pnThongKe.Controls.Add(form);
            pnThongKe.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void btnBieuDo_Click(object sender, EventArgs e)
        {
            pnThongKe.Controls.Clear();
            tableLayoutPanel1.Visible = true;
            pnThongKe.Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1.Dock = DockStyle.Fill;

            BieuDoTron();
            BieuDoCot();
            BieuDoDoanhThu();
            BieuDoPieMembership();
        }
    }
}
