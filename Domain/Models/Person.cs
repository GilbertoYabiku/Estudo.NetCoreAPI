using Core.Models;
using System;

namespace Domain.Models
{
    public class Person : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string CivilRegistry { get; set; }
        public string Email { get; set; }
    }
}