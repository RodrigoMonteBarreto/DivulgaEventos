import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-Titulo',
  templateUrl: './Titulo.component.html',
  styleUrls: ['./Titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() titulo!: string;
  @Input() iconClass = 'fa fa-user';
  @Input() subtitulo = 'Gerenciamento de Eventos';
  @Input() botaoListar = false;

  constructor() { }

  ngOnInit() {
  }

}
