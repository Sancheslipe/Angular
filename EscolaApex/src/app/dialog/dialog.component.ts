import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {
  @Input() titulo = '';
  @Input() mensagem = '';
  @Input() btnOkTexto = '';
  @Input() btnCancelarTexto = '';

  constructor(private activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  public decline() {
    this.activeModal.close(false);
  }
  public accept() {
    this.activeModal.close(true);
  }
  public dismiss() {
    this.activeModal.dismiss();
  }
  









}
