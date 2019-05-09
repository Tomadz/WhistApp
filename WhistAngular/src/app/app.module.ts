import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms"
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { RunderComponent } from './runder/runder.component';
import { RundeComponent } from './runder/runde/runde.component';
import { RundeListComponent } from './runder/runde-list/runde-list.component';
import { RundeService } from './shared/runde.service';

@NgModule({
  declarations: [
    AppComponent,
    RunderComponent,
    RundeComponent,
    RundeListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [RundeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
