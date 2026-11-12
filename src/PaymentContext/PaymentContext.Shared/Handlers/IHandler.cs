using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers;

public interface IHandler<T>  where T : ICommand
{
    Task<IResult> Handle(T command, CancellationToken cancellationToken = default);
}