using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleBackEndTemplate.Infrastructure.Migrations.ApplicationDb
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gym_members_gym_membership_levels_MembershipLevelId",
                table: "gym_members");

            migrationBuilder.DropTable(
                name: "gym_membership_levels");

            migrationBuilder.DropIndex(
                name: "IX_gym_members_MembershipLevelId",
                table: "gym_members");

            migrationBuilder.DropColumn(
                name: "MembershipLevelId",
                table: "gym_members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembershipLevelId",
                table: "gym_members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "gym_membership_levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "varchar(767)", maxLength: 767, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    NumberOfMonths = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gym_membership_levels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "gym_membership_levels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "NumberOfMonths", "Price", "Title" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-month Validity Period; No Discount for Trainer Hiring", null, null, 2, 300, "Bronze" });

            migrationBuilder.InsertData(
                table: "gym_membership_levels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "NumberOfMonths", "Price", "Title" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7-month Validity Period; 30% Discount for Trainer Hiring;", null, null, 7, 700, "Silver" });

            migrationBuilder.InsertData(
                table: "gym_membership_levels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "NumberOfMonths", "Price", "Title" },
                values: new object[] { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12-month Validity Period; 70% Discount for Trainer Hiring;", null, null, 12, 850, "Gold" });

            migrationBuilder.CreateIndex(
                name: "IX_gym_members_MembershipLevelId",
                table: "gym_members",
                column: "MembershipLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_gym_members_gym_membership_levels_MembershipLevelId",
                table: "gym_members",
                column: "MembershipLevelId",
                principalTable: "gym_membership_levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
