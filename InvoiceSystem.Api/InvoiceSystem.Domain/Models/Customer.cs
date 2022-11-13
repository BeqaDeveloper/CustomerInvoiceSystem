using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvoiceSystem.Domain.Models;

/// <summary>
/// Customer.
/// </summary>
[Table(nameof(Customer))]
public class Customer
{
    public Customer()
    {
        Invoices = new HashSet<Invoice>();
    }

    [Key]
    public int Id { get; set; }

    /// <summary>
    /// First name.
    /// </summary>
    [StringLength(100)]
    public string Firstname { get; set; }

    /// <summary>
    /// Last name.
    /// </summary>
    [StringLength(100)]
    public string Lastname { get; set; }

    /// <summary>
    /// Invoices.
    /// </summary>
    public virtual ICollection<Invoice> Invoices { get; set; }
}
