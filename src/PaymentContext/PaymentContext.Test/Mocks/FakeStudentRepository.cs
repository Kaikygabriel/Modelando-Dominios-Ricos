using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.Mocks;

public class FakeStudentRepository : IStudentRepository
{
    public bool EmailIsValid(string email)
    {
        if (string.IsNullOrEmpty(email) || email.Equals("hello@gmai..com"))
            return false;

        return true;
    }

    public bool DocumentIsValid(string document)
    {
        if (string.IsNullOrEmpty(document) || document.Length == 9)
            return false;

        return true;
    }

    public void Create(Student student)
    {
        
    }

    public void Update(Student student)
    {
        
    }

    public async Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (Guid.Parse("ecefb01c-c7b2-49cd-8780-92018ead1460").Equals(id))
        {
            return new Student(new Name("teste","teste"),new Document("23053100053",EDocumentType.Cpf),new Email("kaiky@gmail.com"),new Address("brazil","sp","mogi ","74693-105",02));
        }

        return null; 
    }
}