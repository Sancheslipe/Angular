using System.Collections.Generic;

namespace EscolaApexWepApi.models
{
    public class Disciplina
    {
        public Disciplina(){}
        public Disciplina(int id, string nome, int professorId)
        {
            this.Id = id;
            this.nome = nome;
            this.professorId = professorId;
        }
        public int Id { get; set; }

        public string nome { get; set; }

        public int professorId { get; set; }

        public Professor Professor { get; set; }
   
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}