import { Component, OnInit } from '@angular/core';
import { Runde } from 'src/app/shared/runde.model';
import { RundeService } from 'src/app/shared/runde.service';

@Component({
  selector: 'app-runde-list',
  templateUrl: './runde-list.component.html',
  styles: []
})
export class RundeListComponent implements OnInit {

  constructor(private service: RundeService) { }

  ngOnInit() {
    this.service.refreshList();
  }
  redigerForm(runde: Runde) {
    this.service.formData = Object.assign({}, runde);
  }
  onDelete(id) {
    if (confirm('Er du sikker på du vil slette denne runde?')) {
      this.service.deleteRunde(id).subscribe(res => {
        this.service.refreshList();
      }, err => {
        console.log(err)
      })
    }
  }
}
