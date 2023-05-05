using Split.Engine.Repositories.Interfaces;
using Split.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Services
{
    public class RoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public List<Role> GetRoles()
        {

        }
        public Role GetRole(int id)
        {

        }
        public Role AddRole()
        {

        }
        public void DeleteRole(int id)
        {

        }
    }
}
