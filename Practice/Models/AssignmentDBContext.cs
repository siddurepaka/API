using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Practice.Models
{
    public partial class AssignmentDBContext : DbContext
    {
        public AssignmentDBContext()
        {
        }

        public AssignmentDBContext(DbContextOptions<AssignmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Project> Project { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2BPKC13\\SQLEXPRESS;Initial Catalog=AssignmentDB;Persist Security Info=True;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eid);

                entity.HasIndex(e => e.ProjectId);

                entity.Property(e => e.Eid).HasMaxLength(5);

                entity.Property(e => e.Designation).HasMaxLength(20);

                entity.Property(e => e.Ename)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Joindate)
                    .HasColumnName("joindate")
                    .HasColumnType("date");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Salry).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("items");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.HasIndex(e => e.ItemId);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ItemId);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("projectID");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
