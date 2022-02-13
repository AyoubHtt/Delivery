using API.Application.Behaviors;
using API.Application.Commands.UserCommands;
using API.Application.Validations.UserCommandsValidation;
using Autofac;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace API.Infrastructure.AutofacModules;

public class MediatorModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

        // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
        builder.RegisterAssemblyTypes(typeof(CreateUserCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));

        // Register the Command's Validators (Validators based on FluentValidation library)
        builder
            .RegisterAssemblyTypes(typeof(CreateUserCommandValidator).GetTypeInfo().Assembly)
            .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            .AsImplementedInterfaces();

        builder.Register<ServiceFactory>(context =>
        {
            var componentContext = context.Resolve<IComponentContext>();

            return t => { return componentContext.TryResolve(t, out object? o) ? o : throw new InvalidOperationException(); };
        });

        builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    }
}
