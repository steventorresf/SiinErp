import { HttpClientModule } from "@angular/common/http";
import { registerLocaleData } from '@angular/common';
import es from '@angular/common/locales/es';
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule  } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { IconsProviderModule } from "./icons-provider.module";
import { NgZorroModule } from "./ng-zorro.module";
import { es_ES } from 'ng-zorro-antd/i18n';
import { NZ_I18N } from 'ng-zorro-antd/i18n';

import { FormularioComponent } from './pages/formulario/formulario.component';
import { TablasComponent } from './pages/tablas/tablas.component';
import { WelcomeComponent } from './pages/welcome/welcome.component';
import { PaisComponent } from './pages/general/pais/pais.component';
import { CiudadComponent } from './pages/general/ciudad/ciudad.component';
import { DepartamentoComponent } from './pages/general/departamento/departamento.component';

registerLocaleData(es);

@NgModule({
  declarations: [
    AppComponent,
    FormularioComponent,
    TablasComponent,
    WelcomeComponent,
    PaisComponent,
    CiudadComponent,
    DepartamentoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    IconsProviderModule,
    NgZorroModule
  ],
  providers: [{ provide: NZ_I18N, useValue: es_ES }],
  bootstrap: [AppComponent]
})
export class AppModule { }