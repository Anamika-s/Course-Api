using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApi.Migrations
{
    /// <inheritdoc />
    public partial class addedcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "user1",
                columns: new[] { "Address", "FirstName", "LastName", "MobileNumber" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "user2",
                columns: new[] { "Address", "FirstName", "LastName", "MobileNumber" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "user3",
                columns: new[] { "Address", "FirstName", "LastName", "MobileNumber" },
                values: new object[] { null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Users");
        }
    }
}
