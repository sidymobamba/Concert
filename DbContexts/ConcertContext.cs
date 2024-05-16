using Concert.Entities;
using Microsoft.EntityFrameworkCore;

namespace Concert.DbContexts
{
    public class ConcertContext : DbContext
    {
        public ConcertContext(DbContextOptions<ConcertContext> options)
           : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { Id = "fg32", Name = "Sidy", Surname = "Samb", City = "Brescia", MeansOfTransport = "Car" },
                new UserEntity { Id = "35f4", Name = "Pippo", Surname = "Caio", City = "Milano", MeansOfTransport = "Train" }

            );

            modelBuilder.Entity<TicketEntity>().HasData(
               new TicketEntity { Id = "db34", UserId = "fg32", CO2 = 23455 },
               new TicketEntity { Id = "fv45", UserId = "35f4", CO2 = 23455 }

           );
        }
    }
}
