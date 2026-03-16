using BullseyeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BullseyeApi.Controllers
{
    public record BuyRequest(string Ticker, decimal Shares, decimal Price);
    public record SellRequest(string Ticker, decimal Shares, decimal Price);

    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly PortfolioService _portfolioService;

        public PortfolioController(PortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        public IActionResult GetPortfolio()
        {
            return Ok(new
            {
                Holdings = _portfolioService.GetHoldings(),
                CashBalance = _portfolioService.GetCashBalance()
            });
        }

        [HttpPost("buy")]
        public IActionResult BuyShares([FromBody] BuyRequest request)
        {
            var success = _portfolioService.BuyShares(request.Ticker, request.Shares, request.Price);
            if (!success) return BadRequest("Insufficient funds.");
            return Ok();
        }

        [HttpPost("sell")]
        public IActionResult SellShares([FromBody] SellRequest request)
        {
            var success = _portfolioService.SellShares(request.Ticker, request.Shares, request.Price);
            if (!success) return BadRequest("Unable to sell shares.");
            return Ok();
        }

        [HttpGet("history")]
        public IActionResult GetValueHistory()
        {
            return Ok(_portfolioService.GetValueHistory());
        }
    }
}