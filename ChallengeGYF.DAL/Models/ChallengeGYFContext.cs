using System;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChallengeGYF.DAL.EF.Models;

public partial class ChallengeGYFContext : DbContext
{
    public ChallengeGYFContext()
    {
    }

    public ChallengeGYFContext(DbContextOptions<ChallengeGYFContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                          .AddJsonFile("appsettings.json")
                          .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("myDb"));

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.Property(e => e.CategoriaID).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Observaciones).HasMaxLength(250);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(e => e.FechaCarga).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(250);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Producto)
                .HasForeignKey(d => d.CategoriaID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoriaID_CategoriaID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
