using System.Threading.Tasks;
using EscolaApexWepApi.models;

namespace EscolaApexWepApi.Data.interfaces
{
    public interface IRepositorioDisciplina
    {
         Task<Disciplina[]>ObterTodasAsync(bool incluirProfessor);
         Task<Disciplina>ObterpeloIdAsync(int DisciplinaId);
    }
}