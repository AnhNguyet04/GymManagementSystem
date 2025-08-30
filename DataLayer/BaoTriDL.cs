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
    public class BaoTriDL:DataProvider
    {
        public List<Maintenance> LayDanhSachBaoTriTongHop(int dinhKyBaoTriNgay)
        {
            List<Maintenance> list = new List<Maintenance>();
            string sql = @" SELECT e.Equipment_id, e.Name AS TenThietBi,
            MAX(CASE WHEN m.Status = N'Đang bảo trì' THEN m.Date ELSE NULL END) AS LichDuDinhBaoTri, -- Lịch dự định bảo trì (Đang bảo trì)
            MAX(CASE WHEN m.Status = N'Đã hoàn thành' THEN m.ActualMaintenanceDate ELSE NULL END) AS BaoTriGanNhat, -- Bảo trì gần nhất
            MAX(CASE WHEN m.Status = N'Đã hoàn thành' THEN m.NextMaintenanceDate ELSE NULL END) AS DuKienBaoTriKeTiep,
            e.Status
            FROM Equipment e
            LEFT JOIN Maintenance m ON e.Equipment_id = m.Equipment_id
            GROUP BY e.Equipment_id, e.Name, e.Status";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Maintenance
                    {
                        EquipmentId = reader.GetInt32(0),
                        EquipmentName = reader.GetString(1),
                        MaintenanceDate = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2), // Lịch dự định
                        ActualMaintenanceDate = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3), // Bảo trì gần nhất
                        NextMaintenanceDate = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4), // Bảo trì kế tiếp
                        Status = reader.GetString(5)
                    });
                }
            }
            finally
            {
                DisConnect();
            }
            return list;

        }

        // Lịch sử bảo trì cho thiết bị
        public List<Maintenance> LayLichSuBaoTriTheoThietBi(int equipmentId)
        {
            List<Maintenance> list = new List<Maintenance>();
            string sql = @"
            SELECT Maintenance_id, Equipment_id, Date AS MaintenanceDate, Status, ActualMaintenanceDate, NextMaintenanceDate 
            FROM Maintenance
            WHERE Equipment_id = @id
            ORDER BY Date DESC";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", equipmentId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Maintenance m = new Maintenance();
                    m.MaintenanceId = Convert.ToInt32(reader["Maintenance_id"]);
                    m.EquipmentId = Convert.ToInt32(reader["Equipment_id"]);
                    m.MaintenanceDate = reader["MaintenanceDate"] as DateTime?;
                    m.Status = reader["Status"].ToString();
                    m.ActualMaintenanceDate = reader["ActualMaintenanceDate"] != DBNull.Value? Convert.ToDateTime(reader["ActualMaintenanceDate"]): (DateTime?)null;
                    m.NextMaintenanceDate = reader["NextMaintenanceDate"] != DBNull.Value? Convert.ToDateTime(reader["NextMaintenanceDate"]): (DateTime?)null;

                    list.Add(m);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy lịch sử bảo trì: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return list;
        }
        public bool ThemBaoTri(int equipmentId, DateTime date, string status)
        {
            string sql = "INSERT INTO Maintenance (Equipment_id, Date, Status) VALUES (@eid, @date, @status)";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@eid", equipmentId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@status", status);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm bảo trì: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
        public bool HoanTatBaoTri(int maintenanceId)
        {
            string sql = @"UPDATE Maintenance 
           SET Status = N'Đã hoàn thành', 
               ActualMaintenanceDate = @today,
               NextMaintenanceDate = DATEADD(MONTH, 6, @today)
           WHERE Maintenance_id = @id";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", maintenanceId);
                cmd.Parameters.AddWithValue("@today", DateTime.Now);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("Không tìm thấy Maintenance_id phù hợp.");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi hoàn tất bảo trì: " + ex.Message);
                //return false;
            }
            finally
            {
                DisConnect();
            }
        }
        public bool KiemTraTrungLichBaoTri(int equipmentId, DateTime date)
        {
            string sql = @"SELECT COUNT(*) 
                   FROM Maintenance 
                   WHERE Equipment_id = @eid AND Date = @date";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@eid", equipmentId);
                cmd.Parameters.AddWithValue("@date", date);

                int count = (int)cmd.ExecuteScalar();
                return count > 0; // true nếu đã có lịch trùng
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra lịch bảo trì: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
        public bool XoaBaoTri(int maintenanceId)
        {
            string sql = @"DELETE FROM Maintenance WHERE Maintenance_id = @id";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", maintenanceId);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa lịch sử bảo trì: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
        public bool CapNhatTinhTrangThietBi(int equipmentId, string newStatus)
        {
            string sql = "UPDATE Equipment SET Status = @status WHERE Equipment_id = @eid";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@eid", equipmentId);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật tình trạng thiết bị: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
