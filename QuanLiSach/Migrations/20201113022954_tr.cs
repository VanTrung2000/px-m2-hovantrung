using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLiSach.Migrations
{
    public partial class tr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Despition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publishingyear = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CategorybookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_CategoryBooks_CategorybookId",
                        column: x => x.CategorybookId,
                        principalTable: "CategoryBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoryBooks",
                columns: new[] { "Id", "Category" },
                values: new object[] { 1, "Sách Giáo Trình" });

            migrationBuilder.InsertData(
                table: "CategoryBooks",
                columns: new[] { "Id", "Category" },
                values: new object[] { 2, "Sách Tiểu Thuyết" });

            migrationBuilder.InsertData(
                table: "CategoryBooks",
                columns: new[] { "Id", "Category" },
                values: new object[] { 3, "Sách Tâm Lý" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategorybookId", "Count", "Despition", "Namebook", "Publishingyear" },
                values: new object[] { 1, "Dale CarNeGie", 1, 1, null, "Đắc Nhân Tâm", 2016 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategorybookId", "Count", "Despition", "Namebook", "Publishingyear" },
                values: new object[] { 2, "David j.Lieberman", 2, 2, null, "Đọc Vị Bất Kì Ai", 2015 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategorybookId", "Count", "Despition", "Namebook", "Publishingyear" },
                values: new object[] { 3, "Robin Sharma", 3, 1, null, "Đời Ngắn Đừng Ngủ Dài", 2017 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategorybookId",
                table: "Books",
                column: "CategorybookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "CategoryBooks");
        }
    }
}
