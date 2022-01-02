using EFPracticeApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPracticeApp.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("connectionstring");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Member>(entity => {

                entity.ToTable("members");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.UserName).HasColumnName("u_name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
                entity.Property(i => i.FullName).HasColumnName("full_name").HasColumnType("mvarchar").HasMaxLength(100).IsRequired();
                entity.Property(i => i.RegisterDate).HasColumnName("date_created");

            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.District).HasColumnName("district_name").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
                entity.Property(i => i.City).HasColumnName("city_name").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
                entity.Property(i => i.Country).HasColumnName("Country_name").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
                entity.Property(i => i.FullAddress).HasColumnName("full_address").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
                entity.Property(i => i.ZipCode).HasColumnName("zip_code").HasColumnType("nvarchar").HasMaxLength(10).IsRequired();

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.OrderTitle).HasColumnName("order_title").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.QuantityOfProduct).HasColumnName("product_quantity").HasColumnType("int");
                entity.Property(i => i.TotalAmount).HasColumnName("total_amount");
                entity.Property(i => i.CreationDate).HasColumnName("date_created");

            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
