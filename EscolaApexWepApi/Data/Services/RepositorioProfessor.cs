using System.Linq;
using System.Threading.Tasks;
using EscolaApexWepApi.Data;
using EscolaApexWepApi.Data.interfaces;
using EscolaApexWepApi.models;
using Microsoft.EntityFrameworkCore;

namespace EscolaApexWebApi.Data.Services
{
    public class RepositorioProfessor : IRepositorioProfessor
    {
        private readonly DataContext _contexto;

        public RepositorioProfessor(DataContext contexto)
        {
            this._contexto = contexto;
        }

        public async Task<Professor[]> ObterTodosAsync(bool incluirAluno)
        {   
            IQueryable<Professor> consulta = _contexto.Professor;
            
            if (incluirAluno)
            {
                consulta = consulta.Include(p => p.Disciplinas)
                                   .ThenInclude(d => d.AlunosDisciplinas)
                                   .ThenInclude(ad => ad.Aluno);
            }
            
            consulta = consulta.AsNoTracking().OrderBy(p => p.Id);

            return await consulta.ToArrayAsync();
        }

        public async Task<Professor> ObterProfessorPeloIdAsync(int professorId, bool incluirAluno)
        {
            //aqui defino em qual tabela desejo efetuar a consulta
            IQueryable<Professor> consulta = _contexto.Professor;
            
            //aqui estou dizendo que irei utilizar INNER JOIN na minha Consulta
            //onde para isso necessito ter as informações da FK
            //que foram definidas nos nossos models
            
            if (incluirAluno)
            {
                consulta = consulta.Include(pe => pe.Disciplinas)
                                   .ThenInclude(d => d.AlunosDisciplinas)
                                   .ThenInclude(ad => ad.Aluno);
            }
            
            //aqui estamos ordenando o resultado da consulta pelo ID do professor 
            //depois disso estamos filtrando na lista de professores o prodessor pelo Id
            consulta = consulta.AsNoTracking()
                               .OrderBy(p => p.Id)
                               .Where(p => p.Id == professorId);
            return await consulta.FirstOrDefaultAsync();
        }

        public async Task<Professor[]> ObterTodosPeloAlunoIdAsync(int alunoId, bool incluirDisciplina)
        {
            IQueryable<Professor> consulta = _contexto.Professor;

            if (incluirDisciplina)
            {
                consulta = consulta.Include(p => p.Disciplinas);
            }

            consulta = consulta.AsNoTracking()
                               .OrderBy(p => p.Id)
                               .Where(
                                   p => p.Disciplinas.Any(
                                       d => d.AlunosDisciplinas.Any(
                                           ad => ad.Aluno.Id == alunoId)
                                       )
                                   );

            return await consulta.ToArrayAsync();
        }
    }
}