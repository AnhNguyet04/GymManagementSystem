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
    public partial class PhuongthucTT : Form
    {
        private int studentId;
        private int classId;
        private decimal amount;
        private string paymentType;
        public PhuongthucTT(int studentId, int classId, decimal amount, string paymentType)
        {
            InitializeComponent();
            this.studentId = studentId;
            this.classId = classId;
            this.amount = amount;
            this.paymentType = paymentType;
        }

        private void PhuongthucTT_Load(object sender, EventArgs e)
        {
            txtMahocvien.Text = studentId.ToString();
            txtMalophoc.Text = classId.ToString();
            txtSotien.Text = amount.ToString();
            cbLoaithanhtoan.SelectedItem = paymentType;

            if (cbPTTT.Items.Count > 0)
            {
                cbPTTT.SelectedIndex = 0;
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                Payment payment = new Payment
                {
                    StudentId = studentId,
                    ReferenceId = classId,
                    Amount = amount,
                    PaymentType = paymentType,
                    TransactionDate = DateTime.Now,
                    PaymentMethod = cbPTTT.SelectedItem?.ToString() ?? "Tiền mặt"
                };
                PaymentBL paymentBL = new PaymentBL();
                paymentBL.AddPayment(payment);
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkQR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string soTien = txtSotien.Text;
            Form form = new QRThanhToan(soTien);
            form.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
