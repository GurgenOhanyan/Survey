using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Participants_ParticipantId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Participants",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ParticipantId",
                table: "Answers",
                newName: "ParticipantID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_ParticipantId",
                table: "Answers",
                newName: "IX_Answers_ParticipantID");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantID",
                table: "Answers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnswerValue",
                table: "Answers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "AnswerBool",
                table: "Answers",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Participants_ParticipantID",
                table: "Answers",
                column: "ParticipantID",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Participants_ParticipantID",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Participants",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "ParticipantID",
                table: "Answers",
                newName: "ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_ParticipantID",
                table: "Answers",
                newName: "IX_Answers_ParticipantId");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantId",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AnswerValue",
                table: "Answers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AnswerBool",
                table: "Answers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Participants_ParticipantId",
                table: "Answers",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
