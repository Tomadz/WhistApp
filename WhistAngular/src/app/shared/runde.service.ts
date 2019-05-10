import { Injectable } from '@angular/core';
import { Runde } from './runde.model';
import { HttpClient } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class RundeService {
  formData: Runde;
  readonly rootURL = 'http://localhost:50403/api';
  list: Runde[];

  constructor(private http: HttpClient) { }

  postRunde() {
    return this.http.post(this.rootURL + '/runde', this.formData);
  }
  putRunde() {
    return this.http.put(this.rootURL + "/runde/" + this.formData.Id, this.formData)
  }
  deleteRunde(id) {
    return this.http.delete(this.rootURL + "/runde/" + id)
  }

  refreshList() {
    this.http.get(this.rootURL + '/runde')
      .toPromise()
      .then(res => this.list = res as Runde[])
  }
}
