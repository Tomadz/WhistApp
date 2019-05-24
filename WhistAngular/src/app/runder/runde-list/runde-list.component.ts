import { Component, OnInit } from '@angular/core';
import { Runde } from 'src/app/shared/runde.model';
import { RundeService } from 'src/app/shared/runde.service';
import { Melding } from 'src/app/shared/melding.model';

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

  onDelete(id) {
    if (confirm('Er du sikker på du vil slette denne runde?')) {
      this.service.deleteRunde(id).subscribe(res => {
        this.service.refreshList();
      }, err => {
        console.log(err);
      });
    }
  }

  getNavnFromId(id: string) {
    const filtredeMelder = this.service.spillereList.filter(filter => filter.Id === Number.parseInt(id, 10));
    return filtredeMelder[0].Fornavn;
  }

  getMelding(id: string) {
    const filtredeMelding = this.service.meldinger.filter(filter => filter.Id === Number.parseInt(id, 10));
    return filtredeMelding[0].Melding;
  }

  getPlus(id: string) {
    if (id === null) {
      return '-';
    } else {
      const flitredePlus = this.service.plus.filter(filter => filter.Id === Number.parseInt(id, 10));
      return flitredePlus[0].PlusNavn;
    }
  }

  getVundet(resultat: string) {
    if (resultat) {
      return 'Gået hjem';
    } else {
      return 'Gået under';
    }
  }
}
