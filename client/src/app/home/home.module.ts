import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { AppRoutingModule } from '../app-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    SharedModule
  ],
  exports:[ HomeComponent]
})
export class HomeModule { }
