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
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTransfer(Transfer transfer)
        {
            try
            {
                var username = User.Identity.Name; // دریافت نام کاربر از توکن
                var addedTransfer = await _transferService.AddTransferAsync(transfer, username);
                return CreatedAtAction(nameof(GetTransfers), new { }, addedTransfer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTransfers()
        {
            try
            {
                var username = User.Identity.Name; // دریافت نام کاربر از توکن
                var transfers = await _transferService.GetTransfersAsync(username);
                return Ok(transfers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("Sender/{senderWalletId}")]
        public async Task<IActionResult> GetTransfersBySender(int senderWalletId)
        {
            try
            {
                var username = User.Identity.Name; // دریافت نام کاربر از توکن
                var transfers = await _transferService.GetTransfersBySenderAsync(senderWalletId, username);
                return Ok(transfers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("Receiver/{receiverWalletId}")]
        public async Task<IActionResult> GetTransfersByReceiver(int receiverWalletId)
        {
            try
            {
                var username = User.Identity.Name; // دریافت نام کاربر از توکن
                var transfers = await _transferService.GetTransfersByReceiverAsync(receiverWalletId, username);
                return Ok(transfers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
