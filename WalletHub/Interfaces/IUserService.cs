using Microsoft.AspNetCore.Mvc;
using WalletHub.Models;

namespace WalletHub.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int userId, string username);
        Task<User> GetByUsernameAsync(string Username, string username);
        Task<User> AddAsync(User user, string username);
        Task UpdateAsync(User user, string username);
        Task DeleteAsync(int userId, string username);

    }
}
