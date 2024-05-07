using System.ComponentModel.DataAnnotations;

namespace WalletHub.Models
{
    public class LoginViewModel
    {
        public string? LoginUsername { get; set; }
        public string? LoginPassword { get; set; }
    }
}
