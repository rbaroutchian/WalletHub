using WalletHub.Interfaces;
using WalletHub.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WalletHub.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ILoginService _loginService;

        public WalletService(IWalletRepository walletRepository, ILoginService loginService)
        {
            _walletRepository = walletRepository;
            _loginService = loginService;
        }

        public async Task<Wallet?> GetWalletByIdAsync(int walletId, string username)
        {
            // اعتبارسنجی توکن
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }

            return await _walletRepository.GetWalletByIdAsync(walletId);
        }

        public async Task<IEnumerable<Wallet>> GetWalletsByUserIdAsync(int userId, string username)
        {
            // اعتبارسنجی توکن
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }

            return await _walletRepository.GetWalletsByUserIdAsync(userId);
        }

        public async Task AddWalletAsync(Wallet wallet, string username)
        {
            // اعتبارسنجی توکن
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }

            await _walletRepository.AddWalletAsync(wallet);
        }

        public async Task UpdateWalletAsync(Wallet wallet, string username)
        {
            // اعتبارسنجی توکن
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }

            await _walletRepository.UpdateWalletAsync(wallet);
        }

        public async Task DeleteWalletAsync(int walletId, string username)
        {
            // اعتبارسنجی توکن
            if (!_loginService.Authenticate(username))
            {
                throw new UnauthorizedAccessException("Authentication failed.");
            }

            await _walletRepository.DeleteWalletAsync(walletId);
        }
    }
}
