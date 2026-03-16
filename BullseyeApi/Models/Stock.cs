namespace BullseyeApi.Models
{
    public class Stock
    {
        public string Ticker { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public long MarketCap { get; set; }
        public string Sector { get; set; } = string.Empty;
    }
}