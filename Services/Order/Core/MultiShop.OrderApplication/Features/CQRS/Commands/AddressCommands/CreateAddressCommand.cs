using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.CQRS.Commands.AddressCommands
{
    public class CreateAddressCommand
    {
        public string UserID { get; set; }
        public string Disctrict { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
