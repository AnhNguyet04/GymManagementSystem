using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class MembershipBL
    {
        public List<Membership> GetMemberships(int studentId)
        {
            return new MembershipDL().GetMemberships(studentId);
        }
    }
}
