using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entities;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private WebContext _context;

        public OrderRepository(WebContext context)
        {
            _context = context;
        }


        public IEnumerable<Order> GetOrdersName(string user)
        {
            return _context.Orders.Where(x => x.UserName == user).ToList();
        }

        public async Task<bool> SaveOrderTaskAsync(Order order)
        {
            try
            {
                _context.Orders.Add(order);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        
    }
}
