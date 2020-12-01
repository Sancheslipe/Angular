using System.Collections.Generic;

namespace EscolaApexWepApi.models
{
    public class Aluno
    {
        public Aluno(){}
        public Aluno(int id, string nome, string sobrenome, string telefone)
        {
            this.Id = id;
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.telefone = telefone;

        }
        public int Id { get; set; }

        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }




    }
}