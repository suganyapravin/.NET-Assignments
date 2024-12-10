using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "MemberBorrow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Checkouttime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberBorrow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberFullname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Membersince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "RoleViews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ViewID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleViews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffFullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StaffUsername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    joiningdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublishYear = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookCategoryCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_BookCategory_BookCategoryCategoryId",
                        column: x => x.BookCategoryCategoryId,
                        principalTable: "BookCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Drama" },
                    { 3, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "CreatedBy", "CreatedDate", "IsActive", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 12, 10, 17, 56, 31, 116, DateTimeKind.Utc).AddTicks(7828), true, "Librarian", 0 },
                    { 2, 0, new DateTime(2024, 12, 10, 17, 56, 31, 116, DateTimeKind.Utc).AddTicks(8038), true, "Staff", 0 },
                    { 3, 0, new DateTime(2024, 12, 10, 17, 56, 31, 116, DateTimeKind.Utc).AddTicks(8040), true, "Member", 0 }
                });

            migrationBuilder.InsertData(
                table: "Views",
                columns: new[] { "Id", "VName" },
                values: new object[,]
                {
                    { 1, "Add Staff" },
                    { 2, "Add Books" },
                    { 3, "View Reports" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookCategoryCategoryId",
                table: "Book",
                column: "BookCategoryCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "MemberBorrow");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "RoleViews");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.DropTable(
                name: "BookCategory");
        }
    }
}
