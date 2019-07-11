using Services.DTOs;

namespace Services.Services.Interfaces
{
    public interface IServicePost<T>
    {
        void Save(T model);
    }
}