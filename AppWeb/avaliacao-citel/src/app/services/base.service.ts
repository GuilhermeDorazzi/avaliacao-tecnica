import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { ToastService } from '../services/toast.service';
import '@angular/localize/init';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  url = 'http://localhost:9032/api/';

  toastServiceBase: ToastService;

  // injetando o HttpClient
  constructor(private httpClient: HttpClient,private toast: ToastService) { 
    this.toastServiceBase = this.toast;
  }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    responseType: 'text' as 'json'
  };
  
  get(api:string): Observable<any[]> {
    return this.httpClient.get<any[]>(this.url +  api)
      .pipe(
        retry(2),
        catchError(this.handleError.bind(this)))
  }

  getById(api:string,parametros:string): Observable<any> {
    return this.httpClient.get<any>(this.url + api + parametros)
      .pipe(
        retry(2),
        catchError(this.handleError.bind(this))
      )
  }

  save(api:string, entity: any): Observable<any> {
    return this.httpClient.post<any>(this.url + api, entity, this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError.bind(this))
      )
  }

  update(api:string, entity: any): Observable<any> {
    return this.httpClient.put<any>(this.url + api , JSON.stringify(entity), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError.bind(this))
      )
  }

  delete(api:string, parametros: any) {
    return this.httpClient.delete<any>(this.url + api + '/' + parametros, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError.bind(this))
      )
  }

  // Manipulação de erros
  handleError(error: HttpErrorResponse) {
    let errorMessage = '';

    if(error.error != '' && error.status == 400){
      errorMessage = error.error;
    }
    else if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    
    this.toastServiceBase.showError(errorMessage);
    return throwError(errorMessage);
  };
}
