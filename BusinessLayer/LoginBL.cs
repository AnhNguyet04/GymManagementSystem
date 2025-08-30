using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class LoginBL
    {
        public Account Login(Account acc)
        {
            try
            {
                return (new LoginDL().Login(acc));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
