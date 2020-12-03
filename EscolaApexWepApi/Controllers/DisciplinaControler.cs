using System;
using System.Threading.Tasks;
using EscolaApexWepApi.Data.interfaces;
using EscolaApexWepApi.Data.Services;
using EscolaApexWepApi.models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApexWepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public DisciplinaController(IRepositorio repositorio,
                                    IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorio = repositorio;
            _repositorioDisciplina = repositorioDisciplina;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repositorioDisciplina.ObterTodasAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Disciplina model)
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

        [HttpPut("{disciplinaId}")]
        public async Task<IActionResult> put(int disciplinaId, Disciplina model)
        {
            try
            {
                var disciplina = await _repositorioDisciplina.ObterPeloIdAsync(disciplinaId);
                if (disciplina == null)
                {
                    return NotFound();
                }

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

        [HttpDelete("{disciplinaId}")]
        public async Task<IActionResult> delete(int disciplinaId)
        {
            try
            {
                var disciplina = await _repositorioDisciplina.ObterPeloIdAsync(disciplinaId);
                if (disciplina == null) return NotFound();

                _repositorio.Deletar(disciplina);

                if (await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(
                        new
                        {
                            message = "Deletado!"
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}