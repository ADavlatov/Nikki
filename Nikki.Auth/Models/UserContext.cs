using Microsoft.EntityFrameworkCore;

namespace Nikki.Auth.Models;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.ToTable("NikkiUsers");
            entity.Property(x => x.Username).HasMaxLength(255).HasColumnName("Username");
            entity.Property(x => x.Email).HasMaxLength(255).HasColumnName("Email");
            entity.Property(x => x.Password).HasMaxLength(255).HasColumnName("Password");
        });
    }
}