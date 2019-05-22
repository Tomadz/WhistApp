import { Injectable } from '@angular/core';
import { Runde } from './runde.model';
import { HttpClient } from '@angular/common/http';
import { Spillere } from './spillere.model';
import { Melding } from './melding.model';
import { Plus } from './plus.model';
@Injectable({
  providedIn: 'root'
})
export class RundeService {
  formData: Runde;
  readonly rootURL = 'http://localhost:55465/api';
  rundeList: Runde[];
  spillereList = [{Id: 1, Fornavn: 'Tomas'},
    {Id: 2, Fornavn: 'Anders'},
    {Id: 3, Fornavn: 'Steen'},
    {Id: 4, Fornavn: 'Kristine'}] as Spillere[];
  gaaMedId: number;
  meldinger = [{Id: 1, Melding: '7'},
    {Id: 2, Melding: '8'},
    {Id: 3, Melding: '9'},
    {Id: 4, Melding: 'Sol'},
    {Id: 5, Melding: '10'},
    {Id: 6, Melding: 'Ren sol'},
    {Id: 7, Melding: '11'},
    {Id: 8, Melding: 'Bordlægger'},
    {Id: 9, Melding: '12'},
    {Id: 10, Melding: 'Ren bordlægger'},
    {Id: 11, Melding: '13'},
    {Id: 12, Melding: 'Beskidt'}] as Melding[];
    plus = [{Id: 1, PlusNavn: 'Hårde'},
    {Id: 2, PlusNavn: 'Halve'},
    {Id: 3, PlusNavn: 'Sang'},
    {Id: 4, PlusNavn: 'VIP'},
    {Id: 5, PlusNavn: 'Gode'}] as Plus[];

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

  filterSpillere(id: string) {
    return this.spillereList.filter(filter => filter.Id !== Number.parseInt(id, 10));
  }
}
