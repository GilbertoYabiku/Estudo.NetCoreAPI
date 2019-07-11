using System;

namespace Services.DTOs
{
    public class PersonDTOPost
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public string CivilRegistry { get; set; }
        public string Email { get; set; }
    }
}