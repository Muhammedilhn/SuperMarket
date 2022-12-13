using SuperMarket.Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Entities.Dtos
{
    public class SalesAddDto
    {
        public decimal TotalPrice { get; set; }
        public string PaymentType { get; set; }
    }
}
