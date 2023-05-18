using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class StudentManagementModelsOri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    LId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassCId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.LId);
                    table.ForeignKey(
                        name: "FK_Lecturers_Classes_ClassCId",
                        column: x => x.ClassCId,
                        principalTable: "Classes",
                        principalColumn: "CId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    SId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassCId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.SId);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassCId",
                        column: x => x.ClassCId,
                        principalTable: "Classes",
                        principalColumn: "CId");
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "CId", "ClassName" },
                values: new object[,]
                {
                    { 1, "Mathematics" },
                    { 2, "Physics" },
                    { 3, "Chemistry" }
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "LId", "CId", "ClassCId", "Email", "Name" },
                values: new object[,]
                {
                    { 11L, 1, null, "john.doe@example.com", "John Doe" },
                    { 12L, 2, null, "jane.smith@example.com", "Jane Smith" },
                    { 13L, 3, null, "bob.johnson@example.com", "Bob Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "SId", "CId", "ClassCId", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1000, 1, null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@example.com", "John", "Doe" },
                    { 1001, 2, null, new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "janedoe@example.com", "Jane", "Doe" },
                    { 1003, 3, null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.brown@example.com", "Charlie", "Brown" },
                    { 1004, 1, null, new DateTime(2003, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.davis@example.com", "David", "Davis" },
                    { 1005, 2, null, new DateTime(2004, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.moore@example.com", "Emily", "Moore" },
                    { 1006, 3, null, new DateTime(2005, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "frank.adams@example.com", "Frank", "Adams" },
                    { 1007, 1, null, new DateTime(2006, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "grace.wright@example.com", "Grace", "Wright" },
                    { 1008, 2, null, new DateTime(2007, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "henry.scott@example.com", "Henry", "Scott" },
                    { 1009, 3, null, new DateTime(2008, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabella.taylor@example.com", "Isabella", "Taylor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_ClassCId",
                table: "Lecturers",
                column: "ClassCId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassCId",
                table: "Students",
                column: "ClassCId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
