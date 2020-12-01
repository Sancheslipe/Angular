using System.Threading.Tasks;
using EscolaApexWepApi.models;

namespace EscolaApexWepApi.Data.interfaces
{
    public interface IRepositoryProfessor
    {
        Task<Professor[]> ObterTodosByidasync(bool IncluirAluno);
         Task<Professor[]> ObterTodosPeloAlunoIdAsync(int AlunoId ,bool IncluirDisciplina);
         Task<Professor[]> ObterpeloIdByIdAsync(int professor ,bool IncluirAluno);
    }
}