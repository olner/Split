using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;
using Split.DbContexts;
using Split.Engine.Exceptions;
using Split.DbContexts.Tables;

namespace Split.Engine.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<Users> GetUsers()
        {
            using var context = new SplitDbContextFactory().CreateDbContext(null);
            var users = context.Users.ToList();
            if (users == null)
            {
                throw new UserNotFoundException();
            }
            return users;
        }
        public User GetUser(string login,string password)
        {
            using var context = new SplitDbContextFactory().CreateDbContext(null);
            var users = context.Users.Where(p => p.Login == login && p.Password == password).FirstOrDefault();
            if (users == null)
            {
                throw new UserNotFoundException();
            }
            var user = new User
            {
                Id = users.Id,
                Password = users.Password,
                Login = users.Login
            };
            return user;
        }
        public User GetUser(int id)
        {
            using var context = new SplitDbContextFactory().CreateDbContext(null);
            var users = context.Users.Where(p => p.Id == id).FirstOrDefault();
            if (users == null)
            {
                throw new UserNotFoundException();
            }
            var user = new User
            {
                Id = users.Id,
                Password = users.Password,
                Login = users.Login
            };
            return user;
        }

        public bool IsUserExists(string login)
        {
            using var context = new SplitDbContextFactory().CreateDbContext(null);
            var user = context.Users.Where(p => p.Login == login).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public User Register(string login, string password)
        {
            using var context = new SplitDbContextFactory().CreateDbContext(null);
            Users user = new Users
            {
                Login = login,
                Password = password
            };
            context.Users.Add(user);
            context.SaveChanges();
            return GetUser(login, password);
        }

    }
}
