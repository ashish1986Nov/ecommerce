import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { IBrand } from '../shared/models/brand';
import { IPageInitation } from '../shared/models/pageinitation';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopparams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = "https://localhost:7194/api/";
 
  constructor(private http: HttpClient) { }


  getProducts(shopParams: ShopParams) {

    let params = new HttpParams();

    if (shopParams.brandId !=0) {

      params = params.append('brandId', shopParams.brandId.toString());
    }

    if (shopParams.typeId != 0) {

      params = params.append('typeId', shopParams.typeId.toString());

    }

    if (shopParams.sortOrder ) {

      params = params.append('sort', shopParams.sortOrder);

    }

    if (shopParams.searchText) {


      params = params.append('search', shopParams.searchText);

    }

    params = params.append("pageIndex", shopParams.pageNumber.toString());
    params = params.append("pageSize", shopParams.pageSize.toString());


    return this.http.get<IPageInitation>(this.baseUrl + 'product?pageSize=2', { observe: 'response', params }).
      pipe(map(response => {

        return response.body;

      })


      );
  }

  getBrands() {

    return this.http.get<IBrand[]>(this.baseUrl + 'product/brand');
  }

  getProductTypes() {

    return this.http.get<IType[]>(this.baseUrl + 'product/type');
  }


  getproductDetails(id:number)
  {
    console.log("product Details id1 " +  id);

    return this.http.get<IProduct>(this.baseUrl + 'product/' + id);


  }

}
