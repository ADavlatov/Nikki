using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nikki.Core.Models;

public class CoreContext : DbContext
{
    public DbSet<Space>? Spaces { get; set; }
    public DbSet<Table>? Tables { get; set; }
    public DbSet<Status>? Statuses { get; set; }
    public DbSet<Task>? Tasks { get; set; }
    public DbSet<Subtask>? Subtasks { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=NikkiCore;Username=postgres;Password=admin");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SpaceConfiguration());
        modelBuilder.ApplyConfiguration(new TableConfiguration());
        modelBuilder.ApplyConfiguration(new StatusConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        modelBuilder.ApplyConfiguration(new SubtaskConfiguration());
    }
}

public class SpaceConfiguration : IEntityTypeConfiguration<Space>
{
    public void Configure(EntityTypeBuilder<Space> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("spaces");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.UserId).HasColumnName("user_id");
    }
}

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("tables");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Space).HasColumnName("space_id");
        builder.HasOne(x => x.Space).WithMany(x => x.Tables);
    }
}

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("statuses");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Color).HasColumnName("statuses");
        builder.Property(x => x.Table).HasColumnName("table_id");
        builder.HasOne(x => x.Table).WithMany(x => x.Statuses);
    }
}

public class TaskConfiguration : IEntityTypeConfiguration<TaskModel>
{
    public void Configure(EntityTypeBuilder<TaskModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("tasks");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Priority).HasColumnName("priority");
        builder.Property(x => x.StartDate).HasColumnName("start_date");
        builder.Property(x => x.DueDate).HasColumnName("due_date");
        builder.Property(x => x.Status).HasColumnName("status_id");
        builder.HasOne(x => x.Status).WithMany(x => x.Tasks);
    }
}

public class SubtaskConfiguration : IEntityTypeConfiguration<Subtask>
{
    public void Configure(EntityTypeBuilder<Subtask> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("subtasks");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Priority).HasColumnName("priority");
        builder.Property(x => x.Task).HasColumnName("task_id");
        builder.HasOne(x => x.Task).WithMany(x => x.Subtasks);
    }
}