using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskProject.Configuration;
using TaskProject.Entities;

namespace TaskProject
{
    public class PatientContext : DbContext
    {

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientRecord> PatientRecords { get; set; }

        public PatientContext(DbContextOptions<PatientContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false; 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PatientConfiguration(modelBuilder.Entity<Patient>());

            new PatientRecordConfiguration(modelBuilder.Entity<PatientRecord>());
        }

    }
}
