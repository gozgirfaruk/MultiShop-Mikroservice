using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.CQRS.Results.AddressResults
{
    public class GetAddressByIdQueryResult
    {
        public int AddressID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Disctrict { get; set; }
        public string City { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
    }
}
