using api.Models.AppTables;
using api.Models.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BusConfiguration());
            builder.ApplyConfiguration(new RouteConfiguration());
        }

        public DbSet<Bus>Buses { get; set; }
        public DbSet<BusRoute>BusRoutes { get; set; }
        public DbSet<Booking>Bookings { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Payment>Payments { get; set; }

    }
}