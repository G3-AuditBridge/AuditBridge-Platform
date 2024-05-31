using AuditBridgePlatform.Profiles.Domain.Model.Commands;
using AuditBridgePlatform.Profiles.Domain.Model.Queries;
using AuditBridgePlatform.Profiles.Domain.Model.ValueObjects;
using AuditBridgePlatform.Profiles.Domain.Services;

namespace AuditBridgePlatform.Profiles.Interfaces.ACL.Services;

/**
 * Profile context facade.
 *
 * <summary>
 * This class represents the profiles anti-corruption layer.
 * It contains the methods for Inbound Communication.
 * </summary>
 */

public class ProfilesContextFacade(
 IProfileCommandService profileCommandService,
 IProfileQueryService profileQueryService) : IProfilesContextFacade
{
 public async Task<int> CreateProfile(string firstName, string lastName, string email, string street, string number, string city, string postalCode, string country)
 {
  var createProfileCommand = new CreateProfileCommand(firstName, lastName, email, street, number, city, postalCode, country);
  var profile = await profileCommandService.Handle(createProfileCommand);
  return profile?.Id ?? 0;
 }
 
 public async Task<int> FetchProfileIdByEmail(string email)
 {
  var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
  var profile = await profileQueryService.Handle(getProfileByEmailQuery);
  return profile?.Id ?? 0;
 }
}
