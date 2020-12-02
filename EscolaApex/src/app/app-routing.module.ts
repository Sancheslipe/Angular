import { PrincipalComponent } from './principal/principal.component';
import { PerfilComponent } from './perfil/perfil.component';
import { ProfessoresComponent } from './professores/professores.component';
import { AlunosComponent } from './alunos/alunos.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    {path:'', redirectTo:'principal',pathMatch:'full'},
    {path: 'principal',component: PrincipalComponent},
    {path:'alunos', component: AlunosComponent},
    {path:'professores', component: ProfessoresComponent},
    {path:'perfil', component: PerfilComponent}
    

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
