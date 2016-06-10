using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.Migrations;

namespace Repository.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersName(string user);
        Task<bool> SaveOrderTaskAsync(Order order);


    }
}
