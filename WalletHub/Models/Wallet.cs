using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace WalletHub.Models
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public decimal BlockedBalance { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        public ICollection<Transfer>? SentTransactions { get; set; }
        public ICollection<Transfer>? ReceivedTransactions { get; set; }
    }
}
