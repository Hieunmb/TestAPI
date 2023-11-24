using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Entities;

public partial class TestApiContext : DbContext
{
    public static string connectionString;
    public TestApiContext()
    {
    }

    public TestApiContext(DbContextOptions<TestApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrderTbl> OrderTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderTbl>(entity =>
        {
            entity.HasKey(e => e.ItemCode).HasName("PK__OrderTbl__3ECC0FEB2FE1889D");

            entity.ToTable("OrderTbl");

            entity.Property(e => e.ItemCode).ValueGeneratedNever();
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OderDelivery).HasColumnType("datetime");
            entity.Property(e => e.OrderAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
