using System.ComponentModel.DataAnnotations;
using Domain.Enum.Transeation;

namespace Domain.ViewModel.Transaction;

public class EditeTransactionViewModel
{
    [Required(ErrorMessage = "مبلغ تراکنش نمی تواند خالی باشد")]
    public long Price { get; set; }

    [Required(ErrorMessage = "نوع تراکنش را مشخص کنید")]
    public TransactionType Type { get; set; }

    public DateOnly Createdate { get; set; }=DateOnly.FromDateTime(DateTime.Now);

    public TransactionStatus Status { get; set; }
    public string? Id { get; set; }
    public string? Description { get; set; }
}