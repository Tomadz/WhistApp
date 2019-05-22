import { Component, OnInit } from '@angular/core';
import { RundeService } from 'src/app/shared/runde.service';
import { NgForm } from '@angular/forms';
import { formArrayNameProvider } from '@angular/forms/src/directives/reactive_directives/form_group_name';

@Component({
  selector: 'app-runde',
  templateUrl: './runde.component.html',
  styles: []
})
export class RundeComponent implements OnInit {

  constructor(private service: RundeService) { }
  melderNavn: string;
  melderValue: number;
  vundettest: boolean;
  AntailVIPId: number;
  ngOnInit() {
    if (JSON.parse(localStorage.getItem('melderNavn')) == null) {
      this.service.setMelder();
      this.melderNavn = JSON.parse(localStorage.getItem('melderNavn'));
      this.melderValue = Number.parseInt(JSON.parse(localStorage.getItem('melderValue')), 10);
    }
    this.AntailVIPId = null;
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
    /*if (form.form.controls.PlusId.value[0] > 1) {
      this.service.gaaMedId = form.form.controls.PlusId.value[0];
    }*/
    // this.createRecord(form);
    this.service.setMelder();
    this.melderNavn = JSON.parse(localStorage.getItem('melderNavn'));
    this.melderValue = Number.parseInt(JSON.parse(localStorage.getItem('melderValue')), 10);
    // console.log(this.service.formData);
    this.regnBeloeb(form);
  }

  regnBeloeb(form: NgForm) {
    /*const base;
    const multiplier;
    const melding;
    const basevip;
    const antalvip = Number.parseInt(form.form.controls.AntalVIP.value, 10);;
    const antalstik;
    const melding;
    const plus;
    let beloeb: number;
    const datafromForm = this.service.formData;
    if (datafromForm.Vundet) {
      beloeb = (base * Math.pow(multiplier, (melding - 6)) + basevip * antalvip) * (antalstik - melding + 1) * (plus + 1);
    }*/
  }


  createRecord() {

    /*this.service.postRunde().subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    }, err => {
      console.log(err);
    });*/
  }
}
