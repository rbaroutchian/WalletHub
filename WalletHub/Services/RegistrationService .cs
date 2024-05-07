using WalletHub.Data;
using WalletHub.Interfaces;
using WalletHub.Models;

namespace WalletHub.Services
{
    public class RegistrationService:IRegistrationService
    {
        private readonly WalletHubDbContext _context;

        public RegistrationService(WalletHubDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                // Add the user to the database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Handle exception if necessary
                return false;
            }
        }
    }
}
