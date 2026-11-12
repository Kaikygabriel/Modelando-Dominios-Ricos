using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PayPalPayment: Payment
{
    
    public PayPalPayment(DateTime paidAt, DateTime expiredAt, decimal total, decimal totalPaid, Address address, Document document, string payer, Email email, string transactionCode) : base(expiredAt, total, totalPaid, address, document, payer, email)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode { get; private set; } = null!;
}