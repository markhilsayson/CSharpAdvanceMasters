using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment_01.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Author", "Description", "IsAvailable", "Title", "Year" },
                values: new object[,]
                {
                    { "mss01", "Frank Darabont", "Directed by Frank Darabont, based on the novel Rita Hayworth and Shawshank Redemption by Stephen King.", true, "The Shawshank Redemption", "1994" },
                    { "mss02", "Francis Ford Coppola", "Directed by Francis Ford Coppola, based on the novel of the same name by Mario Puzo.", true, "The Godfather", "2016" },
                    { "mss03", "Christopher Nolan", "Directed by Christopher Nolan, co-written by Nolan, David S. Goyer, and Jonathan Nolan. Based on the DC Comics character Batman created by Bob Kane and Bill Finger.", true, "The Dark Knight", "2008" },
                    { "mss04", "Quentin Tarantino", "Written and Directed by Quentin Tarantino", true, "Pulp Fiction", "1994" },
                    { "mss05", "Martin Scorsese", "Directed by Martin Scorsese, based on the 1986 non-fiction book Wiseguy by Nicholas Pileggi.", true, "Goodfellas", "1990" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: "mss01");

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: "mss02");

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: "mss03");

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: "mss04");

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: "mss05");
        }
    }
}
