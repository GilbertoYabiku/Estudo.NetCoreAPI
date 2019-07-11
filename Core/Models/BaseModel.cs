using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreationDate { get; set; }
    }
}