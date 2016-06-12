using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Model.Entities
{
    public class Album
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Proszę podać gatunek.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Proszę podać artystę.")]
        public string Artist { get; set; }

        [Required(ErrorMessage = "Proszę podać tytuł.")]
        public string Title { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        public decimal Price { get; set; }

        [DefaultValue("/Content/Images/placeholder.gif")]
        public string AlbumUrl { get; set; }
    }
}
