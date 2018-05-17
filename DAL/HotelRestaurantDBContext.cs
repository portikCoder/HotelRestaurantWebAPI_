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
            //Room Reservation
            modelBuilder.Entity<RoomReservation>()
             .HasKey(c => new { c.ReservationId, c.RoomId });
            modelBuilder.Entity<Room>()
             .HasMany(c => c.RoomReservations).WithRequired().HasForeignKey(c => c.RoomId);
            
            modelBuilder.Entity<Reservation>()
             .HasMany(c => c.RoomReservations).WithRequired().HasForeignKey(c => c.ReservationId);
            //Room Equipment
            modelBuilder.Entity<RoomEquipment>()
                .HasKey(c => new { c.RoomId, c.EquipmentId });
            modelBuilder.Entity<Room>()
             .HasMany(c => c.RoomEquipment).WithRequired().HasForeignKey(c => c.RoomId);

            modelBuilder.Entity<Equipment>()
             .HasMany(c => c.RoomEquipment).WithRequired().HasForeignKey(c => c.EquipmentId);

            ///Room Property
            modelBuilder.Entity<RoomProperties>()
                .HasKey(c => new { c.RoomId, c.PropertiId });
            modelBuilder.Entity<Room>()
             .HasMany(c => c.RoomProperties).WithRequired().HasForeignKey(c => c.RoomId);

            modelBuilder.Entity<Properties>()
             .HasMany(c => c.RoomProperties).WithRequired().HasForeignKey(c => c.PropertiId);



        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet <Equipment> Equipment{ get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Reservation> Reservations{ get; set; }
        public DbSet<RoomEquipment> RoomEquipment { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<RoomProperties> RoomProperties { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Subtype> Subtypes { get; set; }
        public DbSet<Objects> Objects { get; set; }
        
        //public DbSet<User> userke { get; set; }
    }
}
