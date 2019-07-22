
namespace Core.CQRS
{
    public interface IHandler<T> where T : Message
    {
        void Handle(T Message);
    }
}
