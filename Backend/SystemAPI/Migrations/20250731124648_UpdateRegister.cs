using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRolleri_Roller_RoleID",
                table: "KullaniciRolleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roller",
                table: "Roller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KullaniciRolleri",
                table: "KullaniciRolleri");

            migrationBuilder.RenameTable(
                name: "Roller",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "KullaniciRolleri",
                newName: "UserRoleJoins");

            migrationBuilder.RenameIndex(
                name: "IX_KullaniciRolleri_RoleID",
                table: "UserRoleJoins",
                newName: "IX_UserRoleJoins_RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleJoins",
                table: "UserRoleJoins",
                columns: new[] { "UserID", "RoleID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleJoins_Roles_RoleID",
                table: "UserRoleJoins",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleJoins_Roles_RoleID",
                table: "UserRoleJoins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleJoins",
                table: "UserRoleJoins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "UserRoleJoins",
                newName: "KullaniciRolleri");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roller");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleJoins_RoleID",
                table: "KullaniciRolleri",
                newName: "IX_KullaniciRolleri_RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KullaniciRolleri",
                table: "KullaniciRolleri",
                columns: new[] { "UserID", "RoleID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roller",
                table: "Roller",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRolleri_Roller_RoleID",
                table: "KullaniciRolleri",
                column: "RoleID",
                principalTable: "Roller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
