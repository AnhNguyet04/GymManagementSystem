using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
   public class ThietBiDL:DataProvider
    {
        public List<Equipment> XemTatCaThietBi()
        {
            List<Equipment> list = new List<Equipment>();
            string sql = @"
            SELECT e.Equipment_id, e.Name, e.Type, e.Purchase_date, e.Status, g.Gym_id, g.Gym_name
            FROM Equipment e
            INNER JOIN Gyms g ON e.Gym_id = g.Gym_id";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Equipment eq = new Equipment
                    {
                        EquipmentId = Convert.ToInt32(reader["Equipment_id"]),
                        Name = reader["Name"].ToString(),
                        Type = reader["Type"].ToString(),
                        PurchaseDate = Convert.ToDateTime(reader["Purchase_date"]),
                        Status = reader["Status"].ToString(),
                        GymId = Convert.ToInt32(reader["Gym_id"]),
                        GymName = reader["Gym_name"].ToString()
                    };
                    list.Add(eq);
                }
                reader.Close();
                return list;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        private int ExecuteEquipmentProc(string procedure, Equipment eq)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (procedure.Equals("uspUpdateEquipment", StringComparison.OrdinalIgnoreCase))
            {
                parameters.Add(new SqlParameter("@EquipmentId", eq.EquipmentId));
            }

            parameters.Add(new SqlParameter("@Name", eq.Name));
            parameters.Add(new SqlParameter("@Type", eq.Type));
            parameters.Add(new SqlParameter("@PurchaseDate", eq.PurchaseDate));
            parameters.Add(new SqlParameter("@Status", eq.Status));
            parameters.Add(new SqlParameter("@GymId", eq.GymId));

            try
            {
                return MyExecuteNonQuery(procedure, CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int ThemThietBi(Equipment eq)
        {
            return ExecuteEquipmentProc("uspAddEquipment", eq);
        }
        public int CapNhatThietBi(Equipment eq)
        {
            return ExecuteEquipmentProc("uspUpdateEquipment", eq);
        }
        public bool XoaThietBi(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@EquipmentId", id)
            };
            return MyExecuteNonQuery("uspDeleteEquipment", CommandType.StoredProcedure, parameters) > 0;
        }

        public List<Gym> GetActiveGyms()
        {
            List<Gym> gyms = new List<Gym>();
            string sql = "SELECT Gym_id, Gym_name FROM Gyms WHERE Status = N'Đang hoạt động'";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gyms.Add(new Gym
                    {
                        GymId = Convert.ToInt32(reader["Gym_id"]),
                        GymName = reader["Gym_name"].ToString()
                    });
                }
                reader.Close();
                return gyms;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách phòng gym: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public bool CapNhatTinhTrangThietBi(int equipmentId, string status)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@EquipmentId", equipmentId),
                new SqlParameter("@Status", status)
            };

            try
            {
                return MyExecuteNonQuery("uspCapNhatTinhTrangThietBi", CommandType.StoredProcedure, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật tình trạng thiết bị: " + ex.Message);
            }
        }
        public List<Equipment> TimKiemThietBi(string tuKhoa, string kieuTim)
        {
            List<Equipment> list = new List<Equipment>();
            string sql = @"
        SELECT e.Equipment_id, e.Name, e.Type, e.Purchase_date, e.Status, e.Gym_id, g.Gym_name
        FROM Equipment e
        INNER JOIN Gyms g ON e.Gym_id = g.Gym_id";

            kieuTim = kieuTim.ToLower();

            // Kiểm tra kiểu tìm kiếm và thêm điều kiện tương ứng
            if (kieuTim == "ten")
                sql += " WHERE e.Name LIKE @TuKhoa";
            else if (kieuTim == "loai")
                sql += " WHERE e.Type LIKE @TuKhoa";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Equipment
                    {
                        EquipmentId = Convert.ToInt32(reader["Equipment_id"]),
                        Name = reader["Name"].ToString(),
                        Type = reader["Type"].ToString(),
                        PurchaseDate = Convert.ToDateTime(reader["Purchase_date"]),
                        Status = reader["Status"].ToString(),
                        GymId = Convert.ToInt32(reader["Gym_id"]),
                        GymName = reader["Gym_name"].ToString()
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm thiết bị: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
