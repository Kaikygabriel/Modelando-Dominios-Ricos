using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public abstract class Payment : Entity
{
  
    protected Payment(DateTime expiredAt, decimal total, decimal totalPaid,Address address, Document document, string payer, Email email)
    {
        Number = Guid.NewGuid().ToString().Replace("-","")[..10];
        
        ExpiredAt = expiredAt;
        Total = total;
        TotalPaid = totalPaid;
        Address = address;
        Document = document;
        Payer = payer;
        Email = email;
        
        AddNotifications(address,document,email);
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

    public void Paid(DateTime paidAt)
    {
        PaidAt = paidAt;
    }
}