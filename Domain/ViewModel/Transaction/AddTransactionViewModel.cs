using System.ComponentModel.DataAnnotations;
using System.Runtime;
using Domain.Entities;
using Domain.Enum.Transeation;

namespace Domain.ViewModel.Transaction;

public class AddTransactionViewModel
{
    [Required(ErrorMessage = "مبلغ تراکنش نمی تواند خالی باشد")]
    public long Price { get; set; }
    [Required(ErrorMessage = "نوع تراکنش نمی تواند خالی باشد")]
    public TransactionType Type { get; set; }

    public bool IsConfirmed { get; set; } = false;
    public TimeOnly CreatTime { get; set; }=TimeOnly.FromDateTime(DateTime.Now);
    public DateOnly Createdate { get; set; }=DateOnly.FromDateTime(DateTime.Now);

    public string? Description { get; set; }
    
}