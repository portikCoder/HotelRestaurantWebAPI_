using DAL.Entities;
using System.Data.Entity;
using System.Configuration;

namespace DAL
{
    public class HotelRestaurantDBContext : DbContext
    {
        public HotelRestaurantDBContext() : base("HotelRestaurantDB")
        {
            Database.SetInitializer(strategy: new MigrateDatabaseToLatestVersion<HotelRestaurantDBContext, DAL.Migrations.Configuration>());
            MigrateDatabaseToLatestVersion<HotelRestaurantDBContext, Migrations.Configuration> strategy = new MigrateDatabaseToLatestVersion<HotelRestaurantDBContext, DAL.Migrations.Configuration>();
            Database.SetInitializer(strategy);

            //var connectionString = ConfigurationManager.ConnectionStrings["HotelRestaurantDB"].ConnectionString;
            //System.Console.WriteLine(connectionString);
        }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Objects> Objects { get; set; }
        
        //public DbSet<User> userke { get; set; }
    }
}
