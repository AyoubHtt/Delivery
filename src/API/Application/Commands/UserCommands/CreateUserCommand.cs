using MediatR;

namespace API.Application.Commands.UserCommands;

public record CreateUserCommand(string Email, string PhoneNumlber) : IRequest<bool>;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}

