using Microsoft.EntityFrameworkCore;
using WalletHub.Models;

namespace WalletHub.Data
{
    public class WalletHubDbContext : DbContext
    {
        public WalletHubDbContext(DbContextOptions<WalletHubDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transfer> Transactions { get; set; }
        public DbSet<LoginViewModel> login { get; set; }
        public DbSet<RegisterViewModel> register { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تعریف روابط بین مدل‌ها

            // یک کاربر می‌تواند چندین کیف پول داشته باشد
            modelBuilder.Entity<User>()
                .HasMany(u => u.Wallets)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete در صورت حذف یک کاربر، کیف‌های مرتبط حذف شوند

            // هر کیف پول می‌تواند چندین تراکنش فرستاده شده و دریافتی داشته باشد
            modelBuilder.Entity<Wallet>()
                .HasMany(w => w.SentTransactions)
                .WithOne(t => t.SenderWallet)
                .HasForeignKey(t => t.SenderWalletId)
                
                .OnDelete(DeleteBehavior.Restrict); // محدود کردن حذف تراکنش‌ها در صورت حذف کیف پول

            modelBuilder.Entity<Wallet>()
                .HasMany(w => w.ReceivedTransactions)
                .WithOne(t => t.ReceiverWallet)
                .HasForeignKey(t => t.ReceiverWalletId)
                
                .OnDelete(DeleteBehavior.Restrict); // محدود کردن حذف تراکنش‌ها در صورت حذف کیف پول

            modelBuilder.Entity<Transfer>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<LoginViewModel>().HasNoKey();
            modelBuilder.Entity<RegisterViewModel>().HasNoKey();


        }
    }
}
