export interface InvoiceModel {
    id: number;
    customerId: number;
    title: string;
    createDate: string;
    durationDate: string;
    status: number;
    currency: string;
    amount: number;
    description: string;
}
