using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class CategoryBL
    {
        public List<Category> GetAllCategories()
        {
            return new CategoryDL().GetAllCategories();
        }
    }
}
