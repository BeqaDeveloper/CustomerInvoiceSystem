import { InvoiceModel } from "./invoice.model";

export interface CustomerModel {
    id: number;
    firstname: string;
    lastname: string;
    phone: string;
    invoices: InvoiceModel[];
}