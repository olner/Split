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
        public User GetUserByLogin(string login);
        bool IsUserExists(string login);
        User Register(string login, string password, string email, string name);
        void DeleteUser(int Id);
        List<string> GetUserRoles(int userId);
        User GetUser(int id);
        Friend GetFriend(int userId, int friendId);
        Friend AddFriend(int userId, int friendId, bool request);
        void DeleteFriend(Guid id);
        List<Friends> GetFriends(int userId);

    }
}
