using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.Entities;

public class StudentTests
{
    private readonly Student _student =new Student(new Name("teste","teste"),new Document("80827330049",EDocumentType.Cpf),new Email("kaiky@gmail.com"),new Address("brazil","sp","mogi ","120",02));
    private readonly Payment _payment =new PayPalPayment(DateTime.UtcNow, DateTime.UtcNow, 100, 100, new Address("brazil", "sp", "mogi ", "120", 02), new Document("80827330049", EDocumentType.Cpf), "teste", new Email("teste@gmail.com"), "123");
    
    [Fact]
    public void Add_Subscription_Should_Return_Error_When_Already_Exists_Subscription_Active()
    {
        var subscription = new Subscription(DateTime.UtcNow);
       
        subscription.AddPayment(_payment);
        _student.AddSubscription(subscription);
        _student.AddSubscription(subscription);
        
        Assert.False(_student.IsValid);
    }
    [Fact]
    public void Add_Subscription_Should_Return_Valid_When_No_Exists_Subscription_Active()
    {
        var subscription = new Subscription(DateTime.UtcNow);
       
        subscription.AddPayment(_payment);
        _student.AddSubscription(subscription);
        
        Assert.True(_student.IsValid);
    }
    [Fact]
    public void Add_Subscription_Should_Return_Error_When_Subscription_No_Contain_Payment()
    {
        var subscription = new Subscription(DateTime.UtcNow);
        
        _student.AddSubscription(subscription);
        
        Assert.False(_student.IsValid);
    }
}