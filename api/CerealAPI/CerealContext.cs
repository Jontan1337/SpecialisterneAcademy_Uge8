using System;
using System.Collections.Generic;
using CerealAPI.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace CerealAPI;

public partial class CerealContext : DbContext
{
    public CerealContext()
    {
    }

    public CerealContext(DbContextOptions<CerealContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=Cereal;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Calories).HasColumnType("int(11)");
            entity.Property(e => e.Fat).HasColumnType("int(11)");
            entity.Property(e => e.Manufacturer).HasMaxLength(1024);
            entity.Property(e => e.Name).HasMaxLength(1024);
            entity.Property(e => e.Potass).HasColumnType("int(11)");
            entity.Property(e => e.Protein).HasColumnType("int(11)");
            entity.Property(e => e.Shelf).HasColumnType("int(11)");
            entity.Property(e => e.Sodium).HasColumnType("int(11)");
            entity.Property(e => e.Sugars).HasColumnType("int(11)");
            entity.Property(e => e.Type).HasColumnType("enum('COLD','HOT')");
            entity.Property(e => e.Vitamins).HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
