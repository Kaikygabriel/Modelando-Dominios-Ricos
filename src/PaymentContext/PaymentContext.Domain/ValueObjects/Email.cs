using System.Text.RegularExpressions;
using Flunt.Validations;
using PaymentContext.Domain.Exceptions;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    private Email()
    {
        
    }
    public Email(string address)
    {
        AddNotifications(new Contract<Email>().Requires().IsEmail(address, "Email.Address"));
        
        Address = address;
    }

    public string Address { get; private init; } = null!;
}