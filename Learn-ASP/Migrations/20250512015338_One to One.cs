using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learn_ASP.Migrations
{
    /// <inheritdoc />
    public partial class OnetoOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerialNumberID",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "serialNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serialNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_serialNumbers_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Price", "SerialNumberID" },
                values: new object[] { 4, "Keyboard", 200000.0, 10 });

            migrationBuilder.InsertData(
                table: "serialNumbers",
                columns: new[] { "Id", "ItemID", "Name" },
                values: new object[] { 10, 4, "KEY001" });

            migrationBuilder.CreateIndex(
                name: "IX_serialNumbers_ItemID",
                table: "serialNumbers",
                column: "ItemID",
                unique: true,
                filter: "[ItemID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "serialNumbers");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "SerialNumberID",
                table: "Items");
        }
    }
}
