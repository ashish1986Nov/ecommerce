import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { IProduct } from '../../shared/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() singleProduct: IProduct;

  constructor() { }

  ngOnInit(): void {
  }

}
