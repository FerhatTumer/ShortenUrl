using Microsoft.EntityFrameworkCore;
using SHORTURL.Domain.Entities;

namespace SHORTURL.Infrastructure
{
    public class UrlDbContext : DbContext
    {
        public UrlDbContext(DbContextOptions<UrlDbContext> options)
    : base(options)
        { }
        public DbSet<UrlEntry> UrlEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlEntry>(entity =>
            {
                entity.ToTable("TB_URL_ENTRIES");

                entity.Property(u => u.ShortUrl).HasColumnName("SHORTURL");

                entity.HasKey(u => u.ShortUrl);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
