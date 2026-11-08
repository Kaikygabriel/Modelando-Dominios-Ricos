using Flunt.Notifications;
using Flunt.Validations;
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
        
        AddNotifications(new Contract<Notification>().IsTrue(Validate(),"Document.Number","Document Invalid"));
    }

    public string Number { get; private init; } = null!;
    public EDocumentType Type { get; private init; }

    private bool Validate() 
    {
        if (Type == EDocumentType.Rg && Number.Length == 9)
            return true;
        if ((Type == EDocumentType.Cpf || Type == EDocumentType.Cin ) && Number.Length == 11)
            return true;

        return false;
    }
}