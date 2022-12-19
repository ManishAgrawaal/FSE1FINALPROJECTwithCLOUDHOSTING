using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LoginServices.Models
{
    public partial class onlineshoppingContext : DbContext
    {
        public onlineshoppingContext()
        {
        }

        public onlineshoppingContext(DbContextOptions<onlineshoppingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orderstbl> Orderstbls { get; set; }
        public virtual DbSet<Productstbl> Productstbls { get; set; }
        public virtual DbSet<TblLogin> TblLogins { get; set; }
        public virtual DbSet<Userstbl> Userstbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET058;Initial Catalog=onlineshopping;user id=sa;password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Orderstbl>(entity =>
            {
                entity.ToTable("orderstbl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("date");

                entity.Property(e => e.Orderid)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("orderid");

                entity.Property(e => e.Productid).HasColumnName("productid");
            });

            modelBuilder.Entity<Productstbl>(entity =>
            {
                entity.ToTable("productstbl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Features)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("features");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("price");

                entity.Property(e => e.Productdesc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("productdesc");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("productname");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.ToTable("tblLogin");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Userstbl>(entity =>
            {
                entity.ToTable("userstbl");

                entity.HasIndex(e => e.Email, "IX_userstbl_1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contactnumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contactnumber");

                entity.Property(e => e.Cpassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cpassword");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Roletype).HasColumnName("roletype");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
