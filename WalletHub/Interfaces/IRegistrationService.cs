using WalletHub.Models;

namespace WalletHub.Interfaces
{
    public interface IRegistrationService
    {
        Task<bool> RegisterAsync(User user);

    }
}
