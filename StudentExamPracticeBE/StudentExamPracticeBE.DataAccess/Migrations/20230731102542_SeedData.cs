using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentExamPracticeBE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
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
                    { new Guid("9e727cee-e590-4a99-a6c6-8618824bdf56"), "Parcurge in mod repetat lista element cu element comparand cu precedentul", "Created", "BubbleSort" },
                    { new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"), "Creati 3 clase respectand principiile OOP.", "Created", "OOP design" },
                    { new Guid("b85c580d-c6fd-4ad9-86dd-bf6ca587915c"), "Efectuare comparatii pentru a sorta n elemente", "Created", "Quicksort" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("0b1fff26-ebb9-405e-ba20-b401d22c9dbc"), "andrei89@yahoo.com", "Majon", "Andrei" },
                    { new Guid("0dbd5e04-670c-4886-88f3-9659d1541965"), "anitaclaudiu@gmail.com", "Claudiu", "Anita" },
                    { new Guid("189752e7-0093-4497-9a75-9b6684a39aa6"), "mihnea.sanda@gmail.com", "Mihnea", "Sanda" },
                    { new Guid("1f2dc7e1-3a5d-43ba-9234-1c256f9f09d3"), "dicu_aurel9@yahoo.com", "Aurel", "Dicu" },
                    { new Guid("3c0250b0-4d43-420f-9dfc-c7ce4d890945"), "ionescu@gmail.com", "Andrei", "Ionescu" },
                    { new Guid("466daa7b-2238-4119-b133-c73fbc991f30"), "vlad.lupu@gmail.com", "Vlad", "Lupu" },
                    { new Guid("583b3dcc-1135-482f-a7a2-f2e7699b1b61"), "neamtuandrei26@yahoo.com", "Andrei", "Neamtu" },
                    { new Guid("8e2df4ea-4825-4961-8c54-fe3e372b2133"), "motoc212@yahoo.com", "Gabriel", "Motoc" },
                    { new Guid("c9710c8a-72fb-40e7-b5bf-e94d8cbce9c3"), "baranescu@yahoo.com", "Andrei", "Baranescu" },
                    { new Guid("d26a3312-d30b-4419-b496-2608cd5ed504"), "tonceamihai99@yahoo.com", "Mihai", "Toncea" }
                });

            migrationBuilder.InsertData(
                table: "StudentTask",
                columns: new[] { "ExamTaskId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("9e727cee-e590-4a99-a6c6-8618824bdf56"), new Guid("0b1fff26-ebb9-405e-ba20-b401d22c9dbc") },
                    { new Guid("9e727cee-e590-4a99-a6c6-8618824bdf56"), new Guid("189752e7-0093-4497-9a75-9b6684a39aa6") },
                    { new Guid("9e727cee-e590-4a99-a6c6-8618824bdf56"), new Guid("466daa7b-2238-4119-b133-c73fbc991f30") },
                    { new Guid("9e727cee-e590-4a99-a6c6-8618824bdf56"), new Guid("583b3dcc-1135-482f-a7a2-f2e7699b1b61") },
                    { new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"), new Guid("1f2dc7e1-3a5d-43ba-9234-1c256f9f09d3") },
                    { new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"), new Guid("3c0250b0-4d43-420f-9dfc-c7ce4d890945") },
                    { new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"), new Guid("583b3dcc-1135-482f-a7a2-f2e7699b1b61") },
                    { new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"), new Guid("8e2df4ea-4825-4961-8c54-fe3e372b2133") },
                    { new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"), new Guid("d26a3312-d30b-4419-b496-2608cd5ed504") },
                    { new Guid("b85c580d-c6fd-4ad9-86dd-bf6ca587915c"), new Guid("0dbd5e04-670c-4886-88f3-9659d1541965") },
                    { new Guid("b85c580d-c6fd-4ad9-86dd-bf6ca587915c"), new Guid("583b3dcc-1135-482f-a7a2-f2e7699b1b61") },
                    { new Guid("b85c580d-c6fd-4ad9-86dd-bf6ca587915c"), new Guid("8e2df4ea-4825-4961-8c54-fe3e372b2133") }
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
