using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Name : ValueObject
{
    private Name()
    {
        
    }
    public Name(string firstName, string lastName)
    {
        AddNotifications(new Contract<Notification>().Requires()
            .IsNotNullOrWhiteSpace(firstName,"Name.firstName")
            .IsNotNullOrWhiteSpace(lastName,"Name.LastName"));
        
        FirstName = firstName;
        LastName = lastName;
        
    }

    public string FirstName { get;private set; }= null!;
    public string LastName { get;private set; }= null!;    
}