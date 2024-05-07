using Microsoft.AspNetCore.Identity;
using WalletHub.Interfaces;
using WalletHub.Models;

namespace WalletHub.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ILoginService _loginService;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, ILoginService loginService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _loginService = loginService;
        }

        public async Task<User> GetByIdAsync(int userId, string username)
        {
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<User> GetByUsernameAsync(string Username, string username)
        {
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }
            return await _userRepository.GetByUsernameAsync(username);
        }

        

          
        

        public async Task UpdateAsync(User user, string username)
        {
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int userId, string username)
        {
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user);
            }
        }

        public async Task<User> AddAsync(User user,string username)
        {
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }
            await _userRepository.AddAsync(user);

            return user;
        }
    }
}
