import { DialogComponent } from './../dialog/dialog.component';
import { Injectable } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Injectable({
  providedIn: 'root'
})
export class DialogService {

constructor(private modalService: NgbModal) { }

  public confirmar(
    titulo: string,
    mensagem: string,
    btnOkTexto: string,
    btnCancelarTexto: string,
    dialogTamanho:string): Promise<boolean>{
      const modalRef = this.modalService.open(DialogComponent,{ size: dialogTamanho});

      modalRef.componentInstance.title = titulo;
      modalRef.componentInstance.message = mensagem;
      modalRef.componentInstance.btnOkText = btnOkTexto;
      modalRef.componentInstance.btnCancelText = btnCancelarTexto;

    return modalRef.result;
    }

}
