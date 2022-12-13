using SuperMarket.Core.Entities;
using SuperMarket.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Entities.Entities
{
    public class ShopCart : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? SalesInformationId { get; set; }
        public bool IsActive { get; set; }
        public Product Product { get; set; }
    }
}
