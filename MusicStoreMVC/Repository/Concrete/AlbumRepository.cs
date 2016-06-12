using System.Linq;
using Model;
using Model.Entities;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class AlbumRepository : IAlbumRepository
    {
        private WebContext _context;

        public AlbumRepository(WebContext context)
        {
            _context = context;
        }
        public IQueryable<Album> Albums
        {
            get
            {
                return _context.Albums;
            }
        }
        public void SaveAlbum(Album album)
        {
            if (album.AlbumId == 0)
                _context.Albums.Add(album);
            else
            {
                Album dbEntry = _context.Albums.Find(album.AlbumId);

                if (dbEntry != null)
                {
                    dbEntry.AlbumUrl = dbEntry.AlbumUrl;
                    dbEntry.Artist = album.Artist;
                    dbEntry.Genre = album.Genre;
                    dbEntry.Price = album.Price;
                    dbEntry.Title = album.Title;
                }
            }
            _context.SaveChanges();
        }
        public Album DeleteAlbum(int albumId)
        {
            Album dbEntry = _context.Albums.Find(albumId);
            if (dbEntry != null)
            {
                _context.Albums.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
