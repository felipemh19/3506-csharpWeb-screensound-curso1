using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    public partial class PopularTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas", new string[]
            {
                "Nome",
                "Bio",
                "FotoPerfil",
            }, new object[]
            {
                "Linkin Park",
                "Banda poggers",
                "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png"
            });

            migrationBuilder.InsertData("Artistas", new string[]
            {
                "Nome",
                "Bio",
                "FotoPerfil",
            }, new object[]
            {
                "Foo Fighters",
                "Banda do Dave Grohl",
                "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png"
            });

            migrationBuilder.InsertData("Artistas", new string[]
            {
                "Nome",
                "Bio",
                "FotoPerfil",
            }, new object[]
            {
                "Blink-182",
                "Banda de pop-punk poggers",
                "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png"
            });

            migrationBuilder.InsertData("Artistas", new string[]
            {
                "Nome",
                "Bio",
                "FotoPerfil",
            }, new object[]
            {
                "Djavan",
                "Cantor e ex-futebolista",
                "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png"
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas");
        }
    }
}
