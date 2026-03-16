namespace BullseyeApi.Models
{
    public class Holding
    {
        public string Ticker { get; set; } = string.Empty;
        public decimal Shares { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}