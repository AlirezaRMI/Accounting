using Domain.Entities.Common;
using Domain.Enum.Transeation;

namespace Domain.Entities;

public class Transaction : BaseEntity
{
    public string? Description { get; set; }

    public long Price { get; set; }

    public DateTime Time { get; set; } = DateTime.UtcNow;

    #region Relation

    public User? User { get; set; }
    public TransactionType Type { get; set; }

    #endregion
}