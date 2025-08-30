using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProvider
    {
        public SqlConnection cn;

        public DataProvider()
        {
            string cnstr = "Data Source=LAPTOP-UVGQT3A6\\ANHNGUYET;Initial Catalog=QLGym;Integrated Security=True";
            cn = new SqlConnection(cnstr);
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=LAPTOP-UVGQT3A6\\ANHNGUYET;Initial Catalog=QLGym;Integrated Security=True");
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void DisConnect()
        {

            if (cn != null && cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }

        }
        public SqlDataReader MyExecuteReader(string sql, CommandType type, SqlParameter[] parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            try
            {
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public object MyExcuteScalar(string sql, CommandType type)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            Connect();
            try
            {
                return (cmd.ExecuteScalar());
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
        public int MyExecuteNonQuery(string sql, CommandType type, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            if (parameters !=null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }    
            }
            try
            {
                Connect();
                return (cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally { DisConnect();}
        }
        public DataTable MyExecuteDataTable(string sql, CommandType commandType)
        {
            DataTable dt = new DataTable();
            Connect();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = commandType;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            finally
            {
                DisConnect();
            }
            return dt;
        }


    }
}
