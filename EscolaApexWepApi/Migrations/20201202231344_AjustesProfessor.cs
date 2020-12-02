using Microsoft.EntityFrameworkCore.Migrations;

namespace EscolaApexWepApi.Migrations
{
    public partial class AjustesProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplina_professor_ProfessorId",
                table: "AlunoDisciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_professor_professorId",
                table: "Disciplina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_professor",
                table: "professor");

            migrationBuilder.DropIndex(
                name: "IX_AlunoDisciplina_ProfessorId",
                table: "AlunoDisciplina");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "AlunoDisciplina");

            migrationBuilder.RenameTable(
                name: "professor",
                newName: "Professor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professor",
                table: "Professor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_professorId",
                table: "Disciplina",
                column: "professorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_professorId",
                table: "Disciplina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professor",
                table: "Professor");

            migrationBuilder.RenameTable(
                name: "Professor",
                newName: "professor");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "AlunoDisciplina",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_professor",
                table: "professor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplina_ProfessorId",
                table: "AlunoDisciplina",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplina_professor_ProfessorId",
                table: "AlunoDisciplina",
                column: "ProfessorId",
                principalTable: "professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_professor_professorId",
                table: "Disciplina",
                column: "professorId",
                principalTable: "professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
