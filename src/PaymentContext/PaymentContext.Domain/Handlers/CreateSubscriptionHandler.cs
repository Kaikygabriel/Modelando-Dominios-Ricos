using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Commands.Subscriptions;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class CreateSubscriptionHandler : Notifiable<Notification>,
    IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreateCreditCardSubscriptionCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IEmailService _emailService;
    public CreateSubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
    {
        _studentRepository = studentRepository;
        _emailService = emailService;
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
        AddNotifications(student.Notifications);
        if (!IsValid)
            return new CommandResult(false,
                "Não foi possivel continuar com o processo. Erro ao adicionar subscription ao student.");

        
        _studentRepository.Update(student);

        await _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem Vindo!",
            "Menssagem de Boas Vindas", $"Seja bem vindo {student.Name}");
        
        return new CommandResult(true,"operação feita com sucesso.");
    }

    public async Task<IResult> Handle(CreateCreditCardSubscriptionCommand command, CancellationToken cancellationToken = default)
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
        var boletoPayment = new CreditCardPayment( DateTime.UtcNow.AddMonths(1), command.Total, command.TotalPaid,
            address, student.Document, command.Payer, student.Email, command.CardName,
            command.CardNumber,command.LastTransactionNumber);

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

        await _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem Vindo!",
            "Menssagem de Boas Vindas", $"Seja bem vindo {student.Name}");
        
        return new CommandResult(true,"operação feita com sucesso.");
    }
}