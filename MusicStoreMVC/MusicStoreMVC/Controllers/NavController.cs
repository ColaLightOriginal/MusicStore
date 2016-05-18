using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Repository.Abstract;

namespace MusicStoreMVC.Controllers
{
    public class NavController : Controller
    {
        private IAlbumRepository _repository;
        public NavController(IAlbumRepository repository)
        {
            _repository = repository;
        }
        // GET: Nav
        public PartialViewResult Menu()
        {
            IEnumerable<string> genres = _repository.Albums
                .Select(x => x.Genre)
                .Distinct();
            return PartialView(genres);
        }
    }
}