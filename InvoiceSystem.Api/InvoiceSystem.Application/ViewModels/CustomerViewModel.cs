using System.ComponentModel.DataAnnotations;

namespace InvoiceSystem.Application.ViewModels;

/// <summary>
/// Customer view model.
/// </summary>
    public class CustomerViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        [Required]
        public string Firstname { get; private set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [Required]
        public string Lastname { get; private set; }
}
