using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revolutionary.Migrations.Application
{
    public partial class CreateDatabaseSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InviteCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InviteCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Class = table.Column<string>(nullable: false),
                    StudentCode = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Session = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassRegister",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRegister_Class_UserId",
                        column: x => x.UserId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRegister_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    Theory = table.Column<float>(nullable: false),
                    Practical = table.Column<float>(nullable: false),
                    Assignment = table.Column<float>(nullable: false),
                    Penalty = table.Column<float>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mark_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mark_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InviteCode",
                columns: new[] { "Id", "Code", "CreatedAt", "RoleId", "Status", "UpdatedAt" },
                values: new object[] { 1, "AAAAAA", new DateTime(2019, 1, 7, 15, 41, 24, 691, DateTimeKind.Local).AddTicks(5726), 1, 1, new DateTime(2019, 1, 7, 15, 41, 24, 692, DateTimeKind.Local).AddTicks(8562) });

            migrationBuilder.InsertData(
                table: "InviteCode",
                columns: new[] { "Id", "Code", "CreatedAt", "RoleId", "Status", "UpdatedAt" },
                values: new object[] { 2, "BBBBBB", new DateTime(2019, 1, 7, 15, 41, 24, 693, DateTimeKind.Local).AddTicks(963), 0, 1, new DateTime(2019, 1, 7, 15, 41, 24, 693, DateTimeKind.Local).AddTicks(969) });

            migrationBuilder.CreateIndex(
                name: "IX_Class_SubjectId",
                table: "Class",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRegister_UserId",
                table: "ClassRegister",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_ClassId",
                table: "Mark",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_UserId",
                table: "Mark",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassRegister");

            migrationBuilder.DropTable(
                name: "InviteCode");

            migrationBuilder.DropTable(
                name: "Mark");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
