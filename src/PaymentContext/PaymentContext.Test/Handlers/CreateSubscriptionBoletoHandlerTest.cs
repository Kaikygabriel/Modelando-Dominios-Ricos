using PaymentContext.Domain.Commands.Subscriptions;
using PaymentContext.Domain.Handlers;
using PaymentContext.Test.Mocks;

namespace PaymentContext.Test.Handlers;

public class CreateSubscriptionBoletoHandlerTest
{
    private readonly CreateSubscriptionHandler _handler;
    private readonly Guid _studentId = Guid.Parse("ecefb01c-c7b2-49cd-8780-92018ead1460");

    public CreateSubscriptionBoletoHandlerTest()
    {
        _handler = new CreateSubscriptionHandler(new FakeStudentRepository(),new FakeEmailService());
    }

    [Fact]
    public async Task Should_Return_Success()
    {
        var commandValid = new CreateBoletoSubscriptionCommand(_studentId, "12345", "9931", "23415", DateTime.UtcNow,
            DateTime.UtcNow.AddMonths(1), 100,100,"Brazil","São Paulo","São Paulo","69087090",0,"teste");
        var result =await _handler.Handle(commandValid);
        Assert.True(_handler.IsValid);
    }
    
    [Fact]
    public async Task Should_Return_Error_When_Command_is_Invalid()
    {
        var commandInvalid = new CreateBoletoSubscriptionCommand(_studentId, "", "", "", DateTime.UtcNow,
            DateTime.UtcNow.AddMonths(1), 0,0,"","","","",0,"");
        var result =await _handler.Handle(commandInvalid);
        Assert.False(_handler.IsValid);
    }
    
    [Fact]
    public async Task Should_Return_Error_When_Student_Not_Found()
    {
        var idRandom = Guid.NewGuid();
        var command = new CreateBoletoSubscriptionCommand(idRandom, "12345", "9931", "23415", DateTime.UtcNow,
            DateTime.UtcNow.AddMonths(1), 100,100,"Brazil","São Paulo","São Paulo","69087-090",0,"teste");
        var result =await _handler.Handle(command);
        Assert.False(_handler.IsValid);
    }
}