using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.ValueObjects;

public class DocumentTest
{
    private const string Cpf_Valid = "12345678910";
    private const string Cpf_Invalid = "123456789";
    
    private const string Cin_Valid = "12345678910";
    private const string Cin_Invalid = "123456789";
    
    private const string Rg_Valid = "123456789";
    private const string Rg_Invalid = "1234567892";

    [Fact]
    public void Should_return_Valid_When_Cpf_Is_Valid()
    {
        var document = new Document(Cpf_Valid,EDocumentType.Cpf);
        Assert.True(document.IsValid);
        
    }

    [Fact]
    public void Should_return_Error_When_Cpf_Is_Invalid()
    {
        var document = new Document(Cpf_Invalid,EDocumentType.Cpf);
        Assert.False(document.IsValid);    
    }
    [Fact]
    public void Should_return_Valid_When_Cin_Is_Valid()
    {
        var document = new Document(Cin_Valid,EDocumentType.Cin);
        Assert.True(document.IsValid);
    }

    [Fact]
    public void Should_return_Error_When_Cin_Is_Invalid()
    {
        var document = new Document(Cin_Invalid,EDocumentType.Cin);
        Assert.False(document.IsValid);
    }

    [Fact]
    public void Should_return_Valid_When_Rg_Is_Valid()
    {
        var document = new Document(Rg_Valid,EDocumentType.Rg);
        Assert.True(document.IsValid);
    }
    
    [Fact]
    public void Should_return_Error_When_Rg_Is_Invalid()
    {
        var document = new Document(Rg_Invalid,EDocumentType.Rg);
        Assert.False(document.IsValid);
    }
}