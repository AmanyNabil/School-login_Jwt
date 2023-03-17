using SchoolManagment_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SchoolManagment_API.Models;

namespace SchoolManagment_API.Data.ModelsConfig
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //--------------------Data Seed-------------------------
            var appUser = new AppUser
            {
                Id = "1",
                Email = "amany@gmail.com",
                UserName = "amany",
                EmailConfirmed = true,
                schoolId = 1,
                NormalizedUserName = "amany".ToString()
            };

            //set user password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash =  ph.HashPassword(appUser, "123456");

            //seed user
            builder.HasData(appUser);

            appUser = new AppUser
            {
                Id = "2",
                Email = "ahmed@gmail.com",
                UserName = "ahmed",
                EmailConfirmed = true,
                schoolId =1,
                NormalizedUserName = "ahmed".ToString()
            };

            //set user password
            ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "123456");
            builder.HasData(appUser);
            
            appUser = new AppUser
            {
                Id = "3",
                Email = "amal@gmail.com",
                UserName = "amal",
                EmailConfirmed = true,
                schoolId = 2,
                NormalizedUserName = "amal".ToString()
            };

            //set user password
            ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "123456");
            builder.HasData(appUser);

            appUser = new AppUser
            {
                Id = "4",
                Email = "heba@gmail.com",
                UserName = "heba",
                EmailConfirmed = true,
                schoolId = 2,
                NormalizedUserName = "heba".ToString()
            };

            //set user password
            ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "123456");
            builder.HasData(appUser);


        }
    }
}

