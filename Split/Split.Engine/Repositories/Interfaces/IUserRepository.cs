using Split.DbContexts.Tables;
using Split.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<Users> GetUsers();
        User GetUser(string login, string password);
        bool IsUserExists(string login);
        User Register(string login, string password);
        User GetUser(int id);
        
    }
}
