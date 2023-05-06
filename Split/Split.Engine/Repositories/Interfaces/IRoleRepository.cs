using Split.DbContexts.Tables;
using Split.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        List<Roles> GetRoles();
        Role GetRole(string roleName);
        bool IsRoleExists(string roleName);
        void SetRole(int roleId, int userId);
        void RemoveRole(int roleId, int userId);
        int GetRoleId(string roleName);
        Role AddRole(string name, string description);
        void DeleteRole(string name);
    }
}
