using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery
    {
        public int OrderDetailID { get; set; }

        public GetOrderDetailByIdQuery(int orderDetailID)
        {
            OrderDetailID = orderDetailID;
        }
    }
}
