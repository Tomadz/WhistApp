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

}
