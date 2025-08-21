using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApi.Migrations
{
    /// <inheritdoc />
    public partial class addeedfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batch_Trainers_TrainerCode1",
                table: "Batch");

            migrationBuilder.DropIndex(
                name: "IX_Batch_TrainerCode1",
                table: "Batch");

            migrationBuilder.DropColumn(
                name: "TrainerCode1",
                table: "Batch");

            migrationBuilder.RenameColumn(
                name: "TrainerCode",
                table: "Batch",
                newName: "TrainerD");

            migrationBuilder.CreateIndex(
                name: "IX_Batch_TrainerD",
                table: "Batch",
                column: "TrainerD");

            migrationBuilder.AddForeignKey(
                name: "FK_Batch_Trainers_TrainerD",
                table: "Batch",
                column: "TrainerD",
                principalTable: "Trainers",
                principalColumn: "TrainerCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batch_Trainers_TrainerD",
                table: "Batch");

            migrationBuilder.DropIndex(
                name: "IX_Batch_TrainerD",
                table: "Batch");

            migrationBuilder.RenameColumn(
                name: "TrainerD",
                table: "Batch",
                newName: "TrainerCode");

            migrationBuilder.AddColumn<int>(
                name: "TrainerCode1",
                table: "Batch",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batch_TrainerCode1",
                table: "Batch",
                column: "TrainerCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Batch_Trainers_TrainerCode1",
                table: "Batch",
                column: "TrainerCode1",
                principalTable: "Trainers",
                principalColumn: "TrainerCode");
        }
    }
}
