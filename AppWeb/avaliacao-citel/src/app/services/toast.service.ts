import { Injectable, TemplateRef  } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  toasts: any[] = [];

  showSuccess(msg: string) {
    this.show(msg, {
      classname: 'bg-success text-light',
      delay: 3000 ,
      autohide: true,
      headertext: 'Sucesso'
    });
  }
  showError(msg: string) {
    this.show(msg, {
      classname: 'bg-danger text-light',
      delay: 3000 ,
      autohide: true,
      headertext: 'Atenção'
    });
  }
  
  show(textOrTpl: string | TemplateRef<any>, options: any = {}) {
    this.toasts.push({ textOrTpl, ...options });
  }

  remove(toast: any) {
    this.toasts = this.toasts.filter(t => t !== toast);
  }
}