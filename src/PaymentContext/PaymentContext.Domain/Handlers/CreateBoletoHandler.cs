using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class CreateBoletoHandler : Notifiable<Notification>,IHandler<CreateBoletoSubscriptionCommand>
{
    private readonly IStudentRepository _studentRepository;

    public CreateBoletoHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IResult> Handle(CreateBoletoSubscriptionCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
        {
            AddNotifications(command.Notifications);
            return new CommandResult(false, "Não foi possivel continuar com o processo. Dados Invalidos.");
        }

        var student = await _studentRepository.GetByIdAsync(command.UserId, cancellationToken);
        if (student is null)
        {
            AddNotification("CreateBoletoHandler","Student not found");
            return new CommandResult(false,"Student não encontrado! ");
        }

        var address = new Address(command.County, command.State, command.City, command.ZipCode,command.AddressNumber);
        var boletoPayment = new BoletoPayment( DateTime.UtcNow.AddMonths(1), command.Total, command.TotalPaid,
            address, student.Document, command.Payer, student.Email, command.CodeBar,
            command.BoletoNumber);

        var subscription = new Subscription(DateTime.UtcNow.AddMonths(1));
        subscription.AddPayment(boletoPayment);
        
        if (!subscription.IsValid)
        {
            AddNotifications(subscription);
            return new CommandResult(false,
                "Não foi possivel continuar com o processo. Dados Invalidos do metodo de pagamento.");
        }
        
        student.AddSubscription(subscription);
        _studentRepository.Update(student);
        
        return new CommandResult(true,"operação feita com sucesso.");
    }
}