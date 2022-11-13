using InvoiceSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace InvoiceSystem.Application.ViewModels;

/// <summary>
/// Invoice view model.
/// </summary>
public class InvoiceViewModel
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    /// <summary>
    /// Title.
    /// </summary>
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// Create date.
    /// </summary>
    [Required]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Duration date.
    /// </summary>
    [Required]
    public DateTime DurationDate { get; set; }

    /// <summary>
    /// Status.
    /// </summary>
    public InvoiceStatusType Status { get; set; }

    /// <summary>
    /// Currency.
    /// </summary>
    [Required]
    public string Currency { get; set; }

    /// <summary>
    /// Amount.
    /// </summary>
    [Required]
    [Range(0.01d, 1_000_000_000)]
    public decimal Amount { get; set; }

    /// <summary>
    /// Description.
    /// </summary>
    public string Description { get; set; }
}
