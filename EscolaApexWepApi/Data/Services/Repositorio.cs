using System.Threading.Tasks;
using EscolaApexWepApi.Data.interfaces;

namespace EscolaApexWepApi.Data.Services
{
    public class Repositorio : IRepositorio
    {
        private readonly DataContext _contexto;
        public Repositorio(DataContext contexto)
        {
           this._contexto = contexto; 
        }
        public void Adicionar<T>(T entidade) where T : class
        {
            _contexto.Add(entidade);
        }

        public void Atualizar<T>(T entidade) where T : class
        {
            _contexto.Update(entidade);
        }

        public void Deletar<T>(T entidade) where T : class
        {
            _contexto.Remove(entidade);
        }

        public async Task<bool> EfetuouAlteracoesAsync()
        {
            return (await _contexto.SaveChangesAsync()) >0;
        }

    }
}