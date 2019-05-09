import { Injectable } from '@angular/core';
import { Runde } from './runde.model';
import { HttpClient } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class RundeService {
  formData:Runde
  constructor(private http:HttpClient) { }
  readonly rootURL = 'https://localhost:44359/api'
  list : Runde[];
  postRunde(formData:Runde){
    return this.http.post(this.rootURL+'/runde',formData);
  }
  refreshList(){
    return this.http.get(this.rootURL+'/runde')
    .toPromise()
    .then(res => this.list = res as Runde[])
  }
}
