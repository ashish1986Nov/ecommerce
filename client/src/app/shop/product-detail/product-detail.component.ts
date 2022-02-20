import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {


  productDetails : IProduct
  constructor(private shopService :ShopService ,
    private activetedRoot : ActivatedRoute ) { }

  ngOnInit(): void {

    this.loadProduct();
  }


  loadProduct()
  {

    this.shopService.getproductDetails(+this.activetedRoot.snapshot.paramMap.get('id')).subscribe(product=>
      {

      this.productDetails=product  
      console.log("product Details name" +  this.productDetails.name);
      },
      error =>  {
console.log(error);

      }
      );

  }

}
