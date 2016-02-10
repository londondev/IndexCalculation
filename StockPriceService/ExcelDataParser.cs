using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockPriceService.Messages;

namespace StockPriceService
{
    internal class ExcelDataParser:IFileDataParser
    {
        public IEnumerable<StockData> GetStockData(Stream fileData)
        {
            throw new NotImplementedException();
        }
    }
}
