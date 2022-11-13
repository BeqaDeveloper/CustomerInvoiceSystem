using AutoMapper;
using InvoiceSystem.Application.ViewModels;
using InvoiceSystem.Domain.Models;
using InvoiceSystem.Infrastructure.Context;
using InvoiceSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Infrastructure.Services;

/// <summary>
/// Invocie service.
/// </summary>
public class InvoiceService : BaseService, IInvoiceService
{
    private readonly IMapper _mapper;
    private readonly InvoiceSystemDbContext _context;

    public InvoiceService(InvoiceSystemDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
        _context = context;
    }

    /// <summary>
    /// Get all invoices.
    /// </summary>
    /// <param name="pageNumber">Page number.</param>
    /// <param name="pageSize">Page size.</param>
    /// <returns>Invoices.</returns>
    public async Task<List<InvoiceViewModel>> GetInvoicesAsync(int pageNumber, int pageSize)
    {
        var data = await _context.Invoices.OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToListAsync();

        var result = _mapper.Map<List<Invoice>, List<InvoiceViewModel>>(data);
        return result;
    }

    /// <summary>
    /// Create invoice.
    /// </summary>
    /// <param name="model">Invoice view model.</param>
    /// <returns></returns>
    public async Task<int> CreateInvoiceAsync(InvoiceViewModel model)
    {
        var invoice = _mapper.Map<Invoice>(model);
        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return invoice.Id;
    }

    /// <summary>
    /// Update invoice.
    /// </summary>
    /// <param name="model">Invoice view model.</param>
    /// <returns></returns>
    public async Task UpdateInvoiceAsync(InvoiceViewModel model)
    {
        var invoice = await _context.Invoices.FindAsync(model.Id);
        if (invoice != null)
        {
            invoice.Amount = model.Amount;
            invoice.Currency = model.Currency;
            invoice.Status = model.Status;
            invoice.Description = model.Description;
            invoice.DurationDate = model.DurationDate;
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Hard delete of invoice.
    /// </summary>
    /// <param name="id">Invoice id.</param>
    /// <returns></returns>
    public async Task DeleteInvoiceAsync(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        await _context.SaveChangesAsync();
    }
}