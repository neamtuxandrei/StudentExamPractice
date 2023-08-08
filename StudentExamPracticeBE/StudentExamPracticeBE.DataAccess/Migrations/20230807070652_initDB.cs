using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentExamPracticeBE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTask",
                columns: table => new
                {
                    ExamTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTask", x => new { x.ExamTaskId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentTask_ExamTasks_ExamTaskId",
                        column: x => x.ExamTaskId,
                        principalTable: "ExamTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTask_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExamTasks",
                columns: new[] { "Id", "Description", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("1b14d474-287f-44b5-81bd-36b698a8f78b"), "Parcurge in mod repetat lista element cu element comparand cu precedentul", "Created", "BubbleSort" },
                    { new Guid("817e3ded-3c2d-43e6-80e1-24781180f6f5"), "Efectuare comparatii pentru a sorta n elemente", "Created", "Quicksort" },
                    { new Guid("cc316902-a7f5-4da2-901b-f6d847a8590a"), "Creati 3 clase respectand principiile OOP.", "Created", "OOP design" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("0419bc13-75ef-418d-a685-595377a15df4"), "andrei89@yahoo.com", "Majon", "Andrei" },
                    { new Guid("0945c332-c3dd-4e9d-abc6-b1337e30e3c5"), "neamtuandrei26@yahoo.com", "Andrei", "Neamtu" },
                    { new Guid("3d92abb1-ad65-4a62-a46b-abce2e32c91c"), "ionescu@gmail.com", "Andrei", "Ionescu" },
                    { new Guid("7398dc1d-a056-4388-b6ce-7eae860d6ea7"), "vlad.lupu@gmail.com", "Vlad", "Lupu" },
                    { new Guid("a2b49aec-9851-4f84-a940-ca326b307e8b"), "dicu_aurel9@yahoo.com", "Aurel", "Dicu" },
                    { new Guid("a80e6beb-4d15-4418-a0a3-0fee512e43c1"), "baranescu@yahoo.com", "Andrei", "Baranescu" },
                    { new Guid("b5106a05-3d90-4691-b482-c21c85d93f1c"), "motoc212@yahoo.com", "Gabriel", "Motoc" },
                    { new Guid("c3a457b0-aa56-4ea4-9759-fc0b8e5aef27"), "tonceamihai99@yahoo.com", "Mihai", "Toncea" },
                    { new Guid("d15675d4-031b-4a7a-b6f9-9b2a32a315f5"), "anitaclaudiu@gmail.com", "Claudiu", "Anita" },
                    { new Guid("d34750a9-ae0d-4197-a118-6eb7adeed2a5"), "mihnea.sanda@gmail.com", "Mihnea", "Sanda" }
                });

            migrationBuilder.InsertData(
                table: "StudentTask",
                columns: new[] { "ExamTaskId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("1b14d474-287f-44b5-81bd-36b698a8f78b"), new Guid("0419bc13-75ef-418d-a685-595377a15df4") },
                    { new Guid("1b14d474-287f-44b5-81bd-36b698a8f78b"), new Guid("0945c332-c3dd-4e9d-abc6-b1337e30e3c5") },
                    { new Guid("1b14d474-287f-44b5-81bd-36b698a8f78b"), new Guid("7398dc1d-a056-4388-b6ce-7eae860d6ea7") },
                    { new Guid("1b14d474-287f-44b5-81bd-36b698a8f78b"), new Guid("d34750a9-ae0d-4197-a118-6eb7adeed2a5") },
                    { new Guid("817e3ded-3c2d-43e6-80e1-24781180f6f5"), new Guid("0945c332-c3dd-4e9d-abc6-b1337e30e3c5") },
                    { new Guid("817e3ded-3c2d-43e6-80e1-24781180f6f5"), new Guid("b5106a05-3d90-4691-b482-c21c85d93f1c") },
                    { new Guid("817e3ded-3c2d-43e6-80e1-24781180f6f5"), new Guid("d15675d4-031b-4a7a-b6f9-9b2a32a315f5") },
                    { new Guid("cc316902-a7f5-4da2-901b-f6d847a8590a"), new Guid("0945c332-c3dd-4e9d-abc6-b1337e30e3c5") },
                    { new Guid("cc316902-a7f5-4da2-901b-f6d847a8590a"), new Guid("3d92abb1-ad65-4a62-a46b-abce2e32c91c") },
                    { new Guid("cc316902-a7f5-4da2-901b-f6d847a8590a"), new Guid("a2b49aec-9851-4f84-a940-ca326b307e8b") },
                    { new Guid("cc316902-a7f5-4da2-901b-f6d847a8590a"), new Guid("b5106a05-3d90-4691-b482-c21c85d93f1c") },
                    { new Guid("cc316902-a7f5-4da2-901b-f6d847a8590a"), new Guid("c3a457b0-aa56-4ea4-9759-fc0b8e5aef27") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTask_StudentId",
                table: "StudentTask",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTask");

            migrationBuilder.DropTable(
                name: "ExamTasks");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
