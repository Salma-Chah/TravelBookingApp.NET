using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelBookingApp.Models;

namespace TravelBookingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets pour nos entités
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des relations

            // Destination -> TravelPackage (1 à plusieurs)
            modelBuilder.Entity<Destination>()
                .HasMany(d => d.TravelPackages)
                .WithOne(p => p.Destination)
                .HasForeignKey(p => p.DestinationId)
                .OnDelete(DeleteBehavior.Restrict); // Empêche la suppression en cascade

            // TravelPackage -> Booking (1 à plusieurs)
            modelBuilder.Entity<TravelPackage>()
                .HasMany(p => p.Bookings)
                .WithOne(b => b.Package)
                .HasForeignKey(b => b.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

            // ApplicationUser -> Booking (1 à plusieurs)
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking -> Payment (1 à 1)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Payment)
                .WithOne(p => p.Booking)
                .HasForeignKey<Payment>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration des index pour améliorer les performances
            modelBuilder.Entity<Booking>()
                .HasIndex(b => b.UserId);

            modelBuilder.Entity<Booking>()
                .HasIndex(b => b.PackageId);

            modelBuilder.Entity<TravelPackage>()
                .HasIndex(p => p.DestinationId);

            // Configuration des propriétés décimales
            modelBuilder.Entity<TravelPackage>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}