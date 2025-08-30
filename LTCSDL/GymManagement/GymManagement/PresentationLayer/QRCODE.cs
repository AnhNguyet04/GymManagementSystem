using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class QRCODE : Form
    {
        public QRCODE(Image qrImage)
        {
            InitializeComponent();
            this.Text = "VietQR Payment";
            picQR.Image = qrImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
