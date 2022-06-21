using Microsoft.EntityFrameworkCore;
using LetsGoCamping.Models;

namespace LetsGoCamping.Repository
{
    public class CampingContext : DbContext
    {
        //We could have the data persist (for the life of the app) in these sets~
        //But for now not needed.
        public CampingContext(DbContextOptions<CampingContext> options)
            : base(options)
        {
        }

        public DbSet<CampingReservationSearch> CampingReservationSearches { get; set; }

        public DbSet<Reservations> Reservations { get; set; }

        public DbSet<Campsites> Campsites { get; set; }

        public DbSet<Search> Searches { get; set; }


    }
}

