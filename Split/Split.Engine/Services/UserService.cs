using Split.DbContexts.Tables;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;

namespace Split.Engine.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserService(IUserRepository userRepository,IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }
        public User? Authorize(string login, string password)
        {
            try
            {
                return userRepository.GetUser(login, password);
            }
            catch(UserNotFoundException)
            {
                return null;
            }
        }

        public User? Register(string login, string password, string email)
        {
            if(userRepository.IsUserExists(login)) throw new ServiceException("Такой пользователь уже есть");

            try
            {
                if (password is not { Length: > 6 } x || x.Contains('!'))
                {
                    throw new ServiceException("Not valid password");
                }
                var name = "не указано";
                return userRepository.Register(login, password, email,name);
            }
            catch (UserNotFoundException)
            {
                return null;
            }
        }

        public void DeleteUser(int Id)
        {
            userRepository.DeleteUser(Id);
        }

        public List<User> GetUsers()
        {
            var users = userRepository
                .GetUsers()
                .Select(user => new User
                {
                    Id = user.Id,
                    Password = user.Password,
                    Login = user.Login,
                    Email = user.Email,
                    Name = user.Name
                }).ToList(); 
            return users;
        }
        public User? GetUserById(int id)
        {
            try
            {
                return userRepository.GetUser(id);
            }
            catch (UserNotFoundException)
            {
                return null;
            }
        }

        public User? GetUserByLogin(string login)
        {
            try
            {
                return userRepository.GetUserByLogin(login);
            }
            catch(UserNotFoundException)
            {
                return null;
            }
        }

        public User? UpdateUserData(int id, string login, string email, string password)
        {
            try
            {
                return userRepository.UpdateUserData(id, login, email, password);
            }
            catch (UserNotFoundException)
            {
                return null;
            }

        }

        public Friend? GetFriend(int userId, int friendId)
        {
            try
            {
                return userRepository.GetFriend(userId, friendId);
            }
            catch (UserNotFoundException)
            {
                return null;
            }
        }

        public Friend? AddFriend(int userId, int friendId, bool request)
        {
            try
            {
                return userRepository.AddFriend(userId, friendId, request);
            }
            catch(UserNotFoundException)
            {
                return null;
            }
        }

        public void DeleteFriend(Guid id)
        {
            userRepository.DeleteFriend(id);
        }

        public List<Friend>? GetFriends(int userId)
        {
            try
            {
                var friends = userRepository.GetFriends(userId)
                     .Select(friend => new Friend
                     {
                         Id = friend.Id,
                         FriendId = friend.FriendId,
                         UserId = friend.UserId,
                         Request = friend.Request
                     }).ToList();

                return friends;
            }
            catch (FriendNotFoundException)
            {
                return null;
            }
        }
    }
}
