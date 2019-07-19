using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CQRS
{
    public interface IHandler<T> where T : Message
    {
        void Handle(T Message);
    }
}
