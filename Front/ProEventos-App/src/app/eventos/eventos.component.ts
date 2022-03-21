import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  widthImg: number = 150;
  marginImg: number =2;
  ShowImage = true;

  // Filtragem de dados
  public eventosFiltrados: any = [];
  private _listFilter: string = '';
  get listFilter() {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    this.eventosFiltrados = this.listFilter ? this.filtrarEventos(this.listFilter): this.eventosFiltrados;
  }

  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento : {tema: string; local: string;}) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );
  }

  alterarImagem(){
    this.ShowImage = !this.ShowImage;
  }
}
