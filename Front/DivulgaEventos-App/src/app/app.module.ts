import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'

import {CollapseModule} from 'ngx-bootstrap/collapse';
import { TooltipModule} from 'ngx-bootstrap/tooltip';
import { BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';


import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { NavComponent } from './shared/nav/Nav.component';

import { EventoService } from './services/evento.service';
import { DateTimeFormatPipePipe } from './helpers/DateTimeFormatPipe.pipe';
import { TituloComponent } from './shared/Titulo/Titulo.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { EventoDetalheComponent } from './components/eventos/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './components/eventos/evento-lista/evento-lista.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { LoteService } from './services/lote.service';
import { AccountService } from './services/AccountService.service';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { HomeComponent } from './components/home/home.component';


defineLocale('pt-br', ptBrLocale);


@NgModule({
  declarations: [
      AppComponent,
      EventosComponent,
      PalestrantesComponent,
      NavComponent,
      ContatosComponent,
      DashboardComponent,
      PerfilComponent,
      TituloComponent,
      DateTimeFormatPipePipe,
      EventoDetalheComponent,
      EventoListaComponent,
      UserComponent,
      HomeComponent,
      LoginComponent,
      RegistrationComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 4000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,


    }),
    NgxSpinnerModule,

  ],
  providers: [
    AccountService,
    EventoService,
    LoteService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }

