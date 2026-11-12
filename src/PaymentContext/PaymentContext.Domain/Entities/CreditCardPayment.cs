using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    
    public CreditCardPayment( DateTime expiredAt, decimal total, decimal totalPaid, Address address, Document document, string payer, Email email, string cardName, string cardNumber, string lastTransactionNumber) : base( expiredAt, total, totalPaid, address, document, payer, email)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }

    public string CardName { get;private set; }
    public string CardNumber { get;private set; }
    public string LastTransactionNumber { get;private set; }
    
}