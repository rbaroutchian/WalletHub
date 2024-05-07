using WalletHub.Models;

namespace WalletHub.Interfaces
{
    public interface ITransferService
    {
        Task<Transfer> AddTransferAsync(Transfer transfer, string username);
        Task<IEnumerable<Transfer>> GetTransfersAsync(string username);
        Task<IEnumerable<Transfer>> GetTransfersBySenderAsync(int senderWalletId, string username);
        Task<IEnumerable<Transfer>> GetTransfersByReceiverAsync(int receiverWalletId, string username);
    }
}
