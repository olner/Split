﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Exceptions
{
    public class RoleNotFoundException : ServiceException
    {
        public RoleNotFoundException() : base("Role not found")
        {
        }
    }
}