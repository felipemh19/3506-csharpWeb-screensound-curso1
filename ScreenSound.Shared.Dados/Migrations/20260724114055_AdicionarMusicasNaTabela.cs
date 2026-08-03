using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    public partial class AdicionarMusicasNaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Musicas", new string[]
            {
                "Nome",
                "AnoLancamento"
            }, new object[]
            {
                "Numb", 
                2003
            });

            migrationBuilder.InsertData("Musicas", new string[]
            {
                "Nome",
                "AnoLancamento"
            }, new object[]
            {
                "What I've done",
                2007
            });

            migrationBuilder.InsertData("Musicas", new string[]
            {
                "Nome",
                "AnoLancamento"
            }, new object[]
            {
                "In the end",
                2001
            });

            migrationBuilder.InsertData("Musicas", new string[]
            {
                "Nome",
                "AnoLancamento"
            }, new object[]
            {
                "First date",
                2001
            });

            migrationBuilder.InsertData("Musicas", new string[]
            {
                "Nome",
                "AnoLancamento"
            }, new object[]
            {
                "The Rock Show",
                2001
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musicas");
        }
    }
}
