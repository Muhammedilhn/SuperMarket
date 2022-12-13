using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Entities.Dtos
{
    public class UserLoginDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
    }
}
