using Domain.Enum.Transeation;

namespace Domain.ViewModel.Transaction;

public class TransactionViewModel
{
    public string? Description { get; set; }
    
    public long Price { get; set; }

    public DateOnly Createdate { get; set; }=DateOnly.FromDateTime(DateTime.Now);

    public TransactionType Type { get; set; }

    public string Id { get; set; }
    
    public TransactionViewModel()
    {
        
    }

    public TransactionViewModel(Entities.Transaction transaction)
    {
        Description = transaction.Description;
        Price = transaction.Price;
        Createdate = transaction.CreateDate;
        Type = transaction.Type;
        Id = transaction.Id;
    }
    
}