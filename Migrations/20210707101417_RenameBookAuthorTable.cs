using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookish.Migrations
{
    public partial class RenameBookAuthorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorDbModelBookDbModel_Authors_AuthorsId",
                table: "AuthorDbModelBookDbModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorDbModelBookDbModel_Books_BooksId",
                table: "AuthorDbModelBookDbModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorDbModelBookDbModel",
                table: "AuthorDbModelBookDbModel");

            migrationBuilder.RenameTable(
                name: "AuthorDbModelBookDbModel",
                newName: "BookAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorDbModelBookDbModel_BooksId",
                table: "BookAuthors",
                newName: "IX_BookAuthors_BooksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                columns: new[] { "AuthorsId", "BooksId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_AuthorsId",
                table: "BookAuthors",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_BooksId",
                table: "BookAuthors",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_AuthorsId",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_BooksId",
                table: "BookAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.RenameTable(
                name: "BookAuthors",
                newName: "AuthorDbModelBookDbModel");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthors_BooksId",
                table: "AuthorDbModelBookDbModel",
                newName: "IX_AuthorDbModelBookDbModel_BooksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorDbModelBookDbModel",
                table: "AuthorDbModelBookDbModel",
                columns: new[] { "AuthorsId", "BooksId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorDbModelBookDbModel_Authors_AuthorsId",
                table: "AuthorDbModelBookDbModel",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorDbModelBookDbModel_Books_BooksId",
                table: "AuthorDbModelBookDbModel",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
