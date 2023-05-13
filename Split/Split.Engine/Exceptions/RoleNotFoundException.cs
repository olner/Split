using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Exceptions
{
    public class RoleNotFoundException : ServiceException
    {
        public RoleNotFoundException(string roleName = null) : base($"Role {roleName} not found")
        {
        }
    }
}
