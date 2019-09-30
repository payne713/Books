using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Result
{
    public class DataResult : BaseResult
    {
        public string Message { get; set; }

        public dynamic Data { get; set; }
    }
}
