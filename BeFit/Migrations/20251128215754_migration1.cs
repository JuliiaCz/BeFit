using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SesjaCwiczenia_Cwiczenie_CwiczenieId",
                table: "SesjaCwiczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_SesjaCwiczenia_Sesja_SesjaId",
                table: "SesjaCwiczenia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SesjaCwiczenia",
                table: "SesjaCwiczenia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sesja",
                table: "Sesja");

            migrationBuilder.RenameTable(
                name: "SesjaCwiczenia",
                newName: "SesjeCwiczenia");

            migrationBuilder.RenameTable(
                name: "Sesja",
                newName: "Sesje");

            migrationBuilder.RenameIndex(
                name: "IX_SesjaCwiczenia_SesjaId",
                table: "SesjeCwiczenia",
                newName: "IX_SesjeCwiczenia_SesjaId");

            migrationBuilder.RenameIndex(
                name: "IX_SesjaCwiczenia_CwiczenieId",
                table: "SesjeCwiczenia",
                newName: "IX_SesjeCwiczenia_CwiczenieId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StworzonePrzez",
                table: "SesjeCwiczenia",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SesjaId1",
                table: "SesjeCwiczenia",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StworzonePrzez",
                table: "Sesje",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SesjeCwiczenia",
                table: "SesjeCwiczenia",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sesje",
                table: "Sesje",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cwiczenie_Name",
                table: "Cwiczenie",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SesjeCwiczenia_CreatedById",
                table: "SesjeCwiczenia",
                column: "StworzonePrzez");

            migrationBuilder.CreateIndex(
                name: "IX_SesjeCwiczenia_SesjaId1",
                table: "SesjeCwiczenia",
                column: "SesjaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sesje_CreatedById",
                table: "Sesje",
                column: "StworzonePrzez");

            migrationBuilder.AddForeignKey(
                name: "FK_Sesje_AspNetUsers_CreatedById",
                table: "Sesje",
                column: "StworzonePrzez",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SesjeCwiczenia_AspNetUsers_CreatedById",
                table: "SesjeCwiczenia",
                column: "StworzonePrzez",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SesjeCwiczenia_Cwiczenie_CwiczenieId",
                table: "SesjeCwiczenia",
                column: "CwiczenieId",
                principalTable: "Cwiczenie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SesjeCwiczenia_Sesje_SesjaId",
                table: "SesjeCwiczenia",
                column: "SesjaId",
                principalTable: "Sesje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SesjeCwiczenia_Sesje_SesjaId1",
                table: "SesjeCwiczenia",
                column: "SesjaId1",
                principalTable: "Sesje",
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

            migrationBuilder.DropForeignKey(
                name: "FK_SesjeCwiczenia_Cwiczenie_CwiczenieId",
                table: "SesjeCwiczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_SesjeCwiczenia_Sesje_SesjaId",
                table: "SesjeCwiczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_SesjeCwiczenia_Sesje_SesjaId1",
                table: "SesjeCwiczenia");

            migrationBuilder.DropIndex(
                name: "IX_Cwiczenie_Name",
                table: "Cwiczenie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SesjeCwiczenia",
                table: "SesjeCwiczenia");

            migrationBuilder.DropIndex(
                name: "IX_SesjeCwiczenia_CreatedById",
                table: "SesjeCwiczenia");

            migrationBuilder.DropIndex(
                name: "IX_SesjeCwiczenia_SesjaId1",
                table: "SesjeCwiczenia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sesje",
                table: "Sesje");

            migrationBuilder.DropIndex(
                name: "IX_Sesje_CreatedById",
                table: "Sesje");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StworzonePrzez",
                table: "SesjeCwiczenia");

            migrationBuilder.DropColumn(
                name: "SesjaId1",
                table: "SesjeCwiczenia");

            migrationBuilder.DropColumn(
                name: "StworzonePrzez",
                table: "Sesje");

            migrationBuilder.RenameTable(
                name: "SesjeCwiczenia",
                newName: "SesjaCwiczenia");

            migrationBuilder.RenameTable(
                name: "Sesje",
                newName: "Sesja");

            migrationBuilder.RenameIndex(
                name: "IX_SesjeCwiczenia_SesjaId",
                table: "SesjaCwiczenia",
                newName: "IX_SesjaCwiczenia_SesjaId");

            migrationBuilder.RenameIndex(
                name: "IX_SesjeCwiczenia_CwiczenieId",
                table: "SesjaCwiczenia",
                newName: "IX_SesjaCwiczenia_CwiczenieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SesjaCwiczenia",
                table: "SesjaCwiczenia",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sesja",
                table: "Sesja",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SesjaCwiczenia_Cwiczenie_CwiczenieId",
                table: "SesjaCwiczenia",
                column: "CwiczenieId",
                principalTable: "Cwiczenie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SesjaCwiczenia_Sesja_SesjaId",
                table: "SesjaCwiczenia",
                column: "SesjaId",
                principalTable: "Sesja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
