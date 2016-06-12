using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStoreMVC.Controllers
{
    public class AdminController : Controller
    {
        private IAlbumRepository repository;

        public AdminController(IAlbumRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View(repository.Albums);
        }

        public ViewResult Edit(int albumId)
        {
            Album album = repository.Albums.FirstOrDefault(p => p.AlbumId == albumId);
            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                repository.SaveAlbum(album);
                TempData["message"] = string.Format("Zapisano {0} {1} ", album.Artist, album.Title);
                return RedirectToAction("Index");
            }
            else
                return View(album);
        }

        public ViewResult Create()
        {
            return View("Edit", new Album());
        }
        public ActionResult Delete(int albumId)
        {
            Album deletedAlbum = repository.DeleteAlbum(albumId);
            if (deletedAlbum != null)
                TempData["message"] = string.Format("Usunięto {0} {1}", deletedAlbum.Artist, deletedAlbum.Title);
            return RedirectToAction("Index");
        }
    }
}