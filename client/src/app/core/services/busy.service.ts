import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {

  busyRequestCnt = 0;

  Busy() {
    this.busyRequestCnt++;

    this.spinnerService.show(undefined, {
      type : 'timer',
      bdColor: 'rgba(255,255,255,0.7)',
      color:'#333333'
      }

    );

  }

  Idle() {

    this.busyRequestCnt--;
    if (this.busyRequestCnt <= 0)
    {
      this.busyRequestCnt = 0;
      this.spinnerService.hide();

    }


  }

  constructor(private spinnerService: NgxSpinnerService) {
    
   


  }
}
