using Core.CQRS;

namespace Domain.Commands
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand(string name, string lastName, string birthdate, string civilRegistry, string email)
        {
            Name = name;
            LastName = lastName;
            Birthdate = birthdate;
            CivilRegistry = civilRegistry;
            Email = email;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public string CivilRegistry { get; set; }
        public string Email { get; set; }
    }
}