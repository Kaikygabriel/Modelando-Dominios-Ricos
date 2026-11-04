namespace PaymentContext.Domain.Entities;

public class Subscription
{
    
    private  Subscription()
    {
        
    }
    public Subscription( DateTime? expired)
    {
        CreateAt = DateTime.UtcNow;
        LastUpdateDate = DateTime.UtcNow;
        Expired = expired;
        IsActive = true;
    }

    public DateTime CreateAt { get; private init; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? Expired { get;private set; }
    public bool IsActive { get;private set; }
    private readonly List<Payment> _payments = [];

    public void AddPayment(Payment payment)
    {
        _payments.Add(payment);
    }

    public IEnumerable<Payment> GetPayments()
        => _payments;

    public void Active()
    {
        IsActive = true;
        LastUpdateDate = DateTime.UtcNow;
    } 
    
    public void Disable()
    {
        IsActive = false;
        LastUpdateDate = DateTime.UtcNow;
    } 
    
}