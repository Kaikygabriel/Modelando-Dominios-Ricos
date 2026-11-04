using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Name : ValueObject
{
    private Name()
    {
        
    }
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get;private set; }= null!;
    public string LastName { get;private set; }= null!;    
}