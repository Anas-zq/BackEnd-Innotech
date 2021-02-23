﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskProject;

namespace TaskProject.Migrations
{
    [DbContext(typeof(PatientContext))]
    [Migration("20210221170011_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskProject.Entities.Patient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OfficialID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OfficialID")
                        .IsUnique();

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateOfBirth = new DateTime(1998, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Ahmad@Innotec",
                            Name = "Ahmad",
                            OfficialID = 0
                        },
                        new
                        {
                            ID = 2,
                            DateOfBirth = new DateTime(1998, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Anas@Innotec",
                            Name = "Anas",
                            OfficialID = 2
                        },
                        new
                        {
                            ID = 3,
                            DateOfBirth = new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ihab@Innotec",
                            Name = "ihab",
                            OfficialID = 3
                        },
                        new
                        {
                            ID = 4,
                            DateOfBirth = new DateTime(2002, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "majd@Innotec",
                            Name = "majd",
                            OfficialID = 4
                        });
                });

            modelBuilder.Entity("TaskProject.Entities.PatientRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AmountBill")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeEntry")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("PatientID");

                    b.ToTable("PatientRecords");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AmountBill = 100.0,
                            DiseaseName = "Corona",
                            PatientID = 1,
                            TimeEntry = new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
                            AmountBill = 120.0,
                            DiseaseName = "Cancer",
                            PatientID = 1,
                            TimeEntry = new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 3,
                            AmountBill = 150.0,
                            DiseaseName = "Z Disease",
                            PatientID = 1,
                            TimeEntry = new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 4,
                            AmountBill = 220.0,
                            DiseaseName = "X Disease",
                            PatientID = 1,
                            TimeEntry = new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 5,
                            AmountBill = 10.0,
                            DiseaseName = "Y Disease",
                            PatientID = 1,
                            TimeEntry = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 6,
                            AmountBill = 300.0,
                            DiseaseName = "Y Disease",
                            PatientID = 2,
                            TimeEntry = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 7,
                            AmountBill = 70.0,
                            DiseaseName = "Z Disease",
                            PatientID = 2,
                            TimeEntry = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 8,
                            AmountBill = 50.0,
                            DiseaseName = "A Disease",
                            PatientID = 2,
                            TimeEntry = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 9,
                            AmountBill = 200.0,
                            DiseaseName = "AB Disease",
                            PatientID = 2,
                            TimeEntry = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 10,
                            AmountBill = 100.0,
                            DiseaseName = "X Disease",
                            PatientID = 2,
                            TimeEntry = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 11,
                            AmountBill = 100.0,
                            DiseaseName = "Corona",
                            PatientID = 3,
                            TimeEntry = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 12,
                            AmountBill = 3000.0,
                            DiseaseName = "Cancer",
                            PatientID = 3,
                            TimeEntry = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 13,
                            AmountBill = 700.0,
                            DiseaseName = "Zx ",
                            PatientID = 3,
                            TimeEntry = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 14,
                            AmountBill = 500.0,
                            DiseaseName = "Ax ",
                            PatientID = 3,
                            TimeEntry = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TaskProject.Entities.PatientRecord", b =>
                {
                    b.HasOne("TaskProject.Entities.Patient", "Patient")
                        .WithMany("PatientRecords")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("TaskProject.Entities.Patient", b =>
                {
                    b.Navigation("PatientRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
