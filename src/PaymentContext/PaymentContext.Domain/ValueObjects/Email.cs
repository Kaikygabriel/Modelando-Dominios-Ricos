using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    private Email()
    {
        
    }
    public Email(string address)
    {
        Address = address;
    }

    public string Address { get; private init; } = null!;
}