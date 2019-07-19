using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CQRS
{
    public abstract class Message
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }
        public Guid AgreggateId { get; set; }
        public string MessageType { get; set; }
        public DateTime DateTimeStamp { get; set; }
    }
}
