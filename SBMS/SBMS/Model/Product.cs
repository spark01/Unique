using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Model
{
    class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
