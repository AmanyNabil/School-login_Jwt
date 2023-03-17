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
    public class SchoolConfig : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasIndex(s => s.name)
                    .IsUnique();
            builder.HasIndex(s => s.phone)
                    .IsUnique();
            //--------------------Data Seeds-------------------------
            builder.HasData(
                    new School
                    {
                        id = 1,
                        name = "School S1",
                        address = "El-Sherouk",
                        phone = "01234567890"
                    },
                    new School
                    {
                        id = 2,
                        name = "School S2",
                        address = "Madinaty",
                        phone = "01287654390"
                    }
                );

        }
    }
}
