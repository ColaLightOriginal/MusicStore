using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Entities;

namespace Model
{
    public class WebContext : IdentityDbContext<ApplicationUser>
    {
        public WebContext() : base("MusicsStoree")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
       
            base.OnModelCreating(modelBuilder); // na koncu zawsze base jezeli go nie dodamy to bedzie nam tworzyl nasze obiekty , natomiast nie jest to poprawna struktura poniewaz w identity sam sobie nazywa struktury WAZNE!
            //Pozniej dodajemy migracje Add-migration AddOrder
        }
        public static WebContext Create()
        {
            return new WebContext();
        }
    }
}
