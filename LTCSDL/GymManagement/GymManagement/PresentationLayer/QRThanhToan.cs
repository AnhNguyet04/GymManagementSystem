using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class QRThanhToan : Form
    {
        private List<Datum> _bankData;
        public QRThanhToan(string soTien)
        {
            InitializeComponent();
            LoadBankData();
            InitBankSelector();
            cbTemplate.SelectedIndex = 1;
            txtSoTien.Text = soTien;
        }
        private void LoadBankData()
        {
            using (WebClient client = new WebClient())
            {
                var htmlData = client.DownloadData("https://api.vietqr.io/v2/banks");
                var bankRawJson = Encoding.UTF8.GetString(htmlData);
                var bankObj = JsonConvert.DeserializeObject<Bank>(bankRawJson);
                _bankData = bankObj.data != null
                            ? new List<Datum>(bankObj.data)
                            : new List<Datum>();
            }
        }
        private void InitBankSelector()
        {
            txtBank.Click += (s, e) =>
            {
                ShowBankSelector(txtBank, _bankData);
            };
        }
        private void ShowBankSelector(TextBox target, List<Datum> banks)
        {
            var popup = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                Size = new Size(400, 150),
                TopMost = true
            };

            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoGenerateColumns = false,
            };

            // Tạo các cột bạn cần hiển thị
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "code",
                HeaderText = "Mã ngân hàng"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "shortName",
                HeaderText = "Tên rút gọn"
            });

            dgv.DataSource = banks;

            // Khi double-click vào dòng nào thì gán vào TextBox và đóng popup
            dgv.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                var sel = banks[e.RowIndex];
                target.Text = sel.shortName;
                target.Tag = sel.bin;
                popup.Close();
            };

            popup.Controls.Add(dgv);

            // Đặt popup ngay dưới TextBox
            var pt = target.PointToScreen(Point.Empty);
            popup.Location = new Point(pt.X, pt.Y + target.Height);

            // Tự động đóng khi click ra ngoài
            popup.Deactivate += (s, e) => popup.Close();

            popup.Show();
        }

        private void btnCreateQR_Click(object sender, EventArgs e)
        {
            var apiRequest = new ApiRequest
            {
                acqId = Convert.ToInt32(txtBank.Tag.ToString()),
                accountNo = long.Parse(txtSTK.Text),
                accountName = txtTenTaiKhoan.Text,
                amount = (int)Math.Round(decimal.Parse(txtSoTien.Text)),
                format = "text",
                template = cbTemplate.Text
            };

            var jsonRequest = JsonConvert.SerializeObject(apiRequest);

            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

            var response = client.Execute(request);
            if (!response.IsSuccessful)
            {
                MessageBox.Show("Lỗi khi tạo mã QR", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dataResult = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            var imageBase64 = dataResult.data.qrDataURL.Replace("data:image/png;base64,", "");
            var image = Base64ToImage(imageBase64);

            this.Hide();
            var qrForm = new QRCODE(image);
            qrForm.ShowDialog();
        }
        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
