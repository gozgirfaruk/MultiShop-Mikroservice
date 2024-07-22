using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public int ID{ get; set; }

        public GetAddressByIdQuery(int iD)
        {
            ID = iD;
        }
    }
}
