using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;
using Split.DbContexts;
using Split.Engine.Exceptions;
using Split.DbContexts.Tables;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace Split.Engine.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<SplitDbContext> contextFactory;

        public UserRepository(IDbContextFactory<SplitDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public List<Users> GetUsers()
        {
            using var context = contextFactory.CreateDbContext();
            var users = context.Users.ToList();
            if (users == null)
            {
                throw new UserNotFoundException();
            }
            return users;
        }
        public User GetUser(string login,string password)
        {
            using var context = contextFactory.CreateDbContext();
            var users = context.Users.Where(p => p.Login == login && p.Password == password).FirstOrDefault();
            if (users == null)
            {
                throw new UserNotFoundException();
            }
            var user = new User
            {
                Id = users.Id,
                Password = users.Password,
                Login = users.Login,
                Email = users.Email,
                Name = users.Name
            };
            return user;
        }
        public User GetUser(int id)
        {
            using var context = contextFactory.CreateDbContext();
            var users = context.Users.Where(p => p.Id == id).FirstOrDefault();
            if (users == null)
            {
                throw new UserNotFoundException();
            }
            var user = new User
            {
                Id = users.Id,
                Password = users.Password,
                Login = users.Login,
                Email = users.Email,
                Name = users.Name
            };
            return user;
        }

        public bool IsUserExists(string login)
        {
            using var context = contextFactory.CreateDbContext();
            var user = context.Users.Where(p => p.Login == login).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
        }
        public List<string> GetUserRoles(int userId)
        {
            using var context = contextFactory.CreateDbContext();
            var roles = context.UserRoles.Where(p => p.UserId == userId).Select(p => p.Roles.Name).ToList();
            if (roles == null)
            {
                throw new UserNotFoundException();
            }
            return roles;
        }

        public User Register(string login, string password)
        {
            using var context = contextFactory.CreateDbContext();
            Users user = new Users
            {
                Login = login,
                Password = password
            };
            context.Users.Add(user);
            context.SaveChanges();
            return GetUser(login, password);
        }
        public void DeleteUser(int Id)
        {
            using var context = contextFactory.CreateDbContext();
            var user = context.Users.Where(x => x.Id == Id).FirstOrDefault() ?? throw new UserNotFoundException();
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
