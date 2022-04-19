using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdaProjectWithSql.Models
{
    public partial class AdaProjectContext : DbContext
    {
        public AdaProjectContext()
        {
        }

        public AdaProjectContext(DbContextOptions<AdaProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BasketProduct> BasketProducts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OKME90P\\SQLEXPRESS;Database=AdaProject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.ToTable("Basket");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Baskets)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Basket_Customer1");
            });

            modelBuilder.Entity<BasketProduct>(entity =>
            {
                entity.ToTable("BasketProduct");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Statement)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.BasketProducts)
                    .HasForeignKey(d => d.BasketId)
                    .HasConstraintName("FK_BasketProduct_Basket");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
