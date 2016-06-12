using System.Linq;
using System.Web.Mvc;
using MusicStoreMVC.Models;
using Repository.Abstract;

namespace MusicStoreMVC.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumRepository _repository;
        private int PageSize = 10;
        public AlbumController(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Main page.";

            return View();
        }

        // GET: Album
        public ViewResult Albumy(string genre, int page = 1)
        {
            AlbumListViewModel viewModel = new AlbumListViewModel
            {
                Albums = _repository.Albums
                .Where(p=>genre==null || p.Genre==genre)
                    .OrderBy(p => p.Title)
                    .Skip((page-1)*PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = genre == null ?
                    _repository.Albums.Count() :
                    _repository.Albums.Count(p => p.Genre==genre)
                },
                CurentGenre = genre
            };
            return View(viewModel);
        }
    }
}