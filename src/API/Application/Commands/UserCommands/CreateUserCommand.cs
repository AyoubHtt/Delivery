using MediatR;
using Microsoft.AspNetCore.Identity;

namespace API.Application.Commands.UserCommands;

public record CreateUserCommand(string Email, string PhoneNumlber) : IRequest<bool>;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly SignInManager<IdentityUser<Guid>> _signInManager;

    public CreateUserCommandHandler(UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}

