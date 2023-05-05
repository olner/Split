using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Exceptions
{
    public class UserNotFoundException : ServiceException
    {
        public UserNotFoundException() : base("User not found")
        {

        }
    }
}
