using System.ComponentModel.DataAnnotations;
using InvoiceSystem.Domain.Enums;

namespace InvoiceSystem.Domain.Models;

    /// <summary>
    /// Invoices.
    /// </summary>
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        /// <summary>
        /// Customer of invoice.
        /// </summary>
        [Required]
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Duration date.
        /// </summary>
        [Required]
        public DateTime DurationDate { get; set; }

        /// <summary>
        /// Invoice status type.
        /// </summary>
        [Required]
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
        public decimal Amount { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [Required]
        [StringLength(5000)]
        public string Description { get; set; }
    }
