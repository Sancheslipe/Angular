using System.Threading.Tasks;
using EscolaApexWepApi.models;

namespace EscolaApexWepApi.Data.interfaces
{
    public interface IRepositorioProfessor
    {
        Task<Professor[]> ObterTodosAsync(bool incluirAluno);
         Task<Professor[]> ObterTodosPeloAlunoIdAsync(int alunoId ,bool incluirDisciplina);
         Task<Professor> ObterProfessorPeloIdAsync(int professorId ,bool incluirAluno);
    }
}