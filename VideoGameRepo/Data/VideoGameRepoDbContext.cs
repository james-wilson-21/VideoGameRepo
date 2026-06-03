using VideoGameRepo.Models;
using Microsoft.EntityFrameworkCore;

namespace VideoGameRepo.Data
{
    public class VideoGameRepoDbContext : DbContext
    {
        public VideoGameRepoDbContext(DbContextOptions<VideoGameRepoDbContext> options)
            : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Game>()
                .Property(b => b.Cost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Game>()
                .Property(b => b.Shipping)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Game>()
                .Property(b => b.Status)
                .HasDefaultValue(false);

            modelBuilder.Entity<Game>()
                .Property(b => b.Image)
                .HasMaxLength(200);

        }
    }
}
