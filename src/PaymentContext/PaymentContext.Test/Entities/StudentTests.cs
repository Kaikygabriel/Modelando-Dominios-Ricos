

using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.Entities;

public class StudentTests
{
    public void Add_Subscription_Should_Return_Error_When_Already_Exists_Subscription_Active()
    {
        var student = new Student(new Name("teste","teste"),new Document("80827330049",EDocumentType.Cpf),new Email("kaiky@gmail.com"),new Address("brazil","sp","mogi ","120",02));
        var subscription = new Subscription(DateTime.UtcNow);
        
        student.AddSubscription(subscription);
        student.AddSubscription(subscription);
        
        Assert.False(student.IsValid);
    }
    
    public void Add_Subscription_Should_Return_Valid_When_No_Exists_Subscription_Active()
    {
        var student = new Student(new Name("teste","teste"),new Document("80827330049",EDocumentType.Cpf),new Email("kaiky@gmail.com"),new Address("brazil","sp","mogi ","120",02));
        var subscription = new Subscription(DateTime.UtcNow);
        
        student.AddSubscription(subscription);
        Assert.True(student.IsValid);
    }
}