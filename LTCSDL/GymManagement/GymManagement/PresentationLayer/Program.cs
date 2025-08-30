using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GymManagemet()); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Login login = new Login();
            //if (login.ShowDialog() == DialogResult.OK)
            //{
            //    GymManagemet mainForm = new GymManagemet();
            //    Application.Run(mainForm);
            //}
            while (true)
            {
                Login login = new Login();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    GymManagemet mainForm = new GymManagemet();
                    mainForm.ShowDialog();

                    if (mainForm.isDangXuat) // gắn cờ khi người dùng chọn đăng xuất
                    {
                        UserSession.Clear();
                        continue; // quay lại vòng lặp để hiển thị Login mới
                    }
                    else
                    {
                        break; // thoát khỏi vòng lặp => thoát app
                    }
                }
                else
                {
                    break; // đóng form login => thoát app
                }
            }
        }



    }
}
