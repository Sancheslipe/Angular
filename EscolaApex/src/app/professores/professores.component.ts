import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Professor } from '../models/Professor';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.scss']
})
export class ProfessoresComponent implements OnInit {

  public titulo = 'Professores';
  public profSelected: Professor = new Professor();
  public professoresForm = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    disciplina: new FormControl(''),})
    

  public professores = [
    {id:1, nome:'Ralf', disciplina: 'C#'},
    {id:2, nome:'Luiz', disciplina: 'Java'},
    {id:3, nome:'DIego', disciplina: 'Angular'},

  ];

    constructor(private fb: FormBuilder) { 
    this.createForm();
  }
  
  createForm(){
    this.professoresForm = this.fb.group({
      id: [''],
      nome: [''],
      disciplina:['']
    })
  }
   profSelect(prof: any){
    this.profSelected = prof;
    this.professoresForm.patchValue(prof);
  }

  // //alunoSelect(aluno:Aluno){
  //   this.alunoSelected = aluno;
  // }

  voltar(){
   this.profSelected = new Professor();
  }

  // voltar(){
  //   this.alunoSelected = new Aluno();
  // }
  onSubmit(){
    console.log(this.professoresForm.value);
  }

  ngOnInit() {
  }

}
