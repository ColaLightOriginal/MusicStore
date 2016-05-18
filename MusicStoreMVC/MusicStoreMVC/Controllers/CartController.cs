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

        public ViewResult Index(string returnUrl)
        {
            CartIndexViewModel viewModel = new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        
        public RedirectToRouteResult AddToCart(int albumId, string returnUrl)
        {
            Album album = _repository.Albums.FirstOrDefault(x => x.AlbumId == albumId);
            if (album!=null)
            {
                GetCart().AddItem(album,1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int albumId, string returnUrl)
        {
            Album album = _repository.Albums.FirstOrDefault(x => x.AlbumId == albumId);
            if (album!=null)
            {
                GetCart().RemoveLine(album);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart==null)
            {
                cart=new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}