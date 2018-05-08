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
        public HotelRestaurantDBContext() : base("HotelRestaurantDB")
        {
            //Database.SetInitializer(strategy: new MigrateDatabaseToLatestVersion<HotelRestaurantDBContext, DAL.Migrations.Configuration>());
            MigrateDatabaseToLatestVersion<HotelRestaurantDBContext, Migrations.Configuration> strategy = new MigrateDatabaseToLatestVersion<HotelRestaurantDBContext, DAL.Migrations.Configuration>();
            Database.SetInitializer(strategy);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        //public DbSet<User> userke { get; set; }
    }
}
