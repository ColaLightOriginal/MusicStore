using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entities;

namespace MusicStoreMVC.Models
{
    public class OrderViewModels
    {
        public string User { get; set; }
        public Cart Cart { get; set; }
    }
}