using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Exceptions
{
    public class FriendNotFoundException : ServiceException
    {
        public FriendNotFoundException() : base("Friend not found")
        {
        }
    }
}
