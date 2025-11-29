using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sesje_AspNetUsers_StworzonePrzez",
                table: "Sesje");

            migrationBuilder.DropForeignKey(
                name: "FK_SesjeCwiczenia_AspNetUsers_StworzonePrzez",
                table: "SesjeCwiczenia");

            migrationBuilder.DropIndex(
                name: "IX_SesjeCwiczenia_StworzonePrzez",
                table: "SesjeCwiczenia");

            migrationBuilder.DropIndex(
                name: "IX_Sesje_StworzonePrzez",
                table: "Sesje");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "SesjeCwiczenia",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Sesje",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SesjeCwiczenia_CreatedById",
                table: "SesjeCwiczenia",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Sesje_CreatedById",
                table: "Sesje",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesje_AspNetUsers_CreatedById",
                table: "Sesje",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SesjeCwiczenia_AspNetUsers_CreatedById",
                table: "SesjeCwiczenia",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sesje_AspNetUsers_CreatedById",
                table: "Sesje");

            migrationBuilder.DropForeignKey(
                name: "FK_SesjeCwiczenia_AspNetUsers_CreatedById",
                table: "SesjeCwiczenia");

            migrationBuilder.DropIndex(
                name: "IX_SesjeCwiczenia_CreatedById",
                table: "SesjeCwiczenia");

            migrationBuilder.DropIndex(
                name: "IX_Sesje_CreatedById",
                table: "Sesje");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SesjeCwiczenia");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Sesje");

            migrationBuilder.CreateIndex(
                name: "IX_SesjeCwiczenia_StworzonePrzez",
                table: "SesjeCwiczenia",
                column: "StworzonePrzez");

            migrationBuilder.CreateIndex(
                name: "IX_Sesje_StworzonePrzez",
                table: "Sesje",
                column: "StworzonePrzez");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesje_AspNetUsers_StworzonePrzez",
                table: "Sesje",
                column: "StworzonePrzez",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SesjeCwiczenia_AspNetUsers_StworzonePrzez",
                table: "SesjeCwiczenia",
                column: "StworzonePrzez",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
