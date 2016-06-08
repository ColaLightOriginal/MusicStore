using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Model.Entities
{
    public class Cart
    {
        
        private List<CartLine> _lineColection = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        {
            get { return _lineColection; }
        }
        public void AddItem(Album album, int quanity)
        {
            CartLine line = _lineColection
                .FirstOrDefault(p => p.Album.AlbumId == album.AlbumId);
            if (line==null)
            {
                _lineColection.Add(new CartLine {Album = album, Quanity = quanity});
            }
            else
            {
                line.Quanity += quanity;
            }
        }

        public void RemoveLine(Album album)
        {
            _lineColection.RemoveAll(l => l.Album.AlbumId == album.AlbumId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineColection.Sum(e => e.Album.Price*e.Quanity);
        }

        public void Clear()
        {
            _lineColection.Clear();
        }


    }
}
