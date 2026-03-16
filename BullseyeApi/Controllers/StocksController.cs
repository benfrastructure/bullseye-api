using BullseyeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BullseyeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly StockService _stockService;

        public StocksController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public IActionResult GetAllStocks()
        {
            return Ok(_stockService.GetAllStocks());
        }

        [HttpGet("{ticker}")]
        public IActionResult GetStock(string ticker)
        {
            var stock = _stockService.GetStock(ticker);
            if (stock == null) return NotFound();
            return Ok(stock);
        }

        [HttpGet("{ticker}/history")]
        public IActionResult GetPriceHistory(string ticker)
        {
            return Ok(_stockService.GetPriceHistory(ticker));
        }
    }
}