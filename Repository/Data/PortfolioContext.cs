using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Portfolio.Domain;

namespace Portfolio.Data;

public partial class PortfolioContext : DbContext
{
    public PortfolioContext()
    {
    }

    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Infos> Infos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3316;user=root;password=Kalpa84#;database=PORTFOLIO", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.4.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Infos>(entity =>
        {
            entity.HasKey(e => e.Slno).HasName("PRIMARY");

            entity.ToTable("info");

            entity.Property(e => e.Slno)
                .HasColumnType("int(11)")
                .HasColumnName("SLNO");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Education)
                .HasMaxLength(100)
                .HasColumnName("EDUCATION");
            entity.Property(e => e.EmailId)
                .HasMaxLength(150)
                .HasColumnName("EMAIL_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("NAME");
            entity.Property(e => e.Phonenumber)
                .HasColumnType("bigint(20)")
                .HasColumnName("PHONENUMBER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
