using SuperMarket.Core.Entities;
using SuperMarket.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Entities.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public int StockCount { get; set; }
        [RegularExpression(@"^\$\d{1,3}(,\d{3})*(\.\d+)?₺")]
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<ShopCart> ShopCarts { get; set; }
    }
}
