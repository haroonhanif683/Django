using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SMS.Models;

public partial class ManagementSystemContext : DbContext
{
    public ManagementSystemContext()
    {
    }

    public ManagementSystemContext(DbContextOptions<ManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Claimant> Claimants { get; set; }

    public virtual DbSet<Founder> Founders { get; set; }

    public virtual DbSet<Foundrecord> Foundrecords { get; set; }

    public virtual DbSet<Item> Items { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseNpgsql("Host=ep-tiny-resonance-a46tc6v2-pooler.us-east-1.aws.neon.tech;Database=ManagementSystem;Username=ManagementSystem_owner;Password=npg_2fE8ojzGyHMV");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claimant>(entity =>
        {
            entity.HasKey(e => e.ClaimantId).HasName("claimant_pkey");

            entity.ToTable("claimant");

            entity.Property(e => e.ClaimantId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("claimant_id");
            entity.Property(e => e.ClaimantName)
                .HasMaxLength(25)
                .HasColumnName("claimant_name");
        });

        modelBuilder.Entity<Founder>(entity =>
        {
            entity.HasKey(e => e.FounderId).HasName("founder_pkey");

            entity.ToTable("founder");

            entity.Property(e => e.FounderId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("founder_id");
            entity.Property(e => e.FounderName)
                .HasMaxLength(25)
                .HasColumnName("founder_name");
            entity.Property(e => e.FounterContact)
                .HasMaxLength(15)
                .HasColumnName("founter_contact");
        });

        modelBuilder.Entity<Foundrecord>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("foundrecord");

            entity.Property(e => e.ClaimDate)
                .HasMaxLength(15)
                .HasColumnName("claim_date");
            entity.Property(e => e.ClaimantId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("claimant_id");
            entity.Property(e => e.FoundDate)
                .HasMaxLength(15)
                .HasColumnName("found_date");
            entity.Property(e => e.FounderId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("founder_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");

            entity.HasOne(d => d.Claimant).WithMany()
                .HasForeignKey(d => d.ClaimantId)
                .HasConstraintName("foundrecord_claimant_id_fkey");

            entity.HasOne(d => d.Founder).WithMany()
                .HasForeignKey(d => d.FounderId)
                .HasConstraintName("foundrecord_founder_id_fkey");

            entity.HasOne(d => d.Item).WithMany()
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("foundrecord_item_id_fkey");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("item_pkey");

            entity.ToTable("item");

            entity.Property(e => e.ItemId)
                .ValueGeneratedNever()
                .HasColumnName("item_id");
            entity.Property(e => e.ItemDiscription)
                .HasMaxLength(50)
                .HasColumnName("item_discription");
            entity.Property(e => e.ItemName)
                .HasMaxLength(25)
                .HasColumnName("item_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
