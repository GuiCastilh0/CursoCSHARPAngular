import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '@app/models/Evento';
import { EventoService } from '@app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {
 //ModalModule
 modalRef?: BsModalRef;
 ///////////////////
 public eventos: Evento[] = [];
 widthImg: number = 150;
 marginImg: number =2;
 ShowImage = true;

 // Filtragem de dados
 public eventosFiltrados: Evento[] = [];
 private filtroListado: string = '';
 get listFilter() {
   return this.filtroListado;
 }
 set listFilter(value: string) {
   this.filtroListado = value;
   this.eventosFiltrados = this.listFilter ? this.filtrarEventos(this.listFilter): this.eventosFiltrados;
 }

 filtrarEventos(filtrarPor: string): Evento[]{
   filtrarPor = filtrarPor.toLocaleLowerCase();
   return this.eventos.filter(
     (evento : {tema: string; local: string;}) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
     evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
   )
 }


 constructor(private eventoService : EventoService ,
             private modalService: BsModalService,
             private toastr: ToastrService,
             private spinner: NgxSpinnerService,
             private router: Router) { }

 ngOnInit(): void {
   this.getEventos();
   this.spinner.show();
 }

 public getEventos(): void {
   this.eventoService.getEventos().subscribe({
     next: (eventos: Evento[]) => {
       this.eventos = eventos;
       this.eventosFiltrados = this.eventos;
     },
     error: (error: any) => {
       this.spinner.hide();
       this.toastr.error('Erro ao Carregar os Eventos', 'Erro!');
     },
     complete: () => this.spinner.hide()
   });
 }

 alterarImagem(){
   this.ShowImage = !this.ShowImage;
 }

 detalheEvento(id : number): void {
    this.router.navigate([`eventos/detalhe/${id}`]);
 }

 openModal(template: TemplateRef<any>) : void {
   this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
 }

 confirm(): void {
   this.modalRef?.hide();
   this.toastr.success('Evento deletado com sucesso!');
 }

 decline(): void {
   this.modalRef?.hide();
 }

}
