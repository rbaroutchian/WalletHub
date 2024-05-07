using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletHub.Interfaces;
using WalletHub.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WalletHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("{walletId}")]
        public async Task<IActionResult> GetWalletById(int walletId)
        {
            try
            {
                var username = User.Identity.Name; // دریافت نام کاربر از توکن
                var wallet = await _walletService.GetWalletByIdAsync(walletId, username);
                if (wallet == null)
                {
                    return NotFound("Wallet not found");
                }

                return Ok(wallet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetWalletsByUserId(int userId)
        {
            try
            {
                var username = User.Identity.Name; // دریافت نام کاربر از توکن
                var wallets = await _walletService.GetWalletsByUserIdAsync(userId, username);
                if (wallets == null)
                {
                    return NotFound("Wallets not found");
                }

                return Ok(wallets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddWallet(Wallet wallet)
        {
            try
            {
                var username = User.Identity.Name; // دریافت نام کاربر از توکن
                await _walletService.AddWalletAsync(wallet, username);
                return CreatedAtAction(nameof(GetWalletById), new { walletId = wallet.WalletId }, wallet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{walletId}")]
        public async Task<IActionResult> UpdateWallet(int walletId, Wallet wallet)
        {
            try
            {
                var username = User.Identity.Name; // دریافت نام کاربر از توکن
                await _walletService.UpdateWalletAsync(wallet, username);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{walletId}")]
        public async Task<IActionResult> DeleteWallet(int walletId)
        {
            try
            {
                var username = User.Identity.Name; // دریافت نام کاربر از توکن
                await _walletService.DeleteWalletAsync(walletId, username);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
