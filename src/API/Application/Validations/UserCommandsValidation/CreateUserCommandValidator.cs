﻿using API.Application.Commands.UserCommands;
using FluentValidation;

namespace API.Application.Validations.UserCommandsValidation;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(command => command.Email).EmailAddress();
        RuleFor(command => command.PhoneNumlber).Matches(@"^(\+[0-9]{9})$");
    }
}
