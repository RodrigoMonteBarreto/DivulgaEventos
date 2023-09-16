import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';


import { NgxSpinnerService } from 'ngx-spinner';
import { EventoService } from 'src/app/services/evento.service';
import { Evento } from 'src/app/models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
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

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService){}

  public ngOnInit(): void {
    this.spinner.show();

    setTimeout(() => {
      this.spinner.hide();
    }, 5000);
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

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.toastr.success('O Evento foi deletado com sucesso!', 'Deletado!');
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
