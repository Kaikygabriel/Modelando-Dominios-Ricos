using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment: Payment
{
    public BoletoPayment(DateTime expiredAt, decimal total, decimal totalPaid, Address address, Document document, string payer, Email email, string codeBar, string boletoNumber) : base(expiredAt, total, totalPaid, address, document, payer, email)
    {
        CodeBar = codeBar;
        BoletoNumber = boletoNumber;
    }

    public string CodeBar { get;private set; }
    public string BoletoNumber { get;private set; }
}