using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Request
{
    public class CategoryRequest
    {
        public string ParentId { get; set; }

        public string Name { get; set; }
    }
}
