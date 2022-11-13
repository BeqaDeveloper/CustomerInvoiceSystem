using InvoiceSystem.Application.ViewModels;

namespace InvoiceSystem.Infrastructure.Interfaces;
    public interface ICustomerService
    {
        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Customers.</returns>
        Task<List<CustomerViewModel>> GetCustomersAsync(int pageNumber, int pageSize);
    }
