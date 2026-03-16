using BullseyeApi.Models;

namespace BullseyeApi.Services
{
    public class PortfolioService
    {
        private readonly List<Holding> _holdings = new();
        private decimal _cashBalance = 100000m;

        public List<Holding> GetHoldings() => _holdings;

        public decimal GetCashBalance() => _cashBalance;

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