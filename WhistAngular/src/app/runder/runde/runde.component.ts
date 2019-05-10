import { Component, OnInit } from '@angular/core';
import { RundeService } from 'src/app/shared/runde.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-runde',
  templateUrl: './runde.component.html',
  styles: []
})
export class RundeComponent implements OnInit {

  constructor(private service: RundeService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      Id: 0,
      SpilId: null,
      RundeNr: null,
      Melder: null,
      Melding: null,
      PlusId: null,
      Makker: null,
      Vundet: null,
      Beloeb: null,
      Spiller1: null,
      Spiller2: null,
      Spiller3: null,
      Spiller4: null
    }
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.Id == 0)
      this.createRecord(form);
    else
      this.updateRecord(form);
  }
  createRecord(form: NgForm) {
    this.service.postRunde().subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    }, err => {
      console.log(err);
    });
  }
  updateRecord(form: NgForm) {
    this.service.putRunde().subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    }, err => {
      console.log(err);
    })
  }
}
