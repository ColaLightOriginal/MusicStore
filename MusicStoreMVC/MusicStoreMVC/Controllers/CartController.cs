using System.Linq;
using System.Web.Mvc;
using Model.Entities;
using MusicStoreMVC.Models;
using Repository.Abstract;

namespace MusicStoreMVC.Controllers
{
   
    public class CartController : Controller
    {
        private IAlbumRepository _repository;

        public CartController(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            CartIndexViewModel viewModel = new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        
        public RedirectToRouteResult AddToCart(Cart cart, int albumId, string returnUrl)
        {
            Album album = _repository.Albums.FirstOrDefault(x => x.AlbumId == albumId);
            if (album!=null)
            {
                cart.AddItem(album,1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int albumId, string returnUrl)
        {
            Album album = _repository.Albums.FirstOrDefault(x => x.AlbumId == albumId);
            if (album!=null)
            {
                cart.RemoveLine(album);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        [Authorize]
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        //Korzystamy z łącznika modelu nie musimy korzystac z metody GetCart w zamian przekazujemy parametr Cart do kazdej z metod
        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart==null)
        //    {
        //        cart=new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}