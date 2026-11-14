using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using static PaymentContext.Domain.Queries.StudentQuery;

namespace PaymentContext.Test.Queries;

public class StudentQueryTest
{
    private static Student _student =   new (new Name("teste", "teste"), new Document("23053100053", EDocumentType.Cpf), new Email("kaiky@gmail.com"),
        new Address("brazil", "sp", "mogi ", "120", 02));

    private readonly List<Student> _list;

    public StudentQueryTest()
    {
        _list =[];
        _list.Add(_student);
    }

    [Fact]
    public void Should_Return_Student_When_Id_Is_valid()
    {
        var result = _list.FirstOrDefault(GetById(_student.Id).Compile());
        Assert.NotNull(result);
    }
    [Fact]
    public void Should_Return_Null_When_Id_Is_Invalid()
    {
        var randomId = Guid.NewGuid();
        var result = _list.FirstOrDefault(GetById(randomId).Compile());
        Assert.Null(result);
    }
    
    [Fact]
    public void Should_Return_Student_When_Document_Is_valid()
    {
        var result = _list.FirstOrDefault(GetByDocument("23053100053").Compile());
        Assert.NotNull(result);
    }
    [Fact]
    public void Should_Return_Null_When_Document_Is_Invalid()
    {
        var result = _list.FirstOrDefault(GetByDocument("13153100053").Compile());
        Assert.Null(result);
    }
}