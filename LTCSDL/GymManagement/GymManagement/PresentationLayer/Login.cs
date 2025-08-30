using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PresentationLayer
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, password;
            username = txtUsername.Text.Trim();
            password = txtPassword.Text;
            Account acc = new Account(username, password);
            try
            {
                Account loggedInUser = new LoginBL().Login(acc);
                if (loggedInUser != null)
                {
                    UserSession.UserName = loggedInUser.Username;
                    UserSession.Role = loggedInUser.Role;
                    UserSession.UserId = loggedInUser.User_id;

                    this.DialogResult = DialogResult.OK; 
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Username and Password không chính xác!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lbClears_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOpenEyes_Click(object sender, EventArgs e)
        {
            if(txtPassword.PasswordChar=='*')
            {
                txtPassword.PasswordChar = '\0';
                btnOpenEyes.Visible = false;
                btnCloseEyes.Visible = true;
            }    
        }

        private void btnCloseEyes_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                //btnOpenEyes.BringToFront();
                txtPassword.PasswordChar = '*';
               // txtPassword.UseSystemPasswordChar = true;
                btnOpenEyes.Visible = true;
                btnCloseEyes.Visible = false;
            }
        }

    }
}

