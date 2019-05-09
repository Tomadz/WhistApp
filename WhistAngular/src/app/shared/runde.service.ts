import { Injectable } from '@angular/core';
import { Runde } from './runde.model';
import { HttpClient } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class RundeService {
  formData: Runde;
  readonly rootURL = 'https://localhost:44359/api';
  list: Runde[];

  constructor(private http: HttpClient) { }

  postRunde() {
    return this.http.post(this.rootURL + '/runde', this.formData);
  }
  putRunde() {
    return this.http.put(this.rootURL + "/runde/" + this.formData.id, this.formData)
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
