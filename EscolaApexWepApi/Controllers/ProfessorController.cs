using System;
using System.Threading.Tasks;
using EscolaApexWepApi.Data.interfaces;
using EscolaApexWepApi.models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApexWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        private readonly IRepositorioProfessor _repositorioProfessor;

        public ProfessorController(IRepositorio repositorio,
                                   IRepositorioProfessor repositorioProfessor)
        {
            this._repositorio = repositorio;
            this._repositorioProfessor = repositorioProfessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    await _repositorioProfessor.ObterTodosAsync(incluirAluno: false)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os professores, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("professorid={professorId}")]
        public async Task<IActionResult> GetById(int professorId)
        {
            try
            {
                return Ok(
                    await _repositorioProfessor.ObterProfessorPeloIdAsync(professorId, incluirAluno: true)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter o professor, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("alunoid={alunoId}")]
        public async Task<IActionResult> GetByAlunoId(int alunoId)
        {
            try
            {
                return Ok(
                    await _repositorioProfessor.ObterTodosPeloAlunoIdAsync(alunoId, incluirDisciplina: false)
                );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os professores pelo id do aluno, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor professor)
        {
            try
            {
                _repositorio.Adicionar(professor);
                if (await this._repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(professor);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar o professor, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("professorid={professorId}")]
        public async Task<IActionResult> Put(int professorId, Professor professor)
        {
            try
            {
                var professorCadastrado = await _repositorioProfessor.ObterProfessorPeloIdAsync(professorId, incluirAluno: false);
                if (professorCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Atualizar(professor);
                if (await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(professor);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao atualizar o professor, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("professorid={professorId}")]
        public async Task<IActionResult> Delete(int professorId)
        {
            try
            {
                var professorCadastrado = await _repositorioProfessor.ObterProfessorPeloIdAsync(professorId, incluirAluno: false);
                if (professorCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Deletar(professorCadastrado);
                if (await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(
                        new {
                            message="Removido!"
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao remover o professor, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }
    }
}