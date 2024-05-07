using Microsoft.EntityFrameworkCore;
using WalletHub.Data;
using WalletHub.Interfaces;
using WalletHub.Models;

namespace WalletHub.Repository
{
    public class TransferRepository: ITransferRepository
    {
        private readonly WalletHubDbContext _context;

        public TransferRepository(WalletHubDbContext context)
        {
            _context = context;
        }

        public async Task<Transfer> AddTransferAsync(Transfer transfer)
        {
            _context.Transactions.Add(transfer);
            await _context.SaveChangesAsync();
            return transfer;
        }

        public async Task<IEnumerable<Transfer>> GetTransfersAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<IEnumerable<Transfer>> GetTransfersBySenderAsync(int senderWalletId)
        {
            return await _context.Transactions.Where(t => t.SenderWalletId == senderWalletId).ToListAsync();
        }

        public async Task<IEnumerable<Transfer>> GetTransfersByReceiverAsync(int receiverWalletId)
        {
            return await _context.Transactions.Where(t => t.ReceiverWalletId == receiverWalletId).ToListAsync();
        }
    }
}
