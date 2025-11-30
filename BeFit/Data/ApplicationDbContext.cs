using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BeFit.Models;

namespace BeFit.Data
{
    public class ApplicationDbContext : IdentityDbContext<Uzytkownik>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Cwiczenie> Cwiczenie { get; set; } = default!;
        public DbSet<Sesja> Sesje { get; set; } = default!;
        public DbSet<SesjaCwiczenia> SesjeCwiczenia { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            builder.Entity<Cwiczenie>()
                   .HasIndex(e => e.Name);

            
            builder.Entity<SesjaCwiczenia>()
                   .HasOne(sc => sc.Sesja)
                   .WithMany()                 
                   .HasForeignKey(sc => sc.SesjaId)
                   .OnDelete(DeleteBehavior.Cascade);

            
            builder.Entity<SesjaCwiczenia>()
                   .HasOne(sc => sc.Cwiczenie)
                   .WithMany()
                   .HasForeignKey(sc => sc.CwiczenieId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
