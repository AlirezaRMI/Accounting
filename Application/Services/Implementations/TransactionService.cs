using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Enum.Transeation;
using Domain.IRepository;
using Domain.ViewModel.Transaction;

namespace Application.Services.Implementations;

public class TransactionService(IBaseRepository<Transaction> transactionrepository) : ITransactionService
{


    public async Task<AddTransactionResult> AddTransactionAsync(AddTransactionViewModel transaction,string? userId)
    {
        if(userId == null) throw new ArgumentNullException(userId);
        var mineTransaction = new Transaction()
        {
            Description = transaction.Description,
            Price = transaction.Price,
            CreateDate = transaction.Createdate,
            UserId = userId,
            Type = transaction.Type
        };
        await transactionrepository.AddAsync(mineTransaction);
        return AddTransactionResult.Success;
    }

    public async Task<TransactionViewModel?> GetTransactionByIdAsync(string id)
    {
        var transaction= await transactionrepository.GetByIdAsync(id);
       
        if (transaction == null)
            return null;
            
        return new TransactionViewModel
        {
            
            Id = transaction.Id,
            Description = transaction.Description,
            Price = transaction.Price,
            Type = transaction.Type,
            UpdeteDate = DateOnly.FromDateTime(DateTime.Now),
            Createdate = DateOnly.FromDateTime(DateTime.Now)
            
        };
        
    }

    public async Task<MineTransaction> UpdateTransactionAsync(EditeTransactionViewModel model)
    {
        if (model.Id != null)
        {
            var transaction = await transactionrepository.GetByIdAsync(model.Id);
            if (transaction == null)
                return MineTransaction.Unknown;
            transaction.Price = model.Price;
            transaction.Description = model.Description;
            transaction.Status = model.Status;
            transaction.Type = model.Type;
            await transactionrepository.UpdateAsync(transaction);
        }

        return MineTransaction.Success;
    }
    public async Task<List<TransactionViewModel>> GetUserTransactionsAsync(string userId, TransactionStatus? status = null)
    {
        var transactions = await transactionrepository.GetAllAsync();

        return transactions
            .Where(t => t.UserId == userId && (!status.HasValue || t.Status == status))
            .Select(t => new TransactionViewModel(t))
            .ToList();
    }

    public async Task<MineTransaction> DeleteTransactionAsync(string id)
    {
        var transaction = await transactionrepository.GetByIdAsync(id);
        if (transaction == null)
            return MineTransaction.Unknown;
        await transactionrepository.DeleteAsync(transaction);
        return MineTransaction.Success;
    }

    public async Task<MineTransaction> ConfirmTransactionAsync(string id)
    {
        var transaction = await transactionrepository.GetByIdAsync(id);
        if(transaction == null)
            return MineTransaction.Unknown;
        transaction.Status = TransactionStatus.Confirmed;
        await transactionrepository.UpdateAsync(transaction);
        return MineTransaction.Success; 
    }

}