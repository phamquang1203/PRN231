using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _26_BuiVanToan_Slot6.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gadgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gadgets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Gadgets",
                columns: new[] { "Id", "Brand", "Cost", "ProductName", "Type" },
                values: new object[,]
                {
                    { 1, "Samsung", 12000m, "Samsung Galaxy", "Mobile" },
                    { 2, "Apple", 13000m, "Iphone", "Mobile" },
                    { 3, "IBM", 34999m, "IBM Thinkpad", "Laptop" },
                    { 4, "HP", 21000m, "HP ProBook", "Laptop" },
                    { 5, "Nokia", 11000m, "Nokia 9222", "Mobile" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gadgets");
        }
    }
}
