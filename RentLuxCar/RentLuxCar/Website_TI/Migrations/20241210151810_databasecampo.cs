using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_TI.Migrations
{
    /// <inheritdoc />
    public partial class databasecampo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Motor",
                table: "Viaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Peso",
                table: "Viaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Potencia",
                table: "Viaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transmissao",
                table: "Viaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vmax",
                table: "Viaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "aceleracao",
                table: "Viaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Motor",
                table: "Viaturas");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Viaturas");

            migrationBuilder.DropColumn(
                name: "Potencia",
                table: "Viaturas");

            migrationBuilder.DropColumn(
                name: "Transmissao",
                table: "Viaturas");

            migrationBuilder.DropColumn(
                name: "Vmax",
                table: "Viaturas");

            migrationBuilder.DropColumn(
                name: "aceleracao",
                table: "Viaturas");
        }
    }
}
