using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCoreLesson4Task1
{
    public partial class ShopDBContext : DbContext
    {
        public ShopDBContext()
        {
        }

        public ShopDBContext(DbContextOptions<ShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=ShopDB;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerNo);

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.DateInSystem).HasColumnType("date");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("LName");

                entity.Property(e => e.Mname)
                    .HasMaxLength(15)
                    .HasColumnName("MName");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("FName");

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("LName");

                entity.Property(e => e.ManagerEmpId).HasColumnName("ManagerEmpID");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("MName");

                entity.Property(e => e.PriorSalary).HasColumnType("money");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.TerminationDate).HasColumnType("date");

                entity.HasOne(d => d.ManagerEmp)
                    .WithMany(p => p.InverseManagerEmp)
                    .HasForeignKey(d => d.ManagerEmpId)
                    .HasConstraintName("FK_Employees_Employees");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.CustomerNoNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerNo)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Orders_Employees");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.LineItem });

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Qty]*[UnitPrice])", false);

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.Weight).HasColumnType("numeric(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
