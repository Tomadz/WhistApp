import { Component, OnInit } from '@angular/core';
import { RundeService } from 'src/app/shared/runde.service';
import { NgForm } from '@angular/forms';
import { Spillere } from 'src/app/shared/spillere.model';
import { formatNumber } from '@angular/common';

@Component({
  selector: 'app-runde',
  templateUrl: './runde.component.html',
  styles: []
})
export class RundeComponent implements OnInit {

  constructor(private service: RundeService) { }
  spillerlistest = this.service.spillereList;
  melderNavn: string;
  melderValue: number;
  ngOnInit() {
    this.service.setMelder();
    this.melderNavn = JSON.parse(localStorage.getItem('melderNavn'));
    this.melderValue = Number.parseInt(JSON.parse(localStorage.getItem('melderValue')), 10);
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.form.reset();
    }
    this.service.formData = {
      Id: 0,
      SpilId: null,
      RundeNr: null,
      Melder: null,
      Melding: 0,
      PlusId: null,
      Makker: null,
      Vundet: null,
      Beloeb: null,
      Spiller1: null,
      Spiller2: null,
      Spiller3: null,
      Spiller4: null
    };
  }

  onSubmit(form: NgForm) {
    this.gaaMedCheck(form);
    // this.createRecord(form);
  }

  gaaMedCheck(form: NgForm) {
    if (form.form.controls.GaaMed.value[0] != null) {
      this.service.gaaMedId = form.form.controls.gaaMed.value[0];
    }
  }

  createRecord(form: NgForm) {

    /*this.service.postRunde().subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    }, err => {
      console.log(err);
    });*/
  }
}
