using PaymentContext.Domain.Exceptions;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.ValueObjects;

public class EmailTest
{
    private const string AddressValid = "teste@gmail.com";
    private const string AddressInvalidNotArroba = "testegmail";
    private const string AddressInvalidNotInit = "@gmail.com";
    private const string AddressInvalidNotDotWithCom = "teste@gmail";

    [Fact]
    public void Should_Return_True_When_Address_In_Email_Is_Valid()
    {
        var email = new Email(AddressValid);
        Assert.False(email.Notifications.Any());
    }
    
    [Theory]
    [InlineData(AddressInvalidNotArroba)]
    [InlineData(AddressInvalidNotDotWithCom)]
    [InlineData(AddressInvalidNotInit)]
    public void Should_Return_False_When_Address_Is_Invalid(string addressInvalid)
    {
        var email = new Email(addressInvalid);
        Assert.True(email.Notifications.Any());
    }
}