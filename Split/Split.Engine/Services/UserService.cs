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

        public User? Register(string login, string password)
        {
            if(userRepository.IsUserExists(login)) throw new ServiceException("Такой пользователь уже есть");

            try
            {
                if (password is not { Length: > 6 } x || x.Contains('!'))
                {
                    throw new ServiceException("Not valid password");
                }
                return userRepository.Register(login, password);
            }
            catch (UserNotFoundException)
            {
                return null;
            }
        }

        public void SetRole(int userId,string roleName)
        {
            var roles = roleRepository.GetUserRoles(userId);
            foreach(var role in roles)
            {
                if (role == roleName) throw new ServiceException("User already have this role");
            }
            try
            {
                roleRepository.AddRole(roleRepository.GetRoleId(roleName), userId);
            }
            catch (RoleNotFoundException)
            {

            } 
        }
    }
}
