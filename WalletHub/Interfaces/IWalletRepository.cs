using WalletHub.Models;

namespace WalletHub.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet?> GetWalletByIdAsync(int walletId);
        Task<IEnumerable<Wallet>> GetWalletsByUserIdAsync(int userId);
        Task AddWalletAsync(Wallet wallet);
        Task UpdateWalletAsync(Wallet wallet);
        Task DeleteWalletAsync(int walletId);
    }
}
