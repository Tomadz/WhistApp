import { Component, OnInit } from '@angular/core';
import { RundeService } from 'src/app/shared/runde.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-runde',
  templateUrl: './runde.component.html',
  styles: []
})
export class RundeComponent implements OnInit {

  constructor(private service:RundeService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form != null)
      form.resetForm();
    this.service.formData = {
      Id:0,
      SpilId:0,
      RundeNr:0,
      Melder:0,
      Melding:0,
      PlusId:0,
      Makker:0,
      Vundet:null,
      Beloeb:0,
      Spiller1:0,
      Spiller2:0,
      Spiller3:0,
      Spiller4:0
    }
  }

  onSubmit(form:NgForm) {
    this.service.postRunde(form.value).subscribe(
      res => {
        this.resetForm(form);
      },
      err => {
        console.log(err)
      }
    )
  }
}
