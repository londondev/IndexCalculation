using System;

namespace StockPriceService.Messages
{
    public class StockData
    {
        public string IndexName { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int Share { get; set; }
    }

    public class WeightedStockData : StockData
    {
        public decimal Weight { get; set; }
    }
}