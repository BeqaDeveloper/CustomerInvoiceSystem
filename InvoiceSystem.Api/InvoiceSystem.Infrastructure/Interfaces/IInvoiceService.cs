using InvoiceSystem.Application.ViewModels;

namespace InvoiceSystem.Infrastructure.Interfaces;
public interface IInvoiceService
{
    /// <summary>
    /// Get all Invoice.
    /// </summary>
    /// <param name="pageNumber">Page number.</param>
    /// <param name="pageSize">Page size.</param>
    /// <returns>Invoices.</returns>
    Task<List<InvoiceViewModel>> GetInvoicesAsync(int pageNumber, int pageSize);

    /// <summary>
    /// Create Invoice.
    /// </summary>
    /// <param name="model">Invoice view model.</param>
    /// <returns></returns>
    Task<int> CreateInvoiceAsync(InvoiceViewModel model);

    /// <summary>
    /// Update Invoice
    /// </summary>
    /// <param name="model">Invoice view model.</param>
    /// <returns></returns>
    Task UpdateInvoiceAsync(InvoiceViewModel model);

/// <summary>
/// Hard delete.
/// </summary>
/// <param name="id">Invoice id</param>
/// <returns></returns>
    Task DeleteInvoiceAsync(int id);
}