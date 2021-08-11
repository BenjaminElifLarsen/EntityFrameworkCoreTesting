using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreTesting.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EFCore_Test1",
                columns: table => new
                {
                    Test1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Test1Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Test1Other = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFCore_Test1", x => x.Test1Id);
                });

            migrationBuilder.CreateTable(
                name: "EFCore_Test2",
                columns: table => new
                {
                    Test2Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Test1Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFCore_Test2", x => x.Test2Id);
                    table.ForeignKey(
                        name: "FK_EFCore_Test2_EFCore_Test1_Test1Id",
                        column: x => x.Test1Id,
                        principalTable: "EFCore_Test1",
                        principalColumn: "Test1Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EFCore_Test1",
                columns: new[] { "Test1Id", "Test1Name", "Test1Other" },
                values: new object[,]
                {
                    { 1, "Product", "123" },
                    { 2, "Entity", "Q" },
                    { 3, "Car", "Wif" },
                    { 4, "Hope", "Were" },
                    { 5, "Fear", "Dash" },
                    { 6, "Bus", "Crash" },
                    { 7, "EF Core", "C Sharp" }
                });

            migrationBuilder.InsertData(
                table: "EFCore_Test2",
                columns: new[] { "Test2Id", "Test1Id" },
                values: new object[,]
                {
                    { "T1-1", 1 },
                    { "T2-1", 1 },
                    { "T3-1", 1 },
                    { "T4-2", 2 },
                    { "T5-2", 2 },
                    { "T6-2", 2 },
                    { "T7-3", 3 },
                    { "T8-4", 4 },
                    { "T9-4", 4 },
                    { "T10-4", 4 },
                    { "T11-4", 4 },
                    { "T12-5", 5 },
                    { "T13-5", 5 },
                    { "T14-6", 6 },
                    { "T15-7", 7 },
                    { "T16-7", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EFCore_Test2_Test1Id",
                table: "EFCore_Test2",
                column: "Test1Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EFCore_Test2");

            migrationBuilder.DropTable(
                name: "EFCore_Test1");
        }
    }
}
