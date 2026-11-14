using PaymentContext.Domain.Services;

namespace PaymentContext.Test.Mocks;

public class FakeEmailService : IEmailService
{
    public async Task Send(string to, string email, string title, string subject, string body)
    {
        await Task.Delay(0);
    }
}