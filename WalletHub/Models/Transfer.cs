using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletHub.Models
{
    public class Transfer
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("SenderWallet")]
        public int SenderWalletId { get; set; }
        public Wallet? SenderWallet { get; set; }

        [ForeignKey("ReceiverWallet")]
        public int ReceiverWalletId { get; set; }
        public Wallet? ReceiverWallet { get; set; }
    }
}
