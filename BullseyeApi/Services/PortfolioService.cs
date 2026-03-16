using BullseyeApi.Models;

namespace BullseyeApi.Services
{
    public class PortfolioService
    {
        private readonly List<Holding> _holdings = new();
        private decimal _cashBalance = 100000m;
        private readonly List<PortfolioValuePoint> _valueHistory = new();

        public List<Holding> GetHoldings() => _holdings;
        public decimal GetCashBalance() => _cashBalance;
        public List<PortfolioValuePoint> GetValueHistory() => _valueHistory;

        public void RecordValue(List<Stock> stocks)
        {
            var holdingsValue = _holdings.Sum(h =>
            {
                var stock = stocks.FirstOrDefault(s => s.Ticker == h.Ticker);
                return h.Shares * (stock?.Price ?? h.PurchasePrice);
            });

            var now = DateTime.Now;
            int time = now.Hour * 3600 + now.Minute * 60 + now.Second;

            _valueHistory.Add(new PortfolioValuePoint
            {
                Time = time,
                Value = holdingsValue + _cashBalance
            });
        }

        public bool BuyShares(string ticker, decimal shares, decimal price)
        {
            var cost = shares * price;
            if (cost > _cashBalance) return false;

            _cashBalance -= cost;
            _holdings.Add(new Holding
            {
                Ticker = ticker,
                Shares = shares,
                PurchasePrice = price
            });

            return true;
        }

        public bool SellShares(string ticker, decimal shares, decimal price)
        {
            decimal sharesToSell = shares;
            var updatedHoldings = new List<Holding>();

            foreach (var holding in _holdings)
            {
                if (holding.Ticker != ticker || sharesToSell <= 0)
                {
                    updatedHoldings.Add(holding);
                    continue;
                }
                if (holding.Shares <= sharesToSell)
                {
                    sharesToSell -= holding.Shares;
                }
                else
                {
                    updatedHoldings.Add(new Holding
                    {
                        Ticker = holding.Ticker,
                        Shares = holding.Shares - sharesToSell,
                        PurchasePrice = holding.PurchasePrice
                    });
                    sharesToSell = 0;
                }
            }

            _cashBalance += shares * price;
            _holdings.Clear();
            _holdings.AddRange(updatedHoldings);

            return true;
        }
    }
}