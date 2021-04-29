import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule }   from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProdutoComponent } from './produto/produto.component';
import { CategoriaComponent } from './categoria/categoria.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastComponent } from './toast/toast.component';

const routes: Routes = [
  { path: 'produto', component: ProdutoComponent },
  { path: 'categoria', component: CategoriaComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ProdutoComponent,
    CategoriaComponent,
    ToastComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    [RouterModule.forRoot(routes)]
  ],
  exports:[
    CategoriaComponent,
    ProdutoComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
