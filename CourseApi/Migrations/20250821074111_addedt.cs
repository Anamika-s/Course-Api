using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApi.Migrations
{
    /// <inheritdoc />
    public partial class addedt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batch_Trainers_TrainerD",
                table: "Batch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batch",
                table: "Batch");

            migrationBuilder.RenameTable(
                name: "Batch",
                newName: "Batches");

            migrationBuilder.RenameColumn(
                name: "TrainerD",
                table: "Batches",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Batch_TrainerD",
                table: "Batches",
                newName: "IX_Batches_TrainerId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batches",
                table: "Batches",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_CourseId",
                table: "Batches",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Courses_CourseId",
                table: "Batches",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Trainers_TrainerId",
                table: "Batches",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Courses_CourseId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Trainers_TrainerId",
                table: "Batches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batches",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_CourseId",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Batches");

            migrationBuilder.RenameTable(
                name: "Batches",
                newName: "Batch");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Batch",
                newName: "TrainerD");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_TrainerId",
                table: "Batch",
                newName: "IX_Batch_TrainerD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batch",
                table: "Batch",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batch_Trainers_TrainerD",
                table: "Batch",
                column: "TrainerD",
                principalTable: "Trainers",
                principalColumn: "TrainerCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
