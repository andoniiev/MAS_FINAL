using MasFinal.Enums;

namespace MasFinal.Models
{
    /// <summary>
    /// Represents a payment.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets or sets the ID of the payment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the amount of the payment.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the name of the payer.
        /// </summary>
        public string? PayerName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the payer.
        /// </summary>
        public string? PayerEmail { get; set; }

        /// <summary>
        /// Gets or sets the credit card number used for the payment.
        /// </summary>
        public string? CreditNumber { get; set; }

        /// <summary>
        /// Gets or sets the current balance on the credit card.
        /// </summary>
        public int? CardBalance { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank used for the payment.
        /// </summary>
        public string? BankName { get; set; }

        /// <summary>
        /// Gets or sets the account number used for the payment.
        /// </summary>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the current balance in the bank account.
        /// </summary>
        public int? AccountBalance { get; set; }

        /// <summary>
        /// Gets or sets the type of payment.
        /// </summary>
        public PaymentType PaymentType { get; set; }
    }
}
