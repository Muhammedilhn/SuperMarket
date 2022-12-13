using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Entities.Dtos
{
    public class ShopCartAddDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int? SalesInformationId { get; set; }
        public bool IsActive { get; set; }
    }
}
