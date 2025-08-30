using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Web.Security;

namespace DataLayer
{
    public class ThongKeDL: DataProvider
    {
        public List<StudentCountByCategory> GetStudentCountByCategory()
        {
            List<StudentCountByCategory> list = new List<StudentCountByCategory>();
            string sql = "SELECT c.Category_name, COUNT(sc.Student_id) AS StudentCount " +
                " FROM Student_Classes sc " +
                " JOIN Classes cls ON sc.Class_id = cls.Class_id " +
                " JOIN Categories c ON cls.Category = c.Category_id " +
                " GROUP BY c.Category_name ";
            Connect();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(sql, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        StudentCountByCategory item = new StudentCountByCategory
                        {
                            CategoryName = reader["Category_name"].ToString(),
                            StudentCount = Convert.ToInt32(reader["StudentCount"])
                        };
                        list.Add(item);
                    }
                }    
            }
            finally
            {
                DisConnect();
            }
            return list;
        }
        public DataTable GetStudentCountByMonth()
        {
            string sql = @"SELECT 
                      MONTH(RegisteredDate) AS Thang,
                      COUNT(*) AS SoLuong
                  FROM Students
                  GROUP BY MONTH(RegisteredDate)
                  ORDER BY Thang";

            return MyExecuteDataTable(sql, CommandType.Text);
        }
        public DataTable GetDoanhThuTheoThang()
        {
            string sql = @"
        SELECT 
            MONTH(Transaction_date) AS Thang,
            SUM(Amount) AS DoanhThu
        FROM Payment
        WHERE Payment_type = 'Class'
        GROUP BY MONTH(Transaction_date)
        ORDER BY Thang";

            return MyExecuteDataTable(sql, CommandType.Text);
        }
        public DataTable GetTiLeMembershipPackage()
        {
            string sql = @"
        SELECT Package_type, COUNT(*) AS SoLuong
        FROM Memberships
        GROUP BY Package_type
    ";
            return MyExecuteDataTable(sql, CommandType.Text);
        }

        
    }
}
