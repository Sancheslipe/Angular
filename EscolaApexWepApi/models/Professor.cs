using System.Collections.Generic;

namespace EscolaApexWepApi.models
{
    public class Professor
    {
        public Professor(){}
        public Professor(int id, string nome)
        {
            this.Id = id;
            this.nome = nome;

        }
        public int Id { get; set; }
        public string nome { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }

}