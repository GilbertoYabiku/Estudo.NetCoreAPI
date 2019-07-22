
namespace Core.CQRS
{
    public interface IBus
    {
        void SendCommand<T>(T command) where T : Command;
        void SendEvent<T>(T @event) where T : Event;
    }
}