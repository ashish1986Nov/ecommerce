import { CompilerConfig } from '@angular/compiler';
import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductDetailComponent } from './shop/product-detail/product-detail.component';
import { ProductItemComponent } from './shop/product-item/product-item.component';
import { ShopComponent } from './shop/shop.component';

const approutes: Routes = [

  {path : '' ,  component  : HomeComponent},
  {path : 'shop' ,  loadChildren:() => import('./shop/shop.module').
  then(mod=>mod.ShopModule) },

  {path : '**' , redirectTo :'', pathMatch : 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(approutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
