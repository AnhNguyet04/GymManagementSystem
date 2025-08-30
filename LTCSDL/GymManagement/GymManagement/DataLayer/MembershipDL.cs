using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class MembershipDL : DataProvider
    {
        public List<Membership> GetMemberships(int studentId)
        {
            List<Membership> memberships = new List<Membership>();
            string sql = "SELECT * FROM Memberships WHERE Student_id = @StudentId";
            Connect();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql,cn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Membership membership = new Membership
                            {
                                MembershipId = Convert.ToInt32(reader["Membership_id"]),
                                StudentId = Convert.ToInt32(reader["Student_id"]),
                                Packagetype = reader["Package_type"].ToString(),
                                Startdate = Convert.ToDateTime(reader["Start_date"]),
                                Enddate = Convert.ToDateTime(reader["End_date"]),
                                Price = Convert.ToDecimal(reader["Price"])
                            };
                            memberships.Add(membership);
                        }
                    }    
                }    
            }
            finally
            {
                DisConnect();
            }
            return memberships;
        }
    }
}
