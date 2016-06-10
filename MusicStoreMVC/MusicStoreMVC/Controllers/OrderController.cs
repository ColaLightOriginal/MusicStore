using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Entities;
using MusicStoreMVC.Models;
using Repository.Abstract;

namespace MusicStoreMVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Checkout(Cart cart)
        {
            var order = new Order()
            {
                PriceDecimal = cart.ComputeTotalValue(),
                UserName = User.Identity.Name,
                CreateDateTime = DateTime.Now,
                Status = "Oczekujący"
            };
            
            _repository.SaveOrderTaskAsync(order);
            cart.Clear();
            return View();
        }

        public ActionResult OrderList()
        { 
            return View(_repository.GetOrdersName(User.Identity.Name));
        }
    }
}