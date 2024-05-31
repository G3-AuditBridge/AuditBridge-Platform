using AuditBridgePlatform.Profiles.Domain.Model.Aggregates;
using AuditBridgePlatform.Profiles.Domain.Model.Commands;
using AuditBridgePlatform.Profiles.Domain.Repositories;
using AuditBridgePlatform.Profiles.Domain.Services;
using AuditBridgePlatform.Shared.Domain.Repositories;

namespace AuditBridgePlatform.Profiles.Application.Internal.CommandServices;
public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}