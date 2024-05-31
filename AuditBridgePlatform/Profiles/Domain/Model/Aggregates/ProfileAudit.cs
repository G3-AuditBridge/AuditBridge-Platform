using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using Microsoft.EntityFrameworkCore.Internal;

namespace AuditBridgePlatform.Profiles.Domain.Model.Aggregates;

public partial class Profile : IEntityWithCreatedUpdatedDate
{
    [Column("Created at")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("Updated at")] public DateTimeOffset? UpdatedDate { get; set; }
}