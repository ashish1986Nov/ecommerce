import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { IProduct } from './shared/models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  products: IProduct[];

  constructor() {


  }
  ngOnInit(): void {


  }

}
