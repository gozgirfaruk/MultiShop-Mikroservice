using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;
using MultiShop.OrderPersistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderPersistance.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _context;

        public OrderingRepository(OrderContext context)
        {
            _context = context;
        }

        public List<Ordering> GetOrderingsByUserId(string id)
        {
            var values = _context.Orderings.Where(x=>x.UserID==id).ToList();
            return values;
        }
    }
}
