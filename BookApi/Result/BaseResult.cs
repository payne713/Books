using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Result
{
    public class BaseResult
    {
        public bool Status { get; set; }

        public string Message { get; set; }
    }
}
