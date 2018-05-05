using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HotelRestaurantDBContext : DbContext
    {
        public HotelRestaurantDBContext() : base("HotelRestaurant")
        {
            Database.SetInitializer(strategy: new MigrateDatabaseToLatestVersion<HotelRestaurantDBContext, DAL.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
