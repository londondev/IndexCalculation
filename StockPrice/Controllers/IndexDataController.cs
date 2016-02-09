using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StockPrice.Controllers
{
    public class IndexDataController : ApiController
    {
        public IHttpActionResult Post(AddStockRequest addStockRequest)
        {
            //var data = addStockRequest.Data.ToString();
            Debug.Write(addStockRequest.Data);
            File.WriteAllText("C:\\Temp\\Sample.txt" , addStockRequest.Data);
            return Ok();
        }
    }

    public class AddStockRequest
    {
        public string FileName { get; set; }
        public string Data { get; set; }
    }
}
