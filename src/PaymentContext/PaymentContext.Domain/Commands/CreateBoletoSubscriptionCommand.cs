using Flunt.Br;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateBoletoSubscriptionCommand : Notifiable<Notification>,ICommand
{
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
            .IsNull(UserId,"CreateBoletoSubscriptionCommand.UserId","UserId Invalid")
            .IsNotNullOrEmpty(Payer,"CreateBoletoSubscriptionCommand.Payer")
            .IsNotNullOrEmpty(CodeBar,"CreateBoletoSubscriptionCommand.CodeBar")
            .IsNotNullOrEmpty(CodeBar,"CreateBoletoSubscriptionCommand.BoletoNumber")
            .IsNotNullOrEmpty(CodeBar,"CreateBoletoSubscriptionCommand.Number")
            .IsNotNullOrEmpty(CodeBar,"CreateBoletoSubscriptionCommand.County")
            .IsNotNullOrEmpty(CodeBar,"CreateBoletoSubscriptionCommand.State")
            .IsNotNullOrEmpty(CodeBar,"CreateBoletoSubscriptionCommand.City")
            .IsNotNullOrEmpty(CodeBar,"CreateBoletoSubscriptionCommand.ZipCode")
            .IsGreaterThan(0,Total,"CreateBoletoSubscriptionCommand.Total")
            .IsGreaterThan(0,TotalPaid,"CreateBoletoSubscriptionCommand.TotalPaid")
        );
    }
}