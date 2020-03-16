using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1e8bd192-8a8d-4be7-8b3f-c592b48c3d12",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "c9ac017a-07d6-4d2b-b069-5019ba92e041",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1e8bd192-8a8d-4be7-8b3f-c592b48c3d12",
                UserId = "c9ac017a-07d6-4d2b-b069-5019ba92e041"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("3544418b-d7bd-4e09-b31e-645dd7fa6ef0"),
                CodeWord = "PageIndex",
                Title = "Главна"
            }) ;

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("b5ff4f9b-44c1-4afe-8308-253ef49c2925"),
                CodeWord = "PageServices",
                Title = "Нашите услуги"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("7eebac08-7334-45d6-b5c3-731bee4677cc"),
                CodeWord = "PageContacts",
                Title = "Контакти"
            });

        }
    }
}
