import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { CustomerModel } from '../models/customer.model';
import { ErrorService } from './common/error.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  constructor(private httpclient: HttpClient,
    private errorService: ErrorService) { }

  GetCustomerList(page: number, pageSize: number) : Observable<CustomerModel[]> {
    return this.httpclient.get<CustomerModel[]>('https://localhost:7233/customer/List', {
      params: new HttpParams({
        fromObject: { page: page, pageSize: pageSize }
      })
    }).pipe();
  }

  private errorHandler(error: HttpErrorResponse){
    this.errorService.handle(error.message);
    return throwError(()=>error.message);
  }
}
