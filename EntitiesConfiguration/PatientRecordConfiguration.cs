using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Entities;

namespace TaskProject.Configuration
{
    public class PatientRecordConfiguration
    {
        public PatientRecordConfiguration(EntityTypeBuilder<PatientRecord> entity)
        {
            entity.HasData(
           new PatientRecord
           {
               ID = 1,
               TimeEntry = new DateTime(2020, 3, 2),
               DiseaseName = "Corona",
               AmountBill = 100,
               PatientID = 1
           },
            new PatientRecord
            {
                ID = 2,
                TimeEntry = new DateTime(2020, 3,3),
                DiseaseName = "Cancer",
                AmountBill = 120,
                PatientID = 1
            },
             new PatientRecord
             {
                 ID = 3,
                 TimeEntry = new DateTime(2020, 4, 3),
                 DiseaseName = "Z Disease",
                 AmountBill = 150,
                 PatientID = 1
             },
              new PatientRecord
              {
                  ID = 4,
                  TimeEntry = new DateTime(2020, 4, 4),
                  DiseaseName = "X Disease",
                  AmountBill = 220,
                  PatientID = 1
              }
              ,
              new PatientRecord
              {
                  ID = 5,
                  TimeEntry = new DateTime(2020, 5, 4),
                  DiseaseName = "Y Disease",
                  AmountBill = 10,
                  PatientID = 1
              }
              ,
              new PatientRecord
              {
                  ID = 6,
                  TimeEntry = new DateTime(2020, 5, 4),
                  DiseaseName = "Y Disease",
                  AmountBill = 300,
                  PatientID = 2
              },
              new PatientRecord
              {
                  ID = 7,
                  TimeEntry = new DateTime(2020, 5, 4),
                  DiseaseName = "Z Disease",
                  AmountBill = 70,
                  PatientID = 2
              },
              new PatientRecord
              {
                  ID = 8,
                  TimeEntry = new DateTime(2020, 5, 4),
                  DiseaseName = "A Disease",
                  AmountBill = 50,
                  PatientID = 2
              },
              new PatientRecord
              {
                  ID = 9,
                  TimeEntry = new DateTime(2020, 5, 4),
                  DiseaseName = "AB Disease",
                  AmountBill = 200,
                  PatientID = 2
              },
              new PatientRecord
              {
                  ID = 10,
                  TimeEntry = new DateTime(2020, 5, 4),
                  DiseaseName = "X Disease",
                  AmountBill = 100,
                  PatientID = 2
              },
              new PatientRecord
              {
                  ID = 11,
                  TimeEntry = new DateTime(2020, 5, 4),
                  DiseaseName = "Corona",
                  AmountBill = 100,
                  PatientID = 3
              }
              ,
              new PatientRecord
              {
                  ID =12,
                  TimeEntry = new DateTime(2020, 5, 4),
                  DiseaseName = "Cancer",
                  AmountBill = 3000,
                  PatientID = 3
              },
              new PatientRecord
              {
                  ID = 13,
                  TimeEntry = new DateTime(2020, 5, 4),
                  DiseaseName = "Zx ",
                  AmountBill = 700,
                  PatientID = 3
              },
              new PatientRecord
              {
                  ID = 14,
                  TimeEntry = new DateTime(2020, 5, 4),
                  DiseaseName = "Ax ",
                  AmountBill = 500,
                  PatientID = 3
              }
           );
        }
    }
}
