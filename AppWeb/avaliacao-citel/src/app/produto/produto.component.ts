import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Categoria } from '../models/categoria';
import { Produto } from '../models/produto';
import { BaseService } from '../services/base.service';
import { ToastService } from '../services/toast.service';
import '@angular/localize/init';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css', '../app.component.css']
})
export class ProdutoComponent implements OnInit {

  api: string = 'Produtos/v1/';
  tipos = [{value: 'N', text: 'Não'},{value: 'S', text: 'Sim'}];
  produto = {} as Produto;
  produtos = [] as Produto[];
  categorias = [] as Categoria[];
  tipotela = 'I';
  desTela = '';

  constructor(private baseService: BaseService, public toastService: ToastService) {}
  
  ngOnInit() {
    this.getCategorias();
  }

  ngAfterViewInit(): void {
    this.onChange();
  }

  save(form: NgForm) {
    
    if (this.tipotela == 'E') {
      this.baseService.update(this.api + 'Put', this.produto).subscribe((dados) => {
        this.toastService.showSuccess(dados);
        this.cleanForm(form);
      });
    } else if(this.tipotela == 'C') {
      this.baseService.save(this.api + 'Post', this.produto).subscribe((dados) => {
        this.toastService.showSuccess(dados);
        this.cleanForm(form);
      });
    }
  }

  get() {
    this.baseService.get(this.api + 'Get').subscribe((produtos: Produto[]) => {
      this.produtos = produtos;
    });
  }

  getCategorias(){
    this.baseService.get('Categorias/v1/Get').subscribe((categorias: Categoria[]) => {
      this.categorias = categorias;
    });
  }

  delete(produto: Produto) {

    this.baseService.delete(this.api + 'Delete', produto.cod_produto + '/' + produto.cod_categoria).subscribe((dados) => {
      this.toastService.showSuccess(dados);
      this.onChange();
    });
  }

  edit(produto: Produto) {
    this.desTela = 'Editar Produto';
    this.tipotela = 'E';
    this.produto = { ...produto };
  }

  create(){
    this.desTela = 'Nova Produto';
    this.tipotela = 'C';
    this.produto = {} as Produto;
  }

  voltar(){
    this.desTela = '';
    this.tipotela = 'I';
  }

  // limpa o formulario
  cleanForm(form: NgForm) {
    form.resetForm();
    this.produto = {} as Produto;
    this.tipotela = 'I';
    this.onChange();
  }

  onChange(){
      const inputTag = document.getElementById('categoria') as HTMLInputElement;
      this.baseService.get(this.api + 'Get/Produtos/Categoria/' + inputTag.value.split(' - ')[0]).subscribe((produtos: Produto[]) => {
        this.produtos = produtos;
      });
  }
}