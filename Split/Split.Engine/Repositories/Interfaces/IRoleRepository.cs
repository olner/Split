using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        void AddRole(int roleId, int userId);
        void RemoveRole(int roleId, int userId);
        List<string> GetUserRoles(int userId);
        int GetRoleId(string roleName);
    }
}
