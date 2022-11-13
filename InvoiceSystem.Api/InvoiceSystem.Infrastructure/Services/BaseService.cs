using InvoiceSystem.Infrastructure.Context;

namespace InvoiceSystem.Infrastructure.Services;

public abstract class BaseService
{
    protected readonly InvoiceSystemDbContext Context;

    protected BaseService(InvoiceSystemDbContext context)
    {
        Context = context;
    }
}