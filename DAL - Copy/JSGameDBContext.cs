using JSGameAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class JSGameDBContext : DbContext
    {
        public JSGameDBContext() :base("JSGameDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JSGameDBContext, DAL.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
