using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Models
{
    public class RCODbContext : DbContext
    {
        public RCODbContext()
        {

        }

        public RCODbContext(DbContextOptions<RCODbContext> options) : base(options) { }

        public const string ConnectionString = $"Server=DESKTOP-4OVFOA0;Database=RCO;User Id=sa;Password=123456";

        public static string GetConnectionStringFromEnvironment()
        {
            return $"Server={Environment.GetEnvironmentVariable("SQL_SERVER")},{Environment.GetEnvironmentVariable("SQL_PORT")};" +
                $"Database={Environment.GetEnvironmentVariable("SQL_DATABASE")};" +
                $"User Id={Environment.GetEnvironmentVariable("SQL_USER")};" +
                $"Password={Environment.GetEnvironmentVariable("SQL_PASSWORD")}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = GetConnectionStringFromEnvironment();

            Console.WriteLine("RCO ConnectionString: " + connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessGroup>(e =>
            {
                e.ToTable("AccessGroup");
                e.HasKey(a => a.Id);
                e.Property<string>(a => a.Name).HasMaxLength(50);
                e.HasMany(a => a.Cards).WithMany(c => c.AccessGroups);
            });
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.Property(u => u.Type).IsRequired().HasDefaultValue(0);
                e.HasKey(u => u.Id);
                e.HasMany(u => u.Cards).WithOne(c => c.User).HasForeignKey(c => c.UserId).HasConstraintName("FK_User_Cards");
            });
            modelBuilder.Entity<Card>(e =>
            {
                e.ToTable("Card");
                e.HasKey(c => c.Id);
                e.Property(c => c.Description).HasMaxLength(1000);
                e.HasMany(c => c.AccessGroups).WithMany(a => a.Cards).UsingEntity<AccessGroupCard>();

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
