using InvoiceSystem.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using InvoiceSystem.Api.Models;

namespace InvoiceSystem.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("GetCustomers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<JsonResult> GetCustomers([FromQuery] Pagination page)
    { 
        var result = await _customerService.GetCustomersAsync(page.PageNumber, page.PageSize);
        return Json(result);
    }
}