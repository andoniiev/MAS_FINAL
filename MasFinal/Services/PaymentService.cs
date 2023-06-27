using MasFinal.Enums;
using MasFinal.Models;
using System.Text.RegularExpressions;

namespace MasFinal.Services
{
    /// <summary>
    /// Service class for processing payments.
    /// </summary>
    public class PaymentService : IPaymentService
    {
        /// <summary>
        /// Processes a payment.
        /// </summary>
        /// <param name="payment">The payment object containing payment details.</param>
        public void ProcessPayment(Payment payment)
        {
            if (payment.PaymentType == PaymentType.CreditCard)
            {
                if (!IsValidName(payment.PayerName))
                {
                    // Payer name is not valid, reject payment
                    RejectPayment("Invalid payer name");
                    return;
                }

                if (!IsValidEmail(payment.PayerEmail))
                {
                    // Payer email is not valid, reject payment
                    RejectPayment("Invalid payer email");
                    return;
                }

                if (!IsValidCreditCardNumber(payment.CreditNumber))
                {
                    // Credit card number is not valid, reject payment
                    RejectPayment("Invalid credit card number");
                    return;
                }

                if (payment.CardBalance < payment.Amount)
                {
                    // Insufficient card balance, reject payment
                    RejectPayment("Insufficient card balance");
                    return;
                }

                // Confirm successful payment
                ConfirmPayment("Payment successful");
            }
            else if (payment.PaymentType == PaymentType.BankTransfer)
            {
                if (!IsValidBankName(payment.BankName))
                {
                    // Bank name is not valid, reject payment
                    RejectPayment("Invalid bank name");
                    return;
                }

                if (!IsValidAccountNumber(payment.AccountNumber))
                {
                    // Account number is not valid, reject payment
                    RejectPayment("Invalid account number");
                    return;
                }

                if (payment.AccountBalance < payment.Amount)
                {
                    // Insufficient account balance, reject payment
                    RejectPayment("Insufficient account balance");
                    return;
                }

                // Confirm successful payment
                ConfirmPayment("Payment successful");
            }
            else
            {
                // Invalid payment type, reject payment
                RejectPayment("Invalid payment type");
            }
        }

        private void ConfirmPayment(string message)
        {
            // Logic to confirm successful payment
            Console.WriteLine(message);
        }

        private void RejectPayment(string message)
        {
            // Logic to reject payment
            Console.WriteLine(message);
        }

        private bool IsValidName(string? name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            // Regular expression to validate name (example pattern)
            var regex = new Regex(@"^[a-zA-Z\s]+$");
            return regex.IsMatch(name);
        }

        private bool IsValidEmail(string? email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // Regular expression to validate email (example pattern)
            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);
        }

        private bool IsValidCreditCardNumber(string? cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return false;

            // Regular expression to validate credit card number (example pattern)
            var regex = new Regex(@"^\d{16}$");
            return regex.IsMatch(cardNumber);
        }

        private bool IsValidBankName(string? bankName)
        {
            if (string.IsNullOrEmpty(bankName))
                return false;

            // Regular expression to validate bank name (example pattern)
            var regex = new Regex(@"^[a-zA-Z\s]+$");
            return regex.IsMatch(bankName);
        }

        private bool IsValidAccountNumber(string? accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
                return false;

            // Regular expression to validate account number (example pattern)
            var regex = new Regex(@"^\d{10}$");
            return regex.IsMatch(accountNumber);
        }
    }
}
