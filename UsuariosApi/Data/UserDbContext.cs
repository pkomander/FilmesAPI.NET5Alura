using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {

        private IConfiguration _configuration;

        //public UserDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration configuration) : base(opt)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //criacao de usuario Admin que vai ser salvo no banco
            CustomIdentityUser admin = new CustomIdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 999999
            };

            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("admininfo:password"));

            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 999999, Name = "admin", NormalizedName = "ADMIN" });
            
            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 999997, Name = "regular", NormalizedName = "REGULAR" });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 999999, UserId = 999999 });
        }
    }
}
