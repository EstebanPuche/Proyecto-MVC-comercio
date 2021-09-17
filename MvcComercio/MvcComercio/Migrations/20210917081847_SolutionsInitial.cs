using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcComercio.Migrations
{
    public partial class SolutionsInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Disco",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<decimal>(
            //    name: "Precio",
            //    table: "Disco",
            //    type: "decimal(18, 2",
            //    nullable: false,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(18, 2)");
        }
    }
}
