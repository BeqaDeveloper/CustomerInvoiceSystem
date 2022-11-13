import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, throwError } from 'rxjs';
import { InvoiceModel } from '../models/invoice.model';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'
import { ErrorService } from './common/error.service';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  public invoice$:  Subject<InvoiceModel>= new BehaviorSubject<InvoiceModel>({} as InvoiceModel);
  public invoiceList$: Subject<InvoiceModel[]> = new BehaviorSubject<InvoiceModel[]>([]);

  constructor(private httpclient: HttpClient, private errorService: ErrorService) { }

  GetInvoiceList(page: number, pageSize: number) : Observable<InvoiceModel[]> {
    return this.httpclient.get<InvoiceModel[]>(`https://localhost:7233/Invoice/List?page=0&pageSize=10`);
  }

  Create(): Observable<InvoiceModel> {
    console.log("Create")
    return this.httpclient.post<InvoiceModel>('https://localhost:7233/Invoice/Create', this.invoice$);
  }

  Update(): Observable<InvoiceModel> {
    console.log("Update");
    return this.httpclient.put<InvoiceModel>('https://localhost:7233/Invoice/Update', this.invoice$);
  }

  private errorHandler(error: HttpErrorResponse){
    this.errorService.handle(error.message);
    return throwError(()=>error.message);
  }
}
