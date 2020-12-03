import { ProfessorService } from './../services/professor.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Professor } from '../models/Professor';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.scss']
})
export class ProfessoresComponent implements OnInit {

  public titulo = 'Professores';
  public professorSelected: Professor = new Professor();
  public professoresForm = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    disciplina: new FormControl(''),
  })


  public professores: Professor[] = [];

  constructor(private fb: FormBuilder,
    private professorServico: ProfessorService) {
    this.createForm();
  }

  createForm() {
    this.professoresForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required]
    })
  }

  carregarProfessores() {
    this.professorServico.obterTodos().subscribe(
      (resultado: Professor[]) => {
        this.professores = resultado;
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  novoProfessor() {
    this.professorSelected = new Professor();
    this.professorSelected.id = -1;
    this.professoresForm.patchValue(this.professorSelected)
  }

  salvarProfessor(professor: Professor) {
    if (this.professorSelected.id === -1) {
      professor.id = 0;
      this.professorServico.salvar(professor).subscribe(
        (resultado: any) => {
          console.log(resultado);
          this.professorSelected = resultado;
          this.carregarProfessores();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    } else {
      this.professorServico.editar(professor).subscribe(
        (resultado: any) => {
          console.log(resultado);
          this.professorSelected = resultado;
          this.carregarProfessores();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    }

  }

  excluirProfessor(professor: Professor) {
    this.professorServico.excluir(professor.id).subscribe(
      (retorno: any) => {
        console.log(retorno);
        this.carregarProfessores();
      },
      (erro: any) => {
        console.log(erro);
      }
    )
  }

  profSelect(prof: any) {
    this.professorSelected = prof;
    this.professoresForm.patchValue(prof);
  }

  // //alunoSelect(aluno:Aluno){
  //   this.alunoSelected = aluno;
  // }

  voltar() {
    this.professorSelected = new Professor();
  }

  // voltar(){
  //   this.alunoSelected = new Aluno();
  // }
  onSubmit() {
    this.salvarProfessor(this.professoresForm.value);
  }

  ngOnInit() {
    this.carregarProfessores();
  }

}
