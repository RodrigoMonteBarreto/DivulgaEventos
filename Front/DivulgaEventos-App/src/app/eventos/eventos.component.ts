import { Component, OnInit } from '@angular/core';
import { EventoService } from '../services/evento.service';
import { Evento } from '../models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos : any = [];
  public eventosFiltrados : any = [];

  public  widthImg: number = 150;
  public  marginImg: number = 2;
  public showImg: boolean = true;
  private _filtroLista: string = '';


  public get filtroLista() : string
  {
    return this._filtroLista;
  }

  public set filtroLista (value: string)
  {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor : string) : Evento {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(
      (e: { tema: string; local : string; }) => e.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      e.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1)
  }

  constructor(private eventoService: EventoService)
  {

  }

  public ngOnInit(): void {
    this.getEventos();
  }

  public alterarImg()
  {
    this.showImg = !this.showImg;
  }


  public getEventos(): void
  {
    this.eventoService.getEventos().subscribe(
      (_eventos : Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }
}
