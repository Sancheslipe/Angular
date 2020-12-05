import { Professor } from './Professor';
export class Disciplina {

constructor (){
    this.id = 0;
    this.nome = '';
    this.professorId = 0;
    this.professor = new Professor;
}
    id: number;
    nome: string;
    professorId: number;
    professor: Professor;

}
