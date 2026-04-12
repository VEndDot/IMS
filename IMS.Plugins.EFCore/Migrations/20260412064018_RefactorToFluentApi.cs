using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Plugins.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class RefactorToFluentApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user_account",
                table: "user_account");

            migrationBuilder.RenameTable(
                name: "user_account",
                newName: "User_account");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "User_account",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "User_account",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "User_account",
                newName: "First_name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "User_account",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_account",
                table: "User_account",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_account",
                table: "User_account");

            migrationBuilder.RenameTable(
                name: "User_account",
                newName: "user_account");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "user_account",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "user_account",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "First_name",
                table: "user_account",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_account",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_account",
                table: "user_account",
                column: "id");
        }
    }
}
