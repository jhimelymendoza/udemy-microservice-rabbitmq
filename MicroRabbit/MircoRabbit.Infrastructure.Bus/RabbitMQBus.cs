using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Events;

namespace MircoRabbit.Infrastructure.Bus
{
   public sealed class RabbitMQBus : IEventBus
   { 

       private readonly IMediator _mediator;
       public Task SendCommand<T>(T command) where T : Command
       {
           return _mediator.Send( command);
       }

       public void Publish<T>(T @event) where T : Event
       {
           throw new NotImplementedException();
       }

       public void Susbscribe<T, TH>() where T : Event where TH : IEventHandler<T>
       {
           throw new NotImplementedException();
       }
   }
}
 
