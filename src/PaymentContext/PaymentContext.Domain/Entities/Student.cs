using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    private Student()
    {
        
    }
        
    public Student(Name name, Document document, Email email, Address address)
    {
        AddNotifications(name,document,email,address);
        
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
        foreach(var sub in _subscriptions)
          if(sub.IsActive)
          {
              AddNotification("Student.Subscription", "Already exists one subscription active !");
              break;
          }
        
        _subscriptions.Add(subscription);
    }

    public IEnumerable<Subscription> GetSubscriptions()
        => _subscriptions;
}