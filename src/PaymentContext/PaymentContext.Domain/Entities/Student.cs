using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class Student
{
    private Student()
    {
        
    }
        
    public Student(Name name, Document document, Email email, Address address)
    {
        Name =name;
        Document = document;
        Email = email;
        Address = address;
    }

    
    public Name Name { get; private set; } = null!;
    public Document Document { get;private set; }= null!;
    public Email Email { get; private set; } = null!;
    private readonly List<Subscription> _subscriptions = [];
    public Address Address { get; private set; } = null!;

    public void AddSubscription(Subscription subscription)
    {
        _subscriptions.ForEach(x=>x.Disable());
        _subscriptions.Add(subscription);
    }

    public IEnumerable<Subscription> GetSubscriptions()
        => _subscriptions;
}