import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopService } from './shop.service';
import { FormsModule } from '@angular/forms';
import { ShopParams } from '../shared/models/shopparams';


@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  @ViewChild('search', { static: true }) searchTerm: ElementRef;


  products: IProduct[];
  brands: IBrand[];
  prdouctTypes: IType[];

  totalCount = 0;

  shopParams = new ShopParams();


  SortOptions = [{ name: 'Alphabetical', value: 'name' },
  { name: 'Price : Low to High ', value: 'priceAsc' },
  { name: 'Price : High To Low ', value: 'priceDesc' }
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {

    this.getProducts();
    this.getTypes();
    this.getBrands();

  }


  getProducts( ) {

    this.shopService.getProducts(this.shopParams).subscribe(
      response => {

        this.products = response.data;

        this.shopParams.pageSize = response.pageSize;
        this.shopParams.pageNumber = response.pageIndex;
        this.totalCount = response.count;


      }, error => {

        console.log(error);

      }
    )

  }



  getTypes() {

    this.shopService.getProductTypes().subscribe(
      response => {

        this.prdouctTypes = [{ id: 0, name: 'All' }, ...response];    


      }, error => {

        console.log(error);

      }
    )

  }



  getBrands() {

    this.shopService.getBrands().subscribe(
      response => {

        this.brands = [{ id: 0, name: 'All' }, ...response];
       


      }, error => {

        console.log(error);

      }
    )

  }



  OnBrandSelected(brandId: number) {


    this.shopParams.brandId = brandId;
    this.getProducts();



  }

  OnProductTypeSelected(typeId: number) {

    this.shopParams.typeId = typeId;

    this.getProducts();


  }

  OnSortSelected(sortOrder: string) {


    this.shopParams.sortOrder = sortOrder;

    console.log("OnSortSelected" + sortOrder);

    this.getProducts();

  }

  OnPageChanged(event: any) {

    this.shopParams.pageNumber = event;
    this.getProducts();


  }

  OnSearch() {

    this.shopParams.searchText = this.searchTerm.nativeElement.value;
    this.getProducts();


  }

  OnReset() {

    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();

    this.getProducts();

  }


}
