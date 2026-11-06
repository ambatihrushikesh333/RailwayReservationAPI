using Microsoft.EntityFrameworkCore;
using RailwayReservationAPI.Models;

namespace RailwayReservationAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Reservation> Reservations
        {get;set;}
    }
}