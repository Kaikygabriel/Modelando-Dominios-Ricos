using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    private Address()
    {
        
    }
    public Address(string county, string state, string city, string zipCode, int number)
    {
        County = county;
        State = state;
        City = city;
        ZipCode = zipCode;
        Number = number;
    }

    public string County { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public int Number { get; private set; }
}