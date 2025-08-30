using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data;

namespace DataLayer
{
    public class CategoryDL: DataProvider
    {
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            string sql = "SELECT * FROM Categories";
            Connect();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(sql, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            CategoryId = Convert.ToInt32(reader["Category_id"]),
                            CategoryName = reader["Category_name"].ToString()
                        };
                        categories.Add(category);
                    }
                }    
            }
            finally
            {

                DisConnect();
            }
            return categories;
        }
    }
}
