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

            modelBuilder.Entity<RoomEquipment>()
                .HasKey(c => new { c.RoomId, c.EquipmentId });



            modelBuilder.Entity<Room>()
             .HasMany(c => c.RoomEquipment).WithRequired().HasForeignKey(c => c.RoomId);

            modelBuilder.Entity<Equipment>()
             .HasMany(c => c.RoomEquipment).WithRequired().HasForeignKey(c => c.EquipmentId);
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet <Equipment> Equipment{ get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Reservation> Reservations{ get; set; }
        public DbSet<RoomEquipment> RoomEquipment { get; set; }
        //public DbSet<User> userke { get; set; }
    }
}
