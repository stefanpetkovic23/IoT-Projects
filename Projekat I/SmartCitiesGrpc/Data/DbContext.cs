using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class SmartCitiesDbContext : DbContext
{
    public SmartCitiesDbContext(DbContextOptions<SmartCitiesDbContext> options)
        : base(options)
    {
    }

    
    public DbSet<CityValue> smartcities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CityValue>(entity =>
        {
            entity.ToTable("smartcities"); // Ime tabele u bazi
            entity.HasKey(e => e.Id); // Postavljanje primarnog ključa

            // Mapiranje svojstava na kolone
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.City).HasColumnName("City");
            entity.Property(e => e.Country).HasColumnName("Country");
            entity.Property(e => e.SmartMobility).HasColumnName("Smart_Mobility");
            entity.Property(e => e.SmartEnvironment).HasColumnName("Smart_Environment");
            entity.Property(e => e.SmartGovernment).HasColumnName("Smart_Government");
            entity.Property(e => e.SmartEconomy).HasColumnName("Smart_Economy");
            entity.Property(e => e.SmartPeople).HasColumnName("Smart_People");
            entity.Property(e => e.SmartLiving).HasColumnName("Smart_Living");
            entity.Property(e => e.SmartCityIndex).HasColumnName("SmartCity_Index");
            entity.Property(e => e.SmartCityIndexRelativeEdmonton).HasColumnName("SmartCity_Index_relative_Edmonton");
        });
    }
}
