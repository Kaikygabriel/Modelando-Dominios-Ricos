using Flunt.Br;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateCreditCardSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public CreateCreditCardSubscriptionCommand()
    {
    }
    public CreateCreditCardSubscriptionCommand(Guid userId, string cardName, string cardNumber, string lastTransactionNumber, string number, DateTime paidAt, DateTime expiredAt, decimal total, decimal totalPaid, string county, string state, string city, string zipCode, string payer)
    {
        UserId = userId;
        CardName = cardName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
        Number = number;
        PaidAt = paidAt;
        ExpiredAt = expiredAt;
        Total = total;
        TotalPaid = totalPaid;
        County = county;
        State = state;
        City = city;
        ZipCode = zipCode;
        Payer = payer;
        
        Validate();
    }

    public Guid UserId { get; set; }
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string LastTransactionNumber { get; set; }
    public string Number { get; set; }
    public DateTime  PaidAt { get; set; }
    public DateTime ExpiredAt { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string County { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string ZipCode { get;  set; }
    
    public string Payer { get;private set; }
    
    public void Validate()
    {
        AddNotifications(new Contract()
            .IsCep(ZipCode,"CreateCreditCardSubscriptionCommand.ZipCode","Cep Invalid")
            .IsCreditCard(CardNumber,"CreateCreditCardSubscriptionCommand.CardNumber")
            .IsNotNullOrEmpty(CardName,"CreateCreditCardSubscriptionCommand.CardName")
            .IsNotNullOrEmpty(CardNumber,"CreateCreditCardSubscriptionCommand.CardNumber")
            .IsNotNullOrEmpty(LastTransactionNumber,"CreateCreditCardSubscriptionCommand.LastTransactionNumber")
            .IsNotNullOrEmpty(Number,"CreateCreditCardSubscriptionCommand.Number")
            .IsNotNullOrEmpty(Payer,"CreateCreditCardSubscriptionCommand.Payer")
            .IsNotNullOrEmpty(UserId.ToString(),"CreateCreditCardSubscriptionCommand.UserId")
            .AreNotEquals(UserId , Guid.Empty,"CreateCreditCardSubscriptionCommand.UserId","UserId is Empty")
        );
    }
}