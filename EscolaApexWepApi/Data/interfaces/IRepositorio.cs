using System.Threading.Tasks;

namespace EscolaApexWepApi.Data.interfaces
{
    public interface IRepositorio
    {
         void Adicionar<T>(T entidade) where T : class;
        void Atualizar<T>(T entidade) where T : class;
        void Deletar<T>(T entidade) where T : class;
        Task<bool> EfetuouAlteracoesAsync();
    }
}