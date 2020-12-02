import { Aluno } from './../models/Aluno';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {
  
  urlBase = `${environment.urlApi}aluno`;
  
  constructor(private http: HttpClient) { }
  
  obterTodos() : Observable<Aluno[]>{
    return this.http.get<Aluno[]>(this.urlBase);  
  }
  
  salvar(aluno: Aluno){
    return this.http.post(this.urlBase, aluno);
  }

  excluir(id: number){
    return this.http.delete(`${this.urlBase}/alunoid=${id}`);
  }

  editar(aluno: Aluno){
    return this.http.put(`${this.urlBase}/alunoid=${aluno.id}`, aluno);
  }

}
