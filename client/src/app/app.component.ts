import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { IPageInitation } from './models/pageinitation';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  products: IProduct[];

  constructor(private http: HttpClient) {


  }
  ngOnInit(): void {

    this.http.get("https://localhost:7194/api/product?pageSize=50").subscribe((response: IPageInitation) => {
      this.products = response.data;

      console.log(response);

    },
      error => {


        console.log(error);


      }
      );
  }
}
