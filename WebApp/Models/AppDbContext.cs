using Microsoft.EntityFrameworkCore;
namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }

    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Combine(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite( $"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    NIP = "28432",
                    Name = "WSEI",
                    REGON = "43248320948",
                },
                new OrganizationEntity()
                {
                    Id = 102,
                    NIP = "48432",
                    Name = "Firma",
                    REGON = "43423248320948",
                }
                
            );
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new {OrganizationEntityId = 101, Street = "św. Filipa 17", City="Kraków"},
                new {OrganizationEntityId = 102, Street = "Dworcowa 7", City="Łódż"}
            );

        modelBuilder.Entity<ContactEntity>()
            .Property(c => c.OrganizationId)
            .HasDefaultValue(101);
        
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Kowal",
                    Email = "adam@gmail.com",
                    PhoneNumber = "123453234",
                    BirthDate = new (2000,10,10),
                    Created = DateTime.Now,
                    OrganizationId = 101,
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Ewa",
                    LastName = "Kowal",
                    Email = "ewa@gmail.com",
                    PhoneNumber = "223413234",
                    BirthDate = new (2000,10,17),
                    Created = DateTime.Now,
                    OrganizationId = 101,
                }
            );
    }
}