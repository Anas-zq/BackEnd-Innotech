using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskProject.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficialID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PatientRecords",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AmountBill = table.Column<double>(type: "float", nullable: false),
                    TimeEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRecords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientRecords_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "ID", "DateOfBirth", "Email", "Name", "OfficialID" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmad@Innotec", "Ahmad", 0 },
                    { 2, new DateTime(1998, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anas@Innotec", "Anas", 2 },
                    { 3, new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ihab@Innotec", "ihab", 3 },
                    { 4, new DateTime(2002, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "majd@Innotec", "majd", 4 }
                });

            migrationBuilder.InsertData(
                table: "PatientRecords",
                columns: new[] { "ID", "AmountBill", "Description", "DiseaseName", "PatientID", "TimeEntry" },
                values: new object[,]
                {
                    { 1, 100.0, null, "Corona", 1, new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 120.0, null, "Cancer", 1, new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 150.0, null, "Z Disease", 1, new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 220.0, null, "X Disease", 1, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 10.0, null, "Y Disease", 1, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 300.0, null, "Y Disease", 2, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 70.0, null, "Z Disease", 2, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 50.0, null, "A Disease", 2, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 200.0, null, "AB Disease", 2, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 100.0, null, "X Disease", 2, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 100.0, null, "Corona", 3, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 3000.0, null, "Cancer", 3, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 700.0, null, "Zx ", 3, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 500.0, null, "Ax ", 3, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientRecords_PatientID",
                table: "PatientRecords",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_OfficialID",
                table: "Patients",
                column: "OfficialID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientRecords");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
