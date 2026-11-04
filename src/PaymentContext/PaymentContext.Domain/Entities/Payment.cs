using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public abstract class Payment
{
  
    protected Payment(DateTime paidAt, DateTime expiredAt, decimal total, decimal totalPaid,Address address, Document document, string payer, Email email)
    {
        Number = Guid.NewGuid().ToString().Replace("-","")[..10];
        PaidAt = paidAt;
        ExpiredAt = expiredAt;
        Total = total;
        TotalPaid = totalPaid;
        Address = address;
        Document = document;
        Payer = payer;
        Email = email;
    }

    public string Number { get;private set; }
    public DateTime  PaidAt { get;private set; }
    public DateTime ExpiredAt { get;private set; }
    public decimal Total { get;private set; }
    public decimal TotalPaid { get;private set; }
    public Address Address { get;private set; }
    public Document Document { get;private set; }
    public string Payer { get;private set; }
    public Email Email { get; private set; } 
}