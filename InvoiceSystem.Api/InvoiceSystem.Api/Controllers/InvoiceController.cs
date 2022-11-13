using InvoiceSystem.Api.Models;
using InvoiceSystem.Application.ViewModels;
using InvoiceSystem.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using InvoiceSystem.Infrastructure.Context;

namespace InvoiceSystem.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class InvoiceController : Controller
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet("GetInvoices")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<JsonResult> GetInvoices([FromQuery] Pagination page)
    {
        var result = await _invoiceService.GetInvoicesAsync(page.PageNumber, page.PageSize);
        
        return Json(result);
    }

    [HttpPost("CreateInvoice")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<JsonResult> CreateInvoice(InvoiceViewModel model)
    {
        var result = await _invoiceService.CreateInvoiceAsync(model);
        return Json(result);
    }

    [HttpPut("UpdateInvoice")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task UpdateInvoice(InvoiceViewModel model)
    {
        await _invoiceService.UpdateInvoiceAsync(model);
    }
}