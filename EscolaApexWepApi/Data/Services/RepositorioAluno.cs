using System.Linq;
using System.Threading.Tasks;
using EscolaApexWepApi.Data.interfaces;
using EscolaApexWepApi.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaApexWepApi.Data.Services
{
    public class RepositorioAluno : IRepositorioAluno
    {
        private readonly DataContext _contexto;

        public RepositorioAluno(DataContext contexto)
        {
            this._contexto = contexto;
        }
        public async Task<Aluno> ObterAlunoByIdAsync(int alunoId, bool incluirProfessor)
        {
            IQueryable<Aluno> consulta = _contexto.Aluno;

            if (incluirProfessor)
            {
                consulta = consulta.Include(a => a.AlunosDisciplinas)
                                    .ThenInclude(ad=> ad.Disciplina)
                                    .ThenInclude(d => d.Professor);


            }

            consulta = consulta.AsNoTracking()
                                .OrderBy(a=> a.Id)
                                .Where(a=> a.Id == alunoId);

            return await consulta.FirstOrDefaultAsync();
            
        }

        public async Task<Aluno[]> ObterTodos(bool incluirProfessor)
        {
            IQueryable<Aluno> consulta = _contexto.Aluno;

             if (incluirProfessor)
            {
                consulta = consulta.Include(a => a.AlunosDisciplinas)
                                    .ThenInclude(ad=> ad.Disciplina)
                                    .ThenInclude(d => d.Professor);


            }
            
            consulta=consulta.AsNoTracking().OrderBy(a => a.Id);
            return await consulta.ToArrayAsync();
        }

        public async Task<Aluno[]> ObterTodosPelaDisciplinaIdAsync(int disciplinaId, bool incluirProfessor)
        {
            IQueryable<Aluno> consulta = _contexto.Aluno;
             if (incluirProfessor)
            {
                consulta = consulta.Include(a => a.AlunosDisciplinas)
                                    .ThenInclude(ad=> ad.Disciplina);
            }
            
            consulta = consulta.AsNoTracking()
                                .OrderBy(a=> a.Id)
                                .Where(a=> a.AlunosDisciplinas.Any(
                                            ad => ad.DisciplinaId == disciplinaId
                                       )
                                    );
            return await consulta.ToArrayAsync();
        }
    
        
    }
}