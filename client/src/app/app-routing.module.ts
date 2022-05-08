import { CompilerConfig } from '@angular/compiler';
import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductDetailComponent } from './shop/product-detail/product-detail.component';
import { ProductItemComponent } from './shop/product-item/product-item.component';
import { ShopComponent } from './shop/shop.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { NotFoundComponent } from './core/not-found/not-found.component';

const approutes: Routes = [

  { path: '', component: HomeComponent, data: { breadcrumb: 'HOME' } },
  { path: 'test-error', component: TestErrorComponent, data: {breadcrumb:'TEST-ERROR'} },
  { path: 'server-error', component: ServerErrorComponent, data: { breadcrumb: 'SERVER-ERROR' }},
  { path: 'not-found', component: NotFoundComponent, data: { breadcrumb: 'NOT-FOUND' } },

  {path : 'shop' ,  loadChildren:() => import('./shop/shop.module').
    then(mod => mod.ShopModule),  data: { breadcrumb: 'SHOP' }},
  {path : '**' , redirectTo :'not-found', pathMatch : 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(approutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
