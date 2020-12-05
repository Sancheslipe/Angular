import { Disciplina } from './../models/Disciplina';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DisciplinaService {

  baseUrl = `${environment.urlApi}disciplina`;

  constructor(private http: HttpClient) { }

  obterTodos(): Observable<Disciplina[]> {
    return this.http.get<Disciplina[]>(this.baseUrl);
  }

  salvar(disciplina: Disciplina){

    return this.http.post(this.baseUrl, disciplina);
  }

  editar(disciplina: Disciplina){
    return this.http.put(`${this.baseUrl}/${disciplina.id}`, disciplina);
  }

  excluir(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }


















  

}
