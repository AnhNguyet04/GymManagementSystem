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
using PresentationLayer.Helpers;

namespace PresentationLayer
{
    public partial class ChonHocVien : Form
    {
        private List<int> selectedClassId;
        public ChonHocVien(List<int> selectedClassId)
        {
            InitializeComponent();
            this.selectedClassId = selectedClassId;
            LoadStudents();
        }

        private void LoadStudents()
        {
            StudentsBL studentBL = new StudentsBL();
            dgvHocVien.DataSource = studentBL.GetAllStudents();
            DataGridViewStyleHelper.FormatStudentDGV(dgvHocVien);
            
            
            if (!dgvHocVien.Columns.Contains("SelectColumn"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "SelectColumn";
                chk.HeaderText = "Chọn";
                dgvHocVien.Columns.Insert(0, chk);
            }    
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Students_ClassBL studentsClassBL = new Students_ClassBL();
            bool anySuccess = false;
            bool hasSelection = false;

            foreach (DataGridViewRow studentRow in dgvHocVien.Rows)
            {
                if (Convert.ToBoolean(studentRow.Cells["SelectColumn"].Value))
                {
                    hasSelection = true;
                    int studentId = Convert.ToInt32(studentRow.Cells["StudentID"].Value);
                    foreach (int classId in selectedClassId)
                    {
                        try
                        {
                            int result = studentsClassBL.DangKyLop(studentId, classId);
                            if (result ==1 || result ==2)
                            {
                                anySuccess = true;
                            }    
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Học viên {studentId} - Lớp {classId}: {ex.Message}");
                        }
                    }    
                }
            }
            if (!hasSelection)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một học viên để thêm vào lớp.");
            }
            else if (anySuccess)
            {
                MessageBox.Show("Thêm học viên thành công.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Không thể thêm học viên nào vào lớp.");
            }
        }

        private void btTimKiemHVTrongLop_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            StudentsBL studentBL = new StudentsBL();
            var students = studentBL.GetAllStudents();
            var filtered = students.Where(s => s.FullName.ToLower().Contains(keyword)).ToList();
            dgvHocVien.DataSource = filtered;
        }

        private void btQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
