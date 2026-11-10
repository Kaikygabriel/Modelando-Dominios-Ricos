using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Commands;

public class CreateBoletoSubscriptionCommand
{
    public Guid UserId { get; set; }
    public string CodeBar { get; set; }
    public string BoletoNumber { get; set; }
    public string Number { get; set; }
    public DateTime  PaidAt { get; set; }
    public DateTime ExpiredAt { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public Address Address { get; set; }
    public string Payer { get;private set; }
}