using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumUrl { get; set; }
    }
}
