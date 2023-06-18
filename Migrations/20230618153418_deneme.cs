using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHORTURL.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_URL_ENTRIES",
                columns: table => new
                {
                    SHORTURL = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LongUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_URL_ENTRIES", x => x.SHORTURL);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_URL_ENTRIES");
        }
    }
}
