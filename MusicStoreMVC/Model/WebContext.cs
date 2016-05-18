using System.Data.Entity;
using Model.Entities;

namespace Model
{
    public class WebContext : DbContext
    {
        public WebContext() : base("MusicStoree")
        {
        }

        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
       
            base.OnModelCreating(modelBuilder); // na koncu zawsze base jezeli go nie dodamy to bedzie nam tworzyl nasze obiekty , natomiast nie jest to poprawna struktura poniewaz w identity sam sobie nazywa struktury WAZNE!
            //Pozniej dodajemy migracje Add-migration AddOrder
        }
    }
}
