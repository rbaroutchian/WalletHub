using Microsoft.EntityFrameworkCore;
using WalletHub.Data;
using WalletHub.Interfaces;
using WalletHub.Models;

namespace WalletHub.Repository
{
    public class WalletRepository:IWalletRepository
    {
        private readonly WalletHubDbContext _context;

        public WalletRepository(WalletHubDbContext context)
        {
            _context = context;
        }

        public async Task<Wallet?> GetWalletByIdAsync(int walletId)
        {
            return await _context.Wallets.FindAsync(walletId);
        }

        public async Task<IEnumerable<Wallet>> GetWalletsByUserIdAsync(int userId)
        {
            return await _context.Wallets.Where(w => w.UserId == userId).ToListAsync();
        }

        public async Task AddWalletAsync(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWalletAsync(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWalletAsync(int walletId)
        {
            var wallet = await _context.Wallets.FindAsync(walletId);
            if (wallet != null)
            {
                _context.Wallets.Remove(wallet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
