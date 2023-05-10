using Split.DbContexts.Tables;
using Split.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        List<Groups> GetGroups();
        Group AddGroup(string name);

    }
}
