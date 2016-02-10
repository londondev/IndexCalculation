using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockPriceService.Messages;

namespace StockPriceService
{
    public class StockDataManager : IStockDataManager
    {
        //TODO: Move this to the config file
        const int INITIAL_INDEX_LEVEL = 100;

        private IFileDataParser _fileDataParser;

        public StockDataManager()
        {
            //TODO: Install DI framework and don't use "new"
            //TODO: DI Framework should choose appropriate FileDataParser based on file extension
            _fileDataParser=new CsvDataParser();
        }
        public IndexData CalculateIndex(FileData fileData)
        {
            var stockData= _fileDataParser.GetStockData(fileData.FileContent).ToList();

            return new IndexData
            {
                Indexes = CalculateIndexes(stockData),
                StockWeights = CalculateStockWeights(stockData),
                WeightedStockData = CalculateWeightedStockData(stockData)
            };

        }

        private List<WeightedStockData> CalculateWeightedStockData(List<StockData> stockDatas)
        {
            List<WeightedStockData> weightedStockDataList=new List<WeightedStockData>();
            var allDates = GetAllDates(stockDatas);
            foreach (var date in allDates)
            {
               var weightedDayStockList= stockDatas.Where(s => s.Date == date).Select(s => new WeightedStockData
                {
                    Date = s.Date,
                    Share = s.Share,
                    Price = s.Price,
                    Id = s.Id,
                    IndexName = s.IndexName,
                    Name = s.Name,
                    Weight = s.Price*s.Share*100/stockDatas.Where(ss => ss.Date == s.Date).Sum(ss => ss.Price*ss.Share)
                }).ToList();

               weightedStockDataList.AddRange(weightedDayStockList);
            }

            return weightedStockDataList;
        }

        private IList<StockWeight> CalculateStockWeights(IList<StockData> stockDatas)
        {
            var lastDate = stockDatas.Select(a => a.Date).OrderByDescending(a => a.Date).First();
            return stockDatas.Where(s=>s.Date==lastDate).Select(a => new StockWeight
            {
                StockId = a.Id,
                Weight = a.Price*a.Share
            }).ToList();
        }

        private IList<IndexDate> CalculateIndexes(IList<StockData> stockDatas)
        {
            IList<IndexDate> indexDateList=new List<IndexDate>();
            var allDates = GetAllDates(stockDatas);

            var firstDayIndexValue = GetIndexValue(stockDatas, allDates.First());
            foreach (var date in allDates)
            {
                var currentDateValue = GetIndexValue(stockDatas, date);
                indexDateList.Add(new IndexDate
                {
                     DateTime = date,
                     Index = currentDateValue * INITIAL_INDEX_LEVEL / firstDayIndexValue
                });
            }
            return indexDateList;
        }

        private static List<DateTime> GetAllDates(IList<StockData> stockDatas)
        {
            return stockDatas.Select(a => a.Date).OrderBy(a => a.Date).Distinct().ToList();
        }

        private static decimal GetIndexValue(IEnumerable<StockData> stockDatas, DateTime date)
        {
            return stockDatas.Where(a => a.Date == date).Sum(a => a.Price*a.Share);
        }
    }
}
