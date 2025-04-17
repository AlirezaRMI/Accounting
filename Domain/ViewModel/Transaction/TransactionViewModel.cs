using System.ComponentModel.DataAnnotations;
using Domain.Enum.Transeation;

namespace Domain.ViewModel.Transaction;

public class TransactionViewModel
{
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "مبلغ تراکنش نمی تواند خالی باشد")]
    public long Price { get; set; }

    public DateOnly Createdate { get; set; }
    public TimeOnly CreatTime { get; set; }
    public DateOnly UpdeteDate { get; set; }
    
    [Required(ErrorMessage = "نوع تراکنش نمی تواند خالی باشد")]
    public  TransactionType Type { get; set; }

    public long? TotalPrice { get; set; }
    public string? Id { get; set; }
    
    public bool IsConfirmed { get; set; }
    public string? UserId { get; set; }
    
    public TransactionViewModel()
    {
        
    }

    public TransactionViewModel(Entities.Transaction transaction)
    {
        IsConfirmed = transaction.IsConfirmed;
        UserId = transaction.UserId;
        Description = transaction.Description;
        Price = transaction.Price;
        Createdate = transaction.CreateDate;
        CreatTime = transaction.CreatTime;
        Type = transaction.Type;
        UpdeteDate = (DateOnly)transaction.UpdateDate!;
        Id = transaction.Id;
    }
    
}