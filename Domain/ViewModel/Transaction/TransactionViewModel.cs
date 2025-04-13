using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Domain.Enum.Transeation;

namespace Domain.ViewModel.Transaction;

public class TransactionViewModel
{
    [Display(Name = "شرح تراکنش")] public string? Description { get; set; }

    [Required] public long Price { get; set; }

    public DateOnly CreateDate { get; set; }

    public TransactionType Type { get; set; }
}


// public class TransactionViewModel(Entities.Transaction transaction)
// {
//     [Display(Name = "شرح تراکنش")] public string? Description { get; set; } = transaction.Description;
//
//     [Required] public long Price { get; set; } = transaction.Price;
//
//     public DateOnly CreateDate { get; set; } = transaction.CreateDate;
//
//     public TransactionType Type { get; set; } = transaction.Type;
// }