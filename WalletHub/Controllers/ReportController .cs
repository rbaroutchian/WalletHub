using Microsoft.AspNetCore.Mvc;
using WalletHub.Data;

namespace WalletHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly WalletHubDbContext _context;

        public ReportController(WalletHubDbContext context)
        {
            _context = context;
        }

        // API برای دریافت لیست انتقال وجه‌ها
        [HttpGet("transactions")]
        public IActionResult GetTransactions()
        {
            var transactions = _context.Transactions.ToList();
            return Ok(transactions);
        }

        // API برای دریافت مقدار موجودی بلاک شده یک کاربر
        [HttpGet("blockedbalance/{userId}")]
        public IActionResult GetBlockedBalance(int userId)
        {
            var blockedBalance = _context.Wallets
                .Where(w => w.UserId == userId)
                .Select(w => w.BlockedBalance)
                .FirstOrDefault();

            if (blockedBalance == null)
            {
                return NotFound("Blocked balance not found");
            }

            return Ok(blockedBalance);
        }
    }
}