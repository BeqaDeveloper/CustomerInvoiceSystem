import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerModel } from 'src/app/shared/models/customer.model';
import { InvoiceModel } from 'src/app/shared/models/invoice.model';
import { CustomerService } from 'src/app/shared/services/customer.service';
import { InvoiceService } from 'src/app/shared/services/invoice.service';

@Component({
  selector: 'app-create-invoice',
  templateUrl: './create-invoice.component.html',
  styleUrls: ['./create-invoice.component.css']
})
export class CreateInvoiceComponent implements OnInit {

  constructor(private invoiceService: InvoiceService, private customerService: CustomerService) { }
  @Input() isNewInvoice!: boolean;
  invoice: InvoiceModel =  {} as InvoiceModel;
  customerList!: CustomerModel[];

  ngOnInit(): void {
    this.customerService.GetCustomerList(0, 1).subscribe(res => {
      this.customerList = res
    });
  }

  createInvoice() {
    this.invoiceService.invoice$.next(this.invoice);
    if (this.isNewInvoice)
      this.invoiceService.Create().subscribe(res => {
        this.invoiceService.GetInvoiceList(1, 10);
      });
    else
      this.invoiceService.Update().subscribe(res => {
        this.invoiceService.GetInvoiceList(1, 10);
      });
  }
}
