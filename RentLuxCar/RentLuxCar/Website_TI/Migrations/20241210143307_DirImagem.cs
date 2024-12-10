using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_TI.Migrations
{
    /// <inheritdoc />
    public partial class DirImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DirImagem",
                table: "Viaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirImagem",
                table: "Viaturas");
        }
    }
}
