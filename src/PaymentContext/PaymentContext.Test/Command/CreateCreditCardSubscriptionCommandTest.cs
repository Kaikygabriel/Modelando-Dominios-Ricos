
using PaymentContext.Domain.Commands;

namespace PaymentContext.Test.Command;

public class CreateCreditCardSubscriptionCommandTest
{
    [Fact]
    public void Should_Return_Success_When_Create_Credit_Card_Subscription_Command_With_Parameters_Valid()
    {
        var command = new CreateCreditCardSubscriptionCommand(
            Guid.NewGuid(),
            "Teste",
            "4111111111111111",
            "TRANS123456",
            "SUB123456",
            DateTime.Now,
            DateTime.Now.AddYears(3),
            150.00m,
            150.00m,
            "Centro",
            "SP",
            "Mogi das Cruzes",
            "08710000",
            "Teste"
        );
        Assert.True(command.IsValid);
    }

    [Fact]
    public void Should_Return_Error_When_Create_Credit_Card_Subscription_Command_With_ZipCode_Invalid()
    {
        var command = new CreateCreditCardSubscriptionCommand(
            Guid.NewGuid(),
            "TEste",
            "4111111111111111",
            "TRANS123456",
            "SUB123456",
            DateTime.Now,
            DateTime.Now.AddYears(3),
            150.00m,
            150.00m,
            "Centro",
            "SP",
            "Mogi das Cruzes",
            "123",
            "Teste"
        );
        Assert.False(command.IsValid);
    }

    [Fact]
    public void Should_Return_Error_When_Create_Credit_Card_Subscription_Command_With_CreditCardNumber_Invalid()
    {
        var command = new CreateCreditCardSubscriptionCommand(
            Guid.NewGuid(),
            "TEste",
            "123",
            "TRANS123456",
            "SUB123456",
            DateTime.Now,
            DateTime.Now.AddYears(3),
            150.00m,
            150.00m,
            "Centro",
            "SP",
            "Mogi das Cruzes",
            "08710000",
            "Teste"
        );
        Assert.False(command.IsValid);
    }

    [Fact]
    public void Should_Return_Error_When_Create_Credit_Card_Subscription_Command_With_UserId_Null()
    {
        var command = new CreateCreditCardSubscriptionCommand(
            Guid.Empty,
            "TEste",
            "4111111111111111",
            "TRANS123456",
            "SUB123456",
            DateTime.Now,
            DateTime.Now.AddYears(3),
            150.00m,
            150.00m,
            "Centro",
            "SP",
            "Mogi das Cruzes",
            "08710000",
            "Teste"
        );
        Assert.False(command.IsValid);
    }
}
