using WalletHub.Interfaces;
using WalletHub.Models;

namespace WalletHub.Services
{
    public class TransferService:ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly ILoginService _loginService;


        public TransferService(ITransferRepository transferRepository, ILoginService loginService)
        {
            _transferRepository = transferRepository;
            _loginService = loginService;
        }

        public async Task<Transfer> AddTransferAsync(Transfer transfer,string username)
        {
            // Additional business logic can be added here if needed
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }
            return await _transferRepository.AddTransferAsync(transfer);
        }

        public async Task<IEnumerable<Transfer>> GetTransfersAsync(string username)
        {
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }
            return await _transferRepository.GetTransfersAsync();
        }

        public async Task<IEnumerable<Transfer>> GetTransfersBySenderAsync(int senderWalletId, string username)
        {
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }
            return await _transferRepository.GetTransfersBySenderAsync(senderWalletId);
        }

        public async Task<IEnumerable<Transfer>> GetTransfersByReceiverAsync(int receiverWalletId, string username)
        {
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }
            return await _transferRepository.GetTransfersByReceiverAsync(receiverWalletId);
        }
    }
}
