using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Document : ValueObject
{
    private Document()
    {
        
    }
    public Document(string number,EDocumentType type)
    {
        Number = number;
        Type = type;
    }

    public string Number { get; private init; } = null!;
    public EDocumentType Type { get; private init; } 
}