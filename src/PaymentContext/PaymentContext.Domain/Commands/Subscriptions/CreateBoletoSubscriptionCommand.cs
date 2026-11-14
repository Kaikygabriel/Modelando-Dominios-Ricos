using Flunt.Br;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands.Subscriptions;

public class CreateBoletoSubscriptionCommand : Notifiable<Notification>,ICommand
{
    public CreateBoletoSubscriptionCommand()
    {
        
    }
    public CreateBoletoSubscriptionCommand(Guid userId, string codeBar, string boletoNumber, string number, DateTime paidAt, DateTime expiredAt, decimal total, decimal totalPaid, string county, string state, string city, string zipCode, int addressNumber, string payer)
    {
        UserId = userId;
        CodeBar = codeBar;
        BoletoNumber = boletoNumber;
        Number = number;
        PaidAt = paidAt;
        ExpiredAt = expiredAt;
        Total = total;
        TotalPaid = totalPaid;
        County = county;
        State = state;
        City = city;
        ZipCode = zipCode;
        AddressNumber = addressNumber;
        Payer = payer;
    }

    public Guid UserId { get; set; }
    public string CodeBar { get; set; }
    public string BoletoNumber { get; set; }
    public string Number { get; set; }
    public DateTime  PaidAt { get; set; }
    public DateTime ExpiredAt { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string County { get;  set; }
    public string State { get;  set; }
    public string City { get;  set; }
    public string ZipCode { get;  set; }
    public int AddressNumber { get;  set; }
    public string Payer { get;private set; }
    
    public void Validate()
    {
        AddNotifications(new Contract()
            .IsCep(ZipCode,"CreateBoletoSubscriptionCommand.ZipCode","Cep invalid")
            .IsNotNull(UserId,"CreateBoletoSubscriptionCommand.UserId","UserId Invalid")
            .IsNotNullOrWhiteSpace(Payer,"CreateBoletoSubscriptionCommand.Payer")
            .IsNotNullOrWhiteSpace(CodeBar,"CreateBoletoSubscriptionCommand.CodeBar")
            .IsNotNullOrWhiteSpace(BoletoNumber,"CreateBoletoSubscriptionCommand.BoletoNumber")
            .IsNotNullOrWhiteSpace(Number,"CreateBoletoSubscriptionCommand.Number")
            .IsNotNullOrWhiteSpace(County,"CreateBoletoSubscriptionCommand.County")
            .IsNotNullOrWhiteSpace(State,"CreateBoletoSubscriptionCommand.State")
            .IsNotNullOrWhiteSpace(City,"CreateBoletoSubscriptionCommand.City")
            .IsGreaterThan(Total,0,"CreateBoletoSubscriptionCommand.Total")
            .IsGreaterThan(TotalPaid,0,"CreateBoletoSubscriptionCommand.TotalPaid")
        );
    }
}