using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleBackEndTemplate.Infrastructure.Migrations.ApplicationDb
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Unq_MemberCode",
                table: "gym_members");

            migrationBuilder.DropColumn(
                name: "MemberCode",
                table: "gym_members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberCode",
                table: "gym_members",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "Unq_MemberCode",
                table: "gym_members",
                column: "MemberCode",
                unique: true);
        }
    }
}
