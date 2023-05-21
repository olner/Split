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

        public User Register(string login, string password, string email, string name)
        {
            using var context = contextFactory.CreateDbContext();
            Users user = new Users
            {
                Login = login,
                Password = password,
                Email = email,
                Name = name
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

        public Friend GetFriend(int userId,int friendId)
        {
            using var context = contextFactory.CreateDbContext();
            var friends = context.Friends.Where(x => x.UserId == userId && x.FriendId == friendId).FirstOrDefault() ?? throw new UserNotFoundException();

            var friend = new Friend
            {
                Id = friends.Id,
                UserId = friends.UserId,
                FriendId = friends.FriendId,
                Request = friends.Request
            };
            return friend;
        }

        public List<Friends> GetFriends(int userId)
        {
            using var context = contextFactory.CreateDbContext();
            var friends = context.Friends.Where(x => x.UserId == userId || x.FriendId == userId).ToList();
            if (friends.Count == 0) throw new FriendNotFoundException();

            return friends;
        }

        public Friend AddFriend(int userId, int friendId, bool request)
        {
            using var context = contextFactory.CreateDbContext();
            var friend = new Friends
            {
                Id = new Guid(),
                UserId = userId, 
                FriendId = friendId,
                Request = request
            };
            context.Friends.Add(friend);
            context.SaveChanges();

            return GetFriend(userId, friendId);
        }

        public void DeleteFriend(Guid id)
        {
            using var context = contextFactory.CreateDbContext();
            var friend = context.Friends.Where(x => x.Id == id).FirstOrDefault() ?? throw new UserNotFoundException();

            context.Friends.Remove(friend);
            context.SaveChanges();
        }
    }
}
