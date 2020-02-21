using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIDEMO.Models
{
    public partial class PracticeDBContext : DbContext
    {
        public PracticeDBContext()
        {
        }

        public PracticeDBContext(DbContextOptions<PracticeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee1> Employee1 { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Project1> Project1 { get; set; }
        public virtual DbSet<Project2> Project2 { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Works> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PracticeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contactname)
                    .HasColumnName("contactname")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Customerid)
                    .IsRequired()
                    .HasColumnName("customerid")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Town)
                    .HasColumnName("town")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasColumnName("Dept_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DeptNo)
                    .IsRequired()
                    .HasColumnName("Dept_no")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeptNo)
                    .IsRequired()
                    .HasColumnName("dept_no")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EmpFname)
                    .IsRequired()
                    .HasColumnName("emp_fname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLname)
                    .IsRequired()
                    .HasColumnName("emp_lname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Customerid)
                    .IsRequired()
                    .HasColumnName("customerid")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Shipaddress)
                    .HasColumnName("shipaddress")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Shipname)
                    .HasColumnName("shipname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Shippeddate)
                    .HasColumnName("shippeddate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Availabledate)
                    .HasColumnName("availabledate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Project1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("project1");

                entity.Property(e => e.Edate)
                    .HasColumnName("edate")
                    .HasColumnType("date");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pname)
                    .HasColumnName("pname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sdate)
                    .HasColumnName("sdate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Project2>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("project_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectNo)
                    .IsRequired()
                    .HasColumnName("project_no")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnName("age");
            });

            modelBuilder.Entity<Works>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.Enterdate)
                    .HasColumnName("enterdate")
                    .HasColumnType("date");

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectNo)
                    .HasColumnName("project_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
