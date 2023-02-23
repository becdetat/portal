using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class FixTablePluralization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Profiles_ProfileId",
                table: "Bookmark");

            migrationBuilder.DropForeignKey(
                name: "FK_NavigationItem_Profiles_ProfileId",
                table: "NavigationItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NavigationItem",
                table: "NavigationItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark");

            migrationBuilder.RenameTable(
                name: "NavigationItem",
                newName: "NavigationItems");

            migrationBuilder.RenameTable(
                name: "Bookmark",
                newName: "Bookmarks");

            migrationBuilder.RenameIndex(
                name: "IX_NavigationItem_ProfileId",
                table: "NavigationItems",
                newName: "IX_NavigationItems_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmark_ProfileId",
                table: "Bookmarks",
                newName: "IX_Bookmarks_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NavigationItems",
                table: "NavigationItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Profiles_ProfileId",
                table: "Bookmarks",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NavigationItems_Profiles_ProfileId",
                table: "NavigationItems",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Profiles_ProfileId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_NavigationItems_Profiles_ProfileId",
                table: "NavigationItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NavigationItems",
                table: "NavigationItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.RenameTable(
                name: "NavigationItems",
                newName: "NavigationItem");

            migrationBuilder.RenameTable(
                name: "Bookmarks",
                newName: "Bookmark");

            migrationBuilder.RenameIndex(
                name: "IX_NavigationItems_ProfileId",
                table: "NavigationItem",
                newName: "IX_NavigationItem_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_ProfileId",
                table: "Bookmark",
                newName: "IX_Bookmark_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NavigationItem",
                table: "NavigationItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Profiles_ProfileId",
                table: "Bookmark",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NavigationItem_Profiles_ProfileId",
                table: "NavigationItem",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
