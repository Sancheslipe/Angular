using System.Linq;
using System.Threading.Tasks;
using EscolaApexWepApi.Data.interfaces;
using EscolaApexWepApi.models;
using Microsoft.EntityFrameworkCore;

namespace EscolaApexWepApi.Data.Services
{
    public class RepositorioDisciplina : IRepositorioDisciplina
    {
       private readonly DataContext _contexto;
       
        public RepositorioDisciplina(DataContext contexto)
        {
            this._contexto = contexto;
        }
        public async Task<Disciplina> ObterPeloIdAsync(int disciplinaId)
        {
            IQueryable<Disciplina> query = _contexto.Disciplina;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id)
                         .Where(c => c.Id == disciplinaId);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Disciplina[]> ObterTodasAsync(bool incluirProfessor)
        {
            IQueryable<Disciplina> query = _contexto.Disciplina;

            if (incluirProfessor)
            {
                query = query.Include(pe => pe.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
    }
}

