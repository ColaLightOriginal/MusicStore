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
    }
}
