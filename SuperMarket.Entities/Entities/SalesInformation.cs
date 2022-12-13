using SuperMarket.Core.Entities.Abstract;
using SuperMarket.Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Entities.Entities
{
    public class SalesInformation :IEntity
    {
        public int Id { get; set; }
        [RegularExpression(@"^\$\d{1,3}(,\d{3})*(\.\d+)?₺")]
        public decimal TotalPrice { get; set; }
        public string PaymentType { get; set; }
    }
}
