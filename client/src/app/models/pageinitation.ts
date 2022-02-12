import { IProduct } from "./product";



  export interface IPageInitation {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IProduct[];
  }



