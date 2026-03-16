using BullseyeApi.Models;

namespace BullseyeApi.Services
{
    public class StockService
    {
        private readonly List<Stock> _stocks = new()
        {
            new Stock { Ticker = "BLZ", CompanyName = "Blaze Industries", Price = 142.50m, MarketCap = 52000000000, Sector = "Technology" },
            new Stock { Ticker = "CRX", CompanyName = "Cerex Energy", Price = 87.30m, MarketCap = 31000000000, Sector = "Energy" },
            new Stock { Ticker = "DVN", CompanyName = "Davin Pharmaceuticals", Price = 220.10m, MarketCap = 78000000000, Sector = "Healthcare" },
            new Stock { Ticker = "FXO", CompanyName = "Foxo Retail Group", Price = 54.75m, MarketCap = 18000000000, Sector = "Consumer" },
            new Stock { Ticker = "GNX", CompanyName = "Genex Robotics", Price = 305.60m, MarketCap = 95000000000, Sector = "Technology" },
            new Stock { Ticker = "HVL", CompanyName = "Harvel Logistics", Price = 67.20m, MarketCap = 22000000000, Sector = "Transportation" },
            new Stock { Ticker = "KPX", CompanyName = "Kopex Mining", Price = 39.80m, MarketCap = 14000000000, Sector = "Materials" },
            new Stock { Ticker = "NVX", CompanyName = "Novex Semiconductors", Price = 412.30m, MarketCap = 134000000000, Sector = "Technology" },
            new Stock { Ticker = "ORB", CompanyName = "Orbital Dynamics", Price = 198.75m, MarketCap = 67000000000, Sector = "Technology" },
            new Stock { Ticker = "PTH", CompanyName = "Patheon Biotech", Price = 88.40m, MarketCap = 29000000000, Sector = "Healthcare" },
            new Stock { Ticker = "QDX", CompanyName = "Quadex Financial", Price = 73.20m, MarketCap = 41000000000, Sector = "Finance" },
            new Stock { Ticker = "RVN", CompanyName = "Raven Aerospace", Price = 265.90m, MarketCap = 89000000000, Sector = "Defense" },
            new Stock { Ticker = "SLX", CompanyName = "Solax Renewables", Price = 119.60m, MarketCap = 38000000000, Sector = "Energy" },
            new Stock { Ticker = "TRX", CompanyName = "Trexon Automotive", Price = 47.30m, MarketCap = 16000000000, Sector = "Consumer" },
            new Stock { Ticker = "UVN", CompanyName = "Uvena Pharmaceuticals", Price = 334.20m, MarketCap = 112000000000, Sector = "Healthcare" },
            new Stock { Ticker = "VLK", CompanyName = "Volkex Steel", Price = 29.80m, MarketCap = 9000000000, Sector = "Materials" },
            new Stock { Ticker = "WXP", CompanyName = "Wexpro Chemicals", Price = 61.40m, MarketCap = 21000000000, Sector = "Materials" },
            new Stock { Ticker = "XNT", CompanyName = "Xentrix Networks", Price = 187.50m, MarketCap = 63000000000, Sector = "Technology" },
            new Stock { Ticker = "YDX", CompanyName = "Yodex Logistics", Price = 54.90m, MarketCap = 19000000000, Sector = "Transportation" },
            new Stock { Ticker = "ZPH", CompanyName = "Zephyr Aviation", Price = 143.70m, MarketCap = 48000000000, Sector = "Transportation" },
            new Stock { Ticker = "ACX", CompanyName = "Acxion Data", Price = 276.30m, MarketCap = 91000000000, Sector = "Technology" },
            new Stock { Ticker = "BNT", CompanyName = "Benton Insurance", Price = 92.10m, MarketCap = 33000000000, Sector = "Finance" },
            new Stock { Ticker = "CLV", CompanyName = "Clover Agritech", Price = 38.60m, MarketCap = 12000000000, Sector = "Agriculture" },
            new Stock { Ticker = "DRX", CompanyName = "Drexon Defense", Price = 321.40m, MarketCap = 107000000000, Sector = "Defense" },
            new Stock { Ticker = "EMX", CompanyName = "Emex Power Grid", Price = 74.80m, MarketCap = 26000000000, Sector = "Energy" },
            new Stock { Ticker = "FNV", CompanyName = "Fenova Ventures", Price = 158.20m, MarketCap = 54000000000, Sector = "Finance" },
            new Stock { Ticker = "GVX", CompanyName = "Gravex Construction", Price = 43.50m, MarketCap = 15000000000, Sector = "Infrastructure" },
            new Stock { Ticker = "HZN", CompanyName = "Horizon Telecom", Price = 109.30m, MarketCap = 37000000000, Sector = "Technology" },
            new Stock { Ticker = "IXL", CompanyName = "Ixalor Cybersecurity", Price = 234.70m, MarketCap = 79000000000, Sector = "Technology" },
            new Stock { Ticker = "JVX", CompanyName = "Javex Maritime", Price = 67.90m, MarketCap = 23000000000, Sector = "Transportation" },
            new Stock { Ticker = "KLN", CompanyName = "Kalon Nutrition", Price = 31.20m, MarketCap = 10000000000, Sector = "Consumer" },
            new Stock { Ticker = "LMX", CompanyName = "Lumex Solar", Price = 88.70m, MarketCap = 30000000000, Sector = "Energy" },
            new Stock { Ticker = "MNV", CompanyName = "Minerva Banking", Price = 147.60m, MarketCap = 50000000000, Sector = "Finance" },
            new Stock { Ticker = "NPX", CompanyName = "Nopex Plastics", Price = 22.40m, MarketCap = 7000000000, Sector = "Materials" },
            new Stock { Ticker = "OVX", CompanyName = "Ovex Oil & Gas", Price = 193.80m, MarketCap = 65000000000, Sector = "Energy" },
            new Stock { Ticker = "PNX", CompanyName = "Phenix Genetics", Price = 289.50m, MarketCap = 97000000000, Sector = "Healthcare" },
            new Stock { Ticker = "QVX", CompanyName = "Quovex Quantum", Price = 512.30m, MarketCap = 171000000000, Sector = "Technology" },
            new Stock { Ticker = "RMX", CompanyName = "Romex Real Estate", Price = 84.20m, MarketCap = 28000000000, Sector = "Real Estate" },
            new Stock { Ticker = "SNX", CompanyName = "Sonex Audio", Price = 57.60m, MarketCap = 19000000000, Sector = "Consumer" },
            new Stock { Ticker = "TLX", CompanyName = "Telex Communications", Price = 123.40m, MarketCap = 42000000000, Sector = "Technology" },
            new Stock { Ticker = "UMX", CompanyName = "Umex Uranium", Price = 44.70m, MarketCap = 15000000000, Sector = "Energy" },
            new Stock { Ticker = "VNX", CompanyName = "Venox Pharmaceuticals", Price = 376.80m, MarketCap = 126000000000, Sector = "Healthcare" },
            new Stock { Ticker = "WLX", CompanyName = "Wellex Water Works", Price = 69.30m, MarketCap = 23000000000, Sector = "Infrastructure" },
            new Stock { Ticker = "XPV", CompanyName = "Xpova Electric", Price = 231.50m, MarketCap = 77000000000, Sector = "Consumer" },
            new Stock { Ticker = "YNX", CompanyName = "Yonex Fertilizers", Price = 36.90m, MarketCap = 12000000000, Sector = "Agriculture" },
            new Stock { Ticker = "ZRX", CompanyName = "Zerox Robotics", Price = 445.20m, MarketCap = 149000000000, Sector = "Technology" },
            new Stock { Ticker = "ABX", CompanyName = "Ablex Brewing", Price = 48.30m, MarketCap = 16000000000, Sector = "Consumer" },
            new Stock { Ticker = "BCX", CompanyName = "Becox Medical Devices", Price = 167.40m, MarketCap = 56000000000, Sector = "Healthcare" },
            new Stock { Ticker = "CDX", CompanyName = "Codex Publishing", Price = 29.10m, MarketCap = 9000000000, Sector = "Media" },
            new Stock { Ticker = "DFX", CompanyName = "Defex Freight", Price = 93.60m, MarketCap = 31000000000, Sector = "Transportation" },
        };

        private readonly Dictionary<string, List<PricePoint>> _priceHistory = new();
        private readonly Random _random = new();

        public StockService()
        {
            foreach (var stock in _stocks)
            {
                _priceHistory[stock.Ticker] = new List<PricePoint>();
            }
        }

        public List<Stock> GetAllStocks() => _stocks;

        public Stock? GetStock(string ticker) =>
            _stocks.FirstOrDefault(s => s.Ticker == ticker);

        public List<PricePoint> GetPriceHistory(string ticker) =>
            _priceHistory.TryGetValue(ticker, out var history) ? history : new List<PricePoint>();

        public void UpdatePrices()
        {
            var now = DateTime.Now;
            int time = now.Hour * 3600 + now.Minute * 60 + now.Second;

            foreach (var stock in _stocks)
            {
                var change = (decimal)(_random.NextDouble() - 0.5) * 0.5m;
                stock.Price = Math.Max(0.01m, Math.Round(stock.Price + change, 2));
                _priceHistory[stock.Ticker].Add(new PricePoint { Time = time, Price = stock.Price });
            }
        }
    }
}