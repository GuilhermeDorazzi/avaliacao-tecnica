import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Categoria } from '../models/categoria';
import { BaseService } from '../services/base.service';
import { ToastService } from '../services/toast.service';
import '@angular/localize/init';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css', '../app.component.css']
})
export class CategoriaComponent implements OnInit {

  api: string = 'Categorias/v1/';
  tipos = [{value: 'N', text: 'Não'},{value: 'S', text: 'Sim'}];
  categoria = {} as Categoria;
  categorias = [] as Categoria[];
  tipotela = 'I';
  desTela = '';

  constructor(private baseService: BaseService, public toastService: ToastService) {}
  
  ngOnInit() {
    this.get();
  }

  save(form: NgForm) {
    
    if (this.tipotela == 'E') {
      this.baseService.update(this.api + 'Put', this.categoria).subscribe((dados) => {
        this.toastService.showSuccess(dados);
        this.cleanForm(form);
      });
    } else if(this.tipotela == 'C') {
      debugger;
      this.baseService.save(this.api + 'Post', this.categoria).subscribe((dados) => {
        this.toastService.showSuccess(dados);
        this.cleanForm(form);
      });
    }
  }

  get() {
    this.baseService.get(this.api + 'Get').subscribe((categorias: Categoria[]) => {
      this.categorias = categorias;
    });
  }

  delete(categoria: Categoria) {

    this.baseService.delete(this.api + 'Delete', categoria.cod_categoria).subscribe((dados) => {
      this.toastService.showSuccess(dados);
      this.get();
    });
  }

  edit(categoria: Categoria) {
    this.desTela = 'Editar Categoria';
    this.tipotela = 'E';
    this.categoria = { ...categoria };
  }

  create(){
    this.desTela = 'Nova Categoria';
    this.tipotela = 'C';
    this.categoria = {} as Categoria;
  }

  voltar(){
    this.desTela = '';
    this.tipotela = 'I';
  }

  // limpa o formulario
  cleanForm(form: NgForm) {
    this.get();
    form.resetForm();
    this.categoria = {} as Categoria;
    this.tipotela = 'I';
  }

}