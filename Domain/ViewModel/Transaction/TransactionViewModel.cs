using System.ComponentModel.DataAnnotations;
using Domain.Enum.Transeation;

namespace Domain.ViewModel.Transaction;

public class TransactionViewModel
{
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "مبلغ تراکنش نمی تواند خالی باشد")]
    public long Price { get; set; }

    public DateOnly Createdate { get; set; }=DateOnly.FromDateTime(DateTime.Now);

    public DateOnly UpdeteDate { get; set; }
    [Required(ErrorMessage = "نوع تراکنش نمی تواند خالی باشد")]
    public TransactionType Type { get; set; }

    public long? TotalPrice { get; set; }
    public string? Id { get; set; }
    
    public string? UserId { get; set; }
    
    public TransactionViewModel()
    {
        
    }

    public TransactionViewModel(Entities.Transaction transaction)
    {
        
        UserId = transaction.UserId;
        Description = transaction.Description;
        Price = transaction.Price;
        Createdate = transaction.CreateDate;
        Type = transaction.Type;
        UpdeteDate = (DateOnly)transaction.UpdateDate!;
        Id = transaction.Id;
    }
    
}