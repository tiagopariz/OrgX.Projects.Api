using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrgX.Projects.Api.Infra.Migrations
{
    [ExcludeFromCodeCoverage]
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IX_dbo_User_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "History",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Entity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Field = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrimaryKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IX_dbo_History_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_History_UserId_dbo_User_Id",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IX_dbo_Project_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_Project_UserId_dbo_User_Id",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    Priority = table.Column<short>(type: "smallint", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IX_dbo_Task_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_Task_ProjectId_dbo_Project_Id",
                        column: x => x.ProjectId,
                        principalSchema: "dbo",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IX_dbo_Comment_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_Comment_TaskId_dbo_Task_Id",
                        column: x => x.TaskId,
                        principalSchema: "dbo",
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "Id", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"), "User", "tiagopariz" },
                    { new Guid("4ee007a2-e556-46cb-941d-0472aec0fe9b"), "Manager", "vangogh" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "History",
                columns: new[] { "Id", "Entity", "Field", "NewValue", "Operation", "PrimaryKeyId", "RegisterDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("08929b27-a7f2-445b-acdb-1fb6dbe4bf23"), "Task", "Id", "66e7562d-3719-4da6-bdcb-95c2e38c80a1", "INSERT", new Guid("66e7562d-3719-4da6-bdcb-95c2e38c80a1"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8926), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("1920161c-e3c8-4f18-a2d0-8092cb948e6d"), "Project", "UserId", "2bd26aa6-5344-4e51-b4b8-144bfb631f3f", "INSERT", new Guid("beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8924), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("1ae61421-4cf9-4637-b82f-4d87836ad5d5"), "Task", "Title", "Task 1 - Project 1", "INSERT", new Guid("66e7562d-3719-4da6-bdcb-95c2e38c80a1"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8928), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("31f4bfea-3e2f-4bbd-86ab-fe6bbcb9d2ab"), "Task", "Status", "0", "INSERT", new Guid("66e7562d-3719-4da6-bdcb-95c2e38c80a1"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8932), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("46aeda78-0638-44cd-a8ea-2f6952b58c9b"), "Project", "Title", "Project 1", "INSERT", new Guid("beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8922), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("5eb7ee91-93cc-4cfd-aded-36b4d460f893"), "Task", "ProjectId", "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d", "INSERT", new Guid("66e7562d-3719-4da6-bdcb-95c2e38c80a1"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8957), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("7bef5d49-7472-41e4-8c75-d7f865f80c00"), "Task", "Detail", "Task 1 of Project 1", "INSERT", new Guid("66e7562d-3719-4da6-bdcb-95c2e38c80a1"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8930), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("ab1d3044-06fe-4c12-a18c-cad69f8dfb06"), "User", "Role", "Manager", "INSERT", new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8963), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("b74fdba2-7756-4669-8142-0b202248a598"), "User", "Id", "2bd26aa6-5344-4e51-b4b8-144bfb631f3f", "INSERT", new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8959), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("bc4237d4-a5f6-4103-99f5-80550f5db8d7"), "Project", "Id", "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d", "INSERT", new Guid("beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8909), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("f4def38d-7b80-4e71-9635-8c5859f4997b"), "Task", "Priority", "0", "INSERT", new Guid("66e7562d-3719-4da6-bdcb-95c2e38c80a1"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8955), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") },
                    { new Guid("f8fc53ec-e65c-42c1-a367-50fb714e8c32"), "User", "Username", "tiagopariz", "INSERT", new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"), new DateTime(2024, 2, 16, 21, 8, 32, 708, DateTimeKind.Local).AddTicks(8961), new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Project",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { new Guid("beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"), "Project 1", new Guid("2bd26aa6-5344-4e51-b4b8-144bfb631f3f") });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Task",
                columns: new[] { "Id", "Detail", "EndDate", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { new Guid("66e7562d-3719-4da6-bdcb-95c2e38c80a1"), "Task 1 of Project 1", null, (short)0, new Guid("beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"), (short)0, "Task 1 - Project 1" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Comment",
                columns: new[] { "Id", "Content", "TaskId" },
                values: new object[] { new Guid("c56b72d6-4716-45eb-bd5a-57b89d6dcff0"), "Comment 1 - Task 1", new Guid("66e7562d-3719-4da6-bdcb-95c2e38c80a1") });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_TaskId",
                schema: "dbo",
                table: "Comment",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_History_UserId",
                schema: "dbo",
                table: "History",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Project_Title",
                schema: "dbo",
                table: "Project",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserId",
                schema: "dbo",
                table: "Project",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Task_Title",
                schema: "dbo",
                table: "Task",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectId",
                schema: "dbo",
                table: "Task",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_User_Username",
                schema: "dbo",
                table: "User",
                column: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "History",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Task",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");
        }
    }
}
