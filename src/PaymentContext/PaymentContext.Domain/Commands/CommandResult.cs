using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CommandResult : IResult
{
    public CommandResult()
    {
        IsSuccess = true;
    }
    
    public CommandResult(bool result,string message)
    {
        Message = message;
        IsSuccess = result;
    }

    public bool  IsSuccess { get;private init; }
    public string Message { get;private init; }
}