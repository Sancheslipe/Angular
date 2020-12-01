using System.Threading.Tasks;
using EscolaApexWepApi.models;

namespace EscolaApexWepApi.Data.interfaces
{
    public interface IRepositorioAluno
    {
         Task<Aluno[]> ObterTodosPelaDisciplinaIdAsync(int disciplinaId ,bool incluirProfessor);
         Task<Aluno[]> ObterTodos(bool incluirProfessor);
         Task<Aluno> ObterAlunoByIdAsync(int alunoId ,bool incluirProfessor);

    }
}