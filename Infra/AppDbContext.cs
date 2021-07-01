using Microsoft.EntityFrameworkCore;
using starwars.Infra.Entities;

namespace starwars.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Film> Film { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            if (modelBuider != null)
            {
                modelBuider.Entity<Film>(entity =>
                {
                    entity
                    .ToTable("Film")
                    .HasKey(key => key.Id);

                    entity
                    .Property(property => property.Id)
                    .ValueGeneratedOnAdd();
                });

                base.OnModelCreating(modelBuider);
            }
        }
    }
}