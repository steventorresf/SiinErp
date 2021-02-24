import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormularioComponent } from './pages/formulario/formulario.component';
import { PaisComponent } from './pages/general/pais/pais.component';
import { TablasComponent } from './pages/tablas/tablas.component';
import { WelcomeComponent } from './pages/welcome/welcome.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/welcome' },
  { path: 'welcome', component: WelcomeComponent },
  { path: 'form', component: FormularioComponent },
  { path: 'general/paises', component: PaisComponent },
  { path: 'otros/tablas', component: TablasComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }