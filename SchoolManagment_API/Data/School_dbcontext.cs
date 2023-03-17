using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagment_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SchoolManagment_API.Data.ModelsConfig;
using SchoolManagment_API.Models;
using System.Security.Claims;

namespace SchoolManagment_API.Data
{
    public class School_dbcontext : IdentityDbContext
    {
        public School_dbcontext(DbContextOptions<School_dbcontext> options)
           : base(options)
        {
              Database.Migrate();
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
      //  public DbSet<Users_School> usersSchool { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseExceptionProcessor();
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");


            builder.ApplyConfiguration(new SchoolConfig());
            builder.ApplyConfiguration(new ClassConfig());
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new RoleConfig());

            //builder.ApplyConfiguration(new UserRoleConfig());

            //builder.ApplyConfigurationsFromAssembly(typeof(string).Assembly);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            }, new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "2"

            }, new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "3"

            }, new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "4"

            });

        }

    }
}
