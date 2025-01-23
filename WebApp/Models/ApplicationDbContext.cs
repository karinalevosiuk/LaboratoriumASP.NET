using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Superheroes;


public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<Hero> Heroes { get; set; }
    public DbSet<Superpower> Superpowers { get; set; }
    public DbSet<HeroSuperpower> HeroPowers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<HeroSuperpower>()
            .HasKey(hp => new { hp.HeroId, hp.SuperpowerId });

        modelBuilder.Entity<HeroSuperpower>()
            .HasOne(hp => hp.Hero)
            .WithMany(h => h.HeroSuperpowers)
            .HasForeignKey(hp => hp.HeroId);


        modelBuilder.Entity<HeroSuperpower>()
            .HasOne(hp => hp.Superpower)
            .WithMany(s => s.HeroSuperpowers)
            .HasForeignKey(hp => hp.SuperpowerId);
    }
}






