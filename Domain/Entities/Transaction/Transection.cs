using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;
using Domain.Enum.Transeation;

namespace Domain.Entities;

public class Transaction : BaseEntity
{
    public string? Description { get; set; }

    public TransactionStatus Status { get; set; }
    [Required(ErrorMessage = "مبلغ تراکنش نمیتواند خالی باشد")]
    public long Price { get; set; }

    public DateOnly Time { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public bool IsConfirmed { get; set; } = false;
    public TimeOnly CreatTime { get; set; }

    #region Relation

    [ForeignKey(nameof(UserId))]
    public string UserId { get; set; }
    public User? User { get; set; }
    
    [EnumDataType(typeof(TransactionType), ErrorMessage = "نوع تراکنش معتبر نیست")]
    public TransactionType Type { get; set; }

    #endregion
}