using MasFinal.Models;

namespace MasFinal.Services
{
    /// <summary>
    /// Interface for payment-related operations.
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Processes the specified payment.
        /// </summary>
        /// <param name="payment">The payment to be processed.</param>
        void ProcessPayment(Payment payment);
    }
}
