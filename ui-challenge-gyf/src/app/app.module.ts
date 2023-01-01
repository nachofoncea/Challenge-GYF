import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule,HTTP_INTERCEPTORS } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { VentaComponent } from './venta/venta.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button'; 


@NgModule({
  declarations: [
    HomeComponent,
    VentaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule
  ],
  providers: [HttpClientModule],
  bootstrap: [HomeComponent]
})
export class AppModule { }
