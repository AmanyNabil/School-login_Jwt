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
    public class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {

            builder.HasIndex(c => new { c.name, c.schoolId })
                    .IsUnique();
            //--------------------Data Seeds-------------------------
            builder.HasData(
                    new Class
                    {
                        id = 1,
                        name = "S1-C1",
                        floor = 1,
                        schoolId = 1
                    },
                    new Class
                    {
                        id = 2,
                        name = "S1-C2",
                        floor = 2,
                        schoolId = 1
                    },
                     new Class
                     {
                         id = 3,
                         name = "S1-C3",
                         floor = 3,
                         schoolId = 1
                     },
                      new Class
                      {
                          id = 4,
                          name = "S2-C1",
                          floor = 1,
                          schoolId = 2
                      },
                       new Class
                       {
                           id = 5,
                           name = "S2-C2",
                           floor = 2,
                           schoolId = 2
                       }
                );

        }
    }
}
