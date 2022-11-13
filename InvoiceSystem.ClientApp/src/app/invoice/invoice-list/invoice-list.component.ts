import { Component, OnInit } from '@angular/core';
import { map, Observable, subscribeOn } from 'rxjs';
import { InvoiceModel } from 'src/app/shared/models/invoice.model';
import { InvoiceService } from 'src/app/shared/services/invoice.service';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrls: ['./invoice-list.component.css']
})
export class InvoiceListComponent implements OnInit {

  invoiceList!: InvoiceModel[];
  isNewInvoice = true;

  constructor(private invoiceService: InvoiceService) { }

  ngOnInit(): void {
    this.invoiceService.GetInvoiceList(0,10).subscribe(res => {
      this.invoiceList = res;
    });
  }

  editInvoice(invoice: InvoiceModel){
    console.log("editInvoice")
    console.log(invoice)
    this.invoiceService.invoice$.subscribe({
      next: (v) => console.log(v),
    });
    this.invoiceService.invoice$.next(invoice);
    this.isNewInvoice = false;
  }
}
