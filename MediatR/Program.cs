using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using JetBrains.Annotations;
using MediatR;

namespace MediatRProj
{
    // ping command and send it
    // pong response

    public class PingCommand : IRequest<PongResponse>
    {

    }
    
    public class PongResponse
    {
        public DateTime Timestamp;

        public PongResponse(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
    }

    [UsedImplicitly]
    public class PingCommandHandler : IRequestHandler<PingCommand, PongResponse>
    {
        public async Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new PongResponse(DateTime.UtcNow))
                .ConfigureAwait(false);
        }
    }

    class Program
    {
        public static async Task Main(string[] args)
        {
            // MediatR

            var builder = new ContainerBuilder();
            
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            // request all req response
            // resolve mediator and send commands

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsImplementedInterfaces();

            var container = builder.Build();
            var mediator = container.Resolve<IMediator>();

            var response = await mediator.Send(new PingCommand());

            Console.WriteLine($"We got a response at { response.Timestamp }");
        }
    }
}
