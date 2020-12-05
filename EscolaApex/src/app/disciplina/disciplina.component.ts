import { DialogService } from './../services/dialog.service';
import { ProfessorService } from './../services/professor.service';
import { DisciplinaService } from './../services/disciplina.service';
import { Professor } from './../models/Professor';
import { Disciplina } from './../models/Disciplina';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-disciplina',
  templateUrl: './disciplina.component.html',
  styleUrls: ['./disciplina.component.scss']
})

export class DisciplinaComponent implements OnInit {
  public titulo = 'Disciplinas';
  public disciplinaSelecionada = new Disciplina();

  public disciplinas: Disciplina[] = [];
  public professores: Professor[] = [];

  disciplinaForm = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    professorId: new FormControl('')
  });


  constructor(private fb: FormBuilder,
              private disciplinaServico: DisciplinaService,
              private professorServico: ProfessorService,
              private dialogoServico: DialogService ) {
    this.criarForm()
  };


  ngOnInit() {
    this.carregarDisciplinas();
    this.carregarProfessores();
  }

  criarForm() {
    this.disciplinaForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      professorId: ['', Validators.required]
    });
  }

  carregarProfessores() {
    this.professorServico.obterTodos().subscribe(
      (resultado: Professor[]) => {
      this.professores = resultado;
    },
    (error: any) => {
      console.log(error);
    }
    )};


  carregarDisciplinas() {
    this.disciplinaServico.obterTodos().subscribe(
      (resultado: Disciplina[]) => {
      this.disciplinas = resultado;
    },
    (error: any) => {
      console.log(error);
    }
    )};

  disciplinaSelect(disciplina: Disciplina) {
    this.disciplinaSelecionada = disciplina;
    this.disciplinaForm.patchValue(disciplina);
  }

  novaDisciplina() {
    this.disciplinaSelecionada = new Disciplina();
    this.disciplinaSelecionada.id = -1;
    this.disciplinaForm.patchValue(this.disciplinaSelecionada)
  }
  salvarDisciplina(disciplina: Disciplina) {
    console.log(disciplina);
    if (this.disciplinaSelecionada.id === -1) {
      disciplina.id = 0;
      this.disciplinaServico.salvar(disciplina).subscribe(
        (resultado: any) => {
          console.log(resultado);
          this.disciplinaSelecionada = resultado;
          this.carregarDisciplinas();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    } else {
      this.disciplinaServico.editar(disciplina).subscribe(
        (resultado: any) => {
          console.log(resultado);
          this.disciplinaSelecionada = resultado;
          this.carregarDisciplinas();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    }

  }
    public abrirDialogoDeConfirmacao(disciplina: Disciplina){
      this.dialogoServico.confirmar('excluir - disciplina',
     'deseja Realmente excluir?',
     'Ok',
     'Cancelar',
     'sm',
     )
     .then(
       (confirmou) => this.excluirDisciplina(disciplina, confirmou)
      )
      .catch(
        (erro: any) => console.log(erro)
      );
  }
  
  excluirDisciplina(disciplina:Disciplina, confirmado: boolean){
    if (confirmado) {
      this.disciplinaServico.excluir(disciplina.id).subscribe(
        (retorno: any) =>{
          console.log(retorno);
          this.carregarDisciplinas();
        },
        (erro: any) => {
          console.log(erro);
        }
      )
    }
    }
    
    
    
  onSubmit(){
    this.salvarDisciplina(this.disciplinaForm.value);
  }

  voltar(){
    this.disciplinaSelecionada = new Disciplina();
  }  

}    