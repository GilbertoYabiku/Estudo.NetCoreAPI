using System;

namespace Services.DTOs
{
    public class UpdatePersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string CivilRegistry { get; set; }
        public string Email { get; set; }
    }
}