using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Exceptions
{
    public class GroupMembersNotFoundException : ServiceException
    {
        public GroupMembersNotFoundException() : base("Group members not found")
        {
        }
    }
}
