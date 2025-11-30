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

            // (opcjonalnie) indeks/unikalność nazwy ćwiczenia
            builder.Entity<Cwiczenie>()
                   .HasIndex(e => e.Name);

            // relacje SesjaCwiczenie -> Sesja (wiele zapisów w jednej sesji)
            builder.Entity<SesjaCwiczenia>()
                   .HasOne(sc => sc.Sesja)
                   .WithMany()                 // możesz dodać w Sesja: public List<SesjaCwiczenie> Pozycje { get; set; } = new();
                   .HasForeignKey(sc => sc.SesjaId)
                   .OnDelete(DeleteBehavior.Cascade);

            // relacje SesjaCwiczenie -> Cwiczenia (konkretny typ ćwiczenia)
            builder.Entity<SesjaCwiczenia>()
                   .HasOne(sc => sc.Cwiczenie)
                   .WithMany()
                   .HasForeignKey(sc => sc.CwiczenieId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
