using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriggersWithEFCore.Models;

namespace TriggersWithEFCore.Persistence
{
    public class TriggersEFCoreContext : DbContext
    {
        public TriggersEFCoreContext(DbContextOptions<TriggersEFCoreContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBirthday> UserBirthdays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("demo");

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(c => c.UserId).HasName("PK_Users");
                e.Property(c => c.UserId).HasColumnName("UserId").HasColumnType("bigint").ValueGeneratedOnAdd();
                e.Property(c => c.Username).HasColumnName("Username").HasColumnType("varchar(100)");
                e.Property(c => c.Password).HasColumnName("Password").HasColumnType("varchar(100)");
                e.Property(c => c.Email).HasColumnName("Email").HasColumnType("varchar(128)").IsRequired();
                e.Property(c => c.Birthday).HasColumnName("Birthday").HasColumnType("varchar(12)").IsRequired();
                e.Property(c => c.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime").IsRequired();
            });

            modelBuilder.Entity<UserBirthday>(e =>
            {
                e.ToTable("UserBirthdays");
                e.HasKey(c => c.UserBirthdayId).HasName("PK_UB");
                e.Property(c => c.UserBirthdayId).HasColumnName("UserBirthdayId").HasColumnType("bigint").ValueGeneratedOnAdd();
                e.Property(c => c.UserId).HasColumnName("UserBirthdayId").HasColumnType("bigint");
                e.Property(c => c.Email).HasColumnName("UserBirthdayId").HasColumnType("varchar(128)");
                e.Property(c => c.Birthday).HasColumnName("UserBirthdayId").HasColumnType("varchar(12)");
            });
        }
    }
}
