using System;
using System.Threading.Tasks;
using EscolaApexWepApi.Data.interfaces;
using EscolaApexWepApi.models;
using Microsoft.AspNetCore.Mvc;

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
            var result = await _repositorioProfessor.ObterTodosAsync(false);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("{professorId}")]
    public async Task<IActionResult> GetByProfessorId(int professorId)
    {
        try
        {
            var result = await _repositorioProfessor.ObterProfessorPeloIdAsync(professorId, true);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpGet("alunoId={alunoId}")]
    public async Task<IActionResult> GetByAlunoId(int alunoId)
    {
        try
        {
            var result = await _repositorioProfessor.ObterTodosPeloAlunoIdAsync(alunoId, true);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> post(Professor model)
    {
        try
        {
            _repositorio.Adicionar(model);

            if (await _repositorio.EfetuouAlteracoesAsync())
            {
                return Ok(model);
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }

        return BadRequest();
    }

    [HttpPut("{professorId}")]
    public async Task<IActionResult> put(int professorId, Professor model)
    {
        try
        {
            var Professor = await _repositorioProfessor.ObterProfessorPeloIdAsync(professorId, false);
            if (Professor == null) return NotFound();

            _repositorio.Atualizar(model);

            if (await _repositorio.EfetuouAlteracoesAsync())
            {
                return Ok(model);
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }

        return BadRequest();
    }

    [HttpDelete("{professorId}")]
    public async Task<IActionResult> delete(int professorId)
    {
        try
        {
            var professor = await _repositorioProfessor.ObterProfessorPeloIdAsync(professorId, false);
            if (professor == null) return NotFound();

            _repositorio.Deletar(professor);

            if (await _repositorio.EfetuouAlteracoesAsync())
            {
                return Ok("Deletado");
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }

        return BadRequest();
    }
}
