using AuditBridgePlatform.Profiles.Domain.Model.Commands;
using AuditBridgePlatform.Profiles.Domain.Model.ValueObjects;

namespace AuditBridgePlatform.Profiles.Domain.Model.Aggregates;

/**
 * Profile Aggregate root entity
 *
 * <p>
 *This class reprresents the Profile aggregate root entity. It contains properties and methods to manage the profile
 * </p>
 */
public partial class Profile
{
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public StreetAddress Address { get; private set; }

    public string FullName => Name.FullName;

    public string EmailAddress => Email.Address;

    public string StreetAddress => Address.FullAddress;
    
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
    }

    public Profile(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, number, city, postalCode, country);
    }
    
    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Address = new StreetAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);
    }
}