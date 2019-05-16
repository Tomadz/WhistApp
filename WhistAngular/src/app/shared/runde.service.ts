import { Injectable } from '@angular/core';
import { Runde } from './runde.model';
import { HttpClient } from '@angular/common/http';
import { Spillere } from './spillere.model';
@Injectable({
  providedIn: 'root'
})
export class RundeService {
  formData: Runde;
  readonly rootURL = 'http://localhost:55465/api';
  rundeList: Runde[];
  spillereList = [
    {Id: 1, Fornavn: 'Tomas'},
    {Id: 2, Fornavn: 'Anders'},
    {Id: 3, Fornavn: 'Steen'},
    {Id: 4, Fornavn: 'Kristine'}] as Spillere[];
  gaaMedId: number;

  constructor(private http: HttpClient) { }

  postRunde() {
    return this.http.post(this.rootURL + '/runde', this.formData);
  }

  deleteRunde(id) {
    return this.http.delete(this.rootURL + '/runde/' + id);
  }

  refreshList() {
    this.http.get(this.rootURL + '/runde')
      .toPromise()
      .then(res => this.rundeList = res as Runde[]);
  }
  setMelder() {
    const lsMelderIndex = JSON.parse(localStorage.getItem('melderIndex'));
    let melderIndex = lsMelderIndex;
    if (melderIndex !== null && melderIndex < this.spillereList.length - 1) {
      melderIndex++;
      localStorage.clear();
      this.localStorageGem('melderNavn', this.spillereList[melderIndex].Fornavn);
      this.localStorageGem('melderValue', this.spillereList[melderIndex].Id);
      this.localStorageGem('melderIndex', melderIndex);
    } else {
      melderIndex = 0;
      localStorage.clear();
      this.localStorageGem('melderNavn', this.spillereList[melderIndex].Fornavn);
      this.localStorageGem('melderValue', this.spillereList[melderIndex].Id);
      this.localStorageGem('melderIndex', 0);
    }
  }

  localStorageGem(lckey: string, obj: any) {
    let stringCopy = '';
    try {
      stringCopy = JSON.stringify(obj);
    } catch (err) {
      // error handling for bad form submission
      console.log(err);
      return;
    }
    localStorage.setItem(lckey, stringCopy);
  }

  get filterSpillere() {
    const melderIndex = JSON.parse(localStorage.getItem('melderIndex'));
    if (melderIndex === null) {
      this.localStorageGem('melderIndex', '0');
    }
    return this.spillereList.filter(filter => filter.Id !== this.spillereList[melderIndex].Id);
  }
}
