using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN221_DinhChinh_Ass3.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatebookprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priced",
                table: "Books",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Books",
                newName: "Priced");
        }
    }
}
