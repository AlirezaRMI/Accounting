using System.ComponentModel.DataAnnotations;
using System.Transactions;
using Domain.Entities.Common;
using Domain.Enum.User;

namespace Domain.Entities;

public class User : BaseEntity
{
    [MaxLength(length:50,ErrorMessage = "نام کاربری نمینواند بیش از 50 کاراکتر باشد")]
    public string? UserName { get; set; }
    
    public string? AccountCode { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; }
    public string? Password { get; set; }
    public Status Status { get; set; }

    #region relations

    public ICollection<UserRoles>? UserRoles { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }

    #endregion
}