using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskProject.Entities;

namespace TaskProject.Configuration
{
    public class PatientConfiguration
    {
        public PatientConfiguration(EntityTypeBuilder<Patient> entity)
        {
            entity.HasIndex(e => new { e.OfficialID }).IsUnique();
            entity.HasMany(e => e.PatientRecords).WithOne(e => e.Patient).HasForeignKey(e => e.PatientID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
             entity.HasData(
            new Patient
            {
                ID = 1,
              
                DateOfBirth = new DateTime(1998, 3, 2),
                OfficialID = 0,
                Name = "Ahmad",
                Email = "Ahmad@Innotec"
            },
             new Patient
             {
                 ID = 2,
                 
                 DateOfBirth = new DateTime(1998, 3, 30),
                 OfficialID = 2,
                 Name = "Anas",
                 Email = "Anas@Innotec"
             },
              new Patient
              {
                  ID = 3,
                  
                  DateOfBirth = new DateTime(2001, 3, 1),
                  OfficialID = 3,
                  Name = "ihab",
                  Email = "ihab@Innotec"
              },
               new Patient
               {
                   ID = 4,
                   
                   DateOfBirth = new DateTime(2002, 1, 3),
                   OfficialID = 4,
                   Name = "majd",
                   Email = "majd@Innotec"
               }
            );
        }
    }
}
