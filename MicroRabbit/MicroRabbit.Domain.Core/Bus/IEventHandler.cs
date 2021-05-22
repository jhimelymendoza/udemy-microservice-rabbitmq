using System;
using System.Collections.Generic;
using System.Text;
using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
    }

    public interface IEventHandler
    {
    }
}
