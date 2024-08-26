using MultiShop.OrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Interfaces
{
    public interface IOrderingRepository
    {
        public List<Ordering> GetOrderingsByUserId(string id);
    }
}
