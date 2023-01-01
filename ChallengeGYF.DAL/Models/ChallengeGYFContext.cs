using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ChallengeGYF;User Id = sa; Password=123456_mbP;TrustServerCertificate=True;MultipleActiveResultSets=true;");

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
