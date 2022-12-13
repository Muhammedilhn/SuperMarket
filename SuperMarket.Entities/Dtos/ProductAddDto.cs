using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Entities.Dtos
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public string ProductType { get; set; }
        public int StockCount { get; set; }
        public string PriceFormat { get; set; }
        public decimal Price { get; set; }
    }
}
