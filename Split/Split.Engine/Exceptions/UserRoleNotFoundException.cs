using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Exceptions
{
    public class UserRoleNotFoundException : ServiceException
    {
        public UserRoleNotFoundException() : base("Role for this user is not found")
        {
        }
    }
}
