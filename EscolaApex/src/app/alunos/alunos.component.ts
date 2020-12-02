import { AlunoService } from './../services/aluno.service';
import { Aluno } from './../models/Aluno';
import { Component, OnInit, TemplateRef, ɵConsole } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {

  public tituloAluno = 'Alunos(a)';
  public alunoSelected: Aluno = new Aluno();
  modalRef: BsModalRef = new BsModalRef;
  public metodo = 'salvar';

  alunoForm = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    sobrenome: new FormControl(''),
    telefone: new FormControl
  })

  public alunos: Aluno[] = [];

  constructor(private fb: FormBuilder,
    private modalService: BsModalService,
    private alunoServico: AlunoService) {
    this.createForm();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  createForm() {
    this.alunoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.carregarAlunos();
  }

  carregarAlunos() {
    this.alunoServico.obterTodos().subscribe(
      (resultado: Aluno[]) => {
        this.alunos = resultado;
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }



  alunoSelect(aluno: Aluno) {
    this.alunoSelected = aluno;
    this.alunoForm.patchValue(aluno);
  }

  novoAluno() {
    this.alunoSelected = new Aluno();
    this.alunoSelected.id = -1;
    this.alunoForm.patchValue(this.alunoSelected)
  }

  salvarAluno(aluno: Aluno) {
    if (this.alunoSelected.id === -1) {
      aluno.id = 0;
      this.alunoServico.salvar(aluno).subscribe(
        (resultado: any) => {
          console.log(resultado);
          this.alunoSelected = resultado;
          this.carregarAlunos();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    } else {
      this.alunoServico.editar(aluno).subscribe(
        (resultado: any) => {
          console.log(resultado);
          this.alunoSelected = resultado;
          this.carregarAlunos();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    }

  }

  excluirAluno(aluno: Aluno){
    this.alunoServico.excluir(aluno.id).subscribe(
      (retorno: any) =>{
        console.log(retorno);
        this.carregarAlunos();
      },
      (erro: any) => {
        console.log(erro);
      }
    )
  }


  onSubmit(){
    this.salvarAluno(this.alunoForm.value);
  }

  voltar(){
    this.alunoSelected = new Aluno();
  }    

}
