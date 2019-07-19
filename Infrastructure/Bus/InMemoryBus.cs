using Core.CQRS;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Bus
{
    public class InMemoryBus : IBus
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InMemoryBus(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SendCommand<T>(T command) where T : Command
        {
            Publish(command);
        }

        public void SendEvent<T>(T @event) where T : Event
        {
            Publish(@event);
        }

        private void Publish<T>(T message) where T : Message
        {
            var serviceProvider = _httpContextAccessor.HttpContext.RequestServices;

            var handler = serviceProvider.GetService(typeof(IHandler<T>));

            ((IHandler<T>)handler).Handle(message);
        }
    }
}
