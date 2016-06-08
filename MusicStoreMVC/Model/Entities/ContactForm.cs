using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("E-mail"), Required(ErrorMessage = "Podaj adres ")]
        public string Email { get; set; }

        [DisplayName("Temat"), Required(ErrorMessage = "Podaj temat")]
        public string Topic { get; set; }

        [DisplayName("Wiadomość"), Required(ErrorMessage = "Wpisz wiadomość")]
        public string Message { get; set; }
    }
}
