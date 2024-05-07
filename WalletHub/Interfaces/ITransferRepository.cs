using WalletHub.Models;

namespace WalletHub.Interfaces
{
    public interface ITransferRepository
    {
        Task<Transfer> AddTransferAsync(Transfer transfer);
        Task<IEnumerable<Transfer>> GetTransfersAsync();
        Task<IEnumerable<Transfer>> GetTransfersBySenderAsync(int senderWalletId);
        Task<IEnumerable<Transfer>> GetTransfersByReceiverAsync(int receiverWalletId);
    }
}
