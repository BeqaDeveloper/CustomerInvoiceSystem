using AutoMapper;
using InvoiceSystem.Application.ViewModels;
using InvoiceSystem.Infrastructure.Context;
using InvoiceSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Infrastructure.Services;

/// <summary>
/// Customer service.
/// </summary>
public class CustomerService : BaseService, ICustomerService
{
    private readonly IMapper _mapper;
    private readonly InvoiceSystemDbContext _context;

    public CustomerService(InvoiceSystemDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
        _context = context;
    }

    /// <summary>
    /// Get all customers.
    /// </summary>
    /// <param name="pageNumber">Page number.</param>
    /// <param name="pageSize">Page Size.</param>
    /// <returns>Customers.</returns>
    public async Task<List<CustomerViewModel>> GetCustomersAsync(int pageNumber, int pageSize)
    {
        var data = await _context.Customers.OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToListAsync();

        var result = _mapper.Map<List<CustomerViewModel>>(data);
        return result;
    }
}