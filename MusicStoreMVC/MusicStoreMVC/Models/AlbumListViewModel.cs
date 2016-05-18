using System.Collections.Generic;
using Model.Entities;

namespace MusicStoreMVC.Models
{
    public class AlbumListViewModel
    {
        public IEnumerable<Album> Albums { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurentGenre { get; set; }
    }
}