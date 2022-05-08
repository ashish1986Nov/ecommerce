import { Injectable } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import {ToastrService } from 'ngx-toastr';


import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { catchError, delay, Observable, throwError } from 'rxjs';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router  , private toaster : ToastrService  ) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(

      delay(1),

      catchError(error => {
        if (error) {


          

          if (error.status == 404) {
            this.toaster.error(error.error.message, error.error.StatusCode);
          }

          if (error.status == 400) {

            if (error.error.errors) {

              throw error.error;
            }
            else {

              this.toaster.error(error.error.Message, error.error.StatusCode);
            }
          }


          if (error.status == 404) {

          //  this.router.navigateByUrl('/not-found');
          }


          if (error.status == 500) {
            const  navExtra : NavigationExtras = {
              state: { error: error.error }
            }

            this.router.navigateByUrl('/server-error', navExtra);
          }

          return throwError(error);
        }
      })
    );
  }
}
