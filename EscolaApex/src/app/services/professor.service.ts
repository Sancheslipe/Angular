import { Professor } from './../models/Professor';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Aluno } from '../models/Aluno';


@Injectable({
  providedIn: 'root'
})
export class ProfessorService {

urlBase = `${environment.urlApi}professor`;
  
  constructor(private http: HttpClient) { }
  
  obterTodos() : Observable<Professor[]>{
    return this.http.get<Professor[]>(this.urlBase);  
  }
  
  salvar(aluno: Professor){
    return this.http.post(this.urlBase, aluno);
  }

  excluir(id: number){
    return this.http.delete(`${this.urlBase}/${id}`);
  }

  editar(Professor: Professor){
    return this.http.put(`${this.urlBase}/${Professor.id}`,Professor);
  }

}
