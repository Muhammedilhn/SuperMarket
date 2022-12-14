using SuperMarket.Core.Entities;
using SuperMarket.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Entities.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
