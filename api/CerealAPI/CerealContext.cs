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
        => optionsBuilder.UseMySql("server=db;port=3306;database=cereal;user=cereal_user;password=cereal_password",
            Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect("server=db;port=3306;database=cereal;user=cereal_user;password=cereal_password"),
            mySqlOptionsAction => mySqlOptionsAction.EnableRetryOnFailure());

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
