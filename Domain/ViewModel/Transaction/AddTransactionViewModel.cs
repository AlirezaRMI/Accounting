using System.ComponentModel.DataAnnotations;
using System.Runtime;
using Domain.Enum.Transeation;

namespace Domain.ViewModel.Transaction;

public class AddTransactionViewModel
{
    [Required(ErrorMessage = "مبلغ تراکنش نمی تواند خالی باشد")]
    public long Price { get; set; }

    public TransactionType Type { get; set; }

    public DateOnly Createdate { get; set; }=DateOnly.FromDateTime(DateTime.Now);

    public string? Description { get; set; }
    
}