using SchoolManagment_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace SchoolManagment_API.Data.ModelsConfig
{
    public class UserRoleConfig 
    {
        //public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        //{
        //    builder.HasData(new IdentityUserRole
        //    {
        //        RoleId = "",
        //        UserId = ""
        //    });
        //}
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            }, new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "2"

            });
        }
    }
}
