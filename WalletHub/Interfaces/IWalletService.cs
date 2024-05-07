using WalletHub.Models;

namespace WalletHub.Interfaces
{
    public interface IWalletService
    {
        Task<Wallet?> GetWalletByIdAsync(int walletId, string username);
        Task<IEnumerable<Wallet>> GetWalletsByUserIdAsync(int userId, string username);
        Task AddWalletAsync(Wallet wallet, string username);
        Task UpdateWalletAsync(Wallet wallet, string username);
        Task DeleteWalletAsync(int walletId, string username);
    }
}
