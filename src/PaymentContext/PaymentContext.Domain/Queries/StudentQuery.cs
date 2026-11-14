using System.Linq.Expressions;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Queries;

public static class StudentQuery
{
    public static Expression<Func<Student,bool>> GetByDocument(string document)
         => x=>x.Document.Number.Equals(document);
    
    public static Expression<Func<Student,bool>> GetById(Guid id)
        => x=>x.Id.Equals(id);
}