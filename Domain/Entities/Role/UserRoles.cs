using Domain.Entities.Common;

namespace Domain.Entities;

public class UserRoles : BaseEntity
{
    public long UserId { get; set; }
    public long RoleId { get; set; }

    #region Relation

    public Role Role { get; set; }
    public User User { get; set; }
    #endregion
}