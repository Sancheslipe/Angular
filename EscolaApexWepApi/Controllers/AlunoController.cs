using System;
using System.Threading.Tasks;
using EscolaApexWepApi.Data.interfaces;
using EscolaApexWepApi.models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApexWepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepositorioAluno _repositorioAluno;
        private readonly IRepositorio _repositorio;

        public AlunoController(IRepositorio repositorio,
                               IRepositorioAluno repositorioAluno)
        {
            this._repositorio = repositorio;
            this._repositorioAluno = repositorioAluno;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
              var resultado = await _repositorioAluno.ObterTodos(incluirProfessor: false);
              return Ok(resultado);  
            }
            catch (Exception ex )
            {
                
                return BadRequest($"Ao obter todos os alunos, ocorreu um erro: {ex.Message}");
            }
        }
    [HttpGet("alunoid={alunoId}")]
        public async Task<IActionResult> GetbyId(int alunoId)
        {
            try
            {
              var resultado = await _repositorioAluno.ObterAlunoByIdAsync(alunoId, incluirProfessor: false);
              return Ok(resultado);  
            }
            catch (Exception ex )
            {
                
                return BadRequest($"Ao obter todos os alunos, ocorreu um erro: {ex.Message}");
            }
        }
    
    [HttpGet("disciplinaid={disciplinaidId}")]
        public async Task<IActionResult> GetbyDisciplinaidId(int disciplinaId)
        {
            try
            {
              var resultado = await _repositorioAluno.ObterTodosPelaDisciplinaIdAsync(disciplinaId , incluirProfessor:false);
              return Ok(resultado);  
            }
            catch (Exception ex )
            {
                
                return BadRequest($"Ao obter todos os alunos pela disciplina, ocorreu um erro: {ex.Message}");
            }
        }
    
        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            try
            {
                _repositorio.Adicionar(aluno);
                
                if (await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(aluno);
                }

            }
            catch (Exception ex)
            {
                
                return BadRequest($"Ao salvar o aluno ocorreu um erro {ex.Message}");
            }
            return BadRequest();
        }
    
        [HttpPut("alunoid={alunoId}")]
        public async Task<IActionResult> put(int alunoId, Aluno aluno)
        {
          
            try
            {
                var alunoCadastrado = await _repositorioAluno.ObterAlunoByIdAsync(alunoId, incluirProfessor: false);
                if (alunoCadastrado == null)
                {
                    return NotFound();             
                }  
        
                _repositorio.Atualizar(aluno);

            
                if(await _repositorio.EfetuouAlteracoesAsync())
                {
                    return Ok(aluno);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar o aluno ocorreu um erro {ex.Message}");            
            }
            return BadRequest();
        }    
    [HttpDelete("alunoid={alunoId}")]
    public async Task<IActionResult> Delete(int alunoId)
    {
        try
        {
            var alunoCadastrado = await _repositorioAluno.ObterAlunoByIdAsync(alunoId, incluirProfessor: false);
            if (alunoCadastrado == null)
            {
                return NotFound();             
            }
            _repositorio.Deletar(alunoCadastrado);

            if (await _repositorio.EfetuouAlteracoesAsync())
            {
                //este objeto é do tipo dict que é do tipo Dictionary, que á função ok irá converte-lo em Json
                return Ok(
                    new{
                        message="removido!"
                    }

                );
            }
        
        
        }
        catch (Exception ex)
        {
            
            return BadRequest($"Ao remover o aluno, ocorreu um erro {ex.Message}");
        }
        return BadRequest();
    }
}
}