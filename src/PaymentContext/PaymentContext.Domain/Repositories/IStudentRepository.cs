using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories;

public interface IStudentRepository
{
    bool EmailIsValid(string email);
    bool DocumentIsValid(string document);
    void Create(Student student);
    void Update(Student student);
    Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}