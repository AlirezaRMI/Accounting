using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Enum.Transeation;
using Domain.IRepository;
using Domain.ViewModel.Transaction;

namespace Application.Services.Implementations;

public class TransactionService(IBaseRepository<Transaction> transactionrepository) : ITransactionService
{
    public async Task<List<TransactionViewModel>> GetTransactionsAsync()
    {
        var transactions = await transactionrepository.GetAllAsync();
        return transactions.Select(x => new TransactionViewModel(x)).ToList();
    }

    public async Task<AddTransactionResult> AddTransactionAsync(AddTransactionViewModel transaction)
    {
        var mineTransaction = new Transaction()
        {
            Description = transaction.Description,
            Price = transaction.Price,
            CreateDate = transaction.Createdate,
            Type = transaction.Type
        };
        await transactionrepository.AddAsync(mineTransaction);
        return AddTransactionResult.Success;
    }

    public async Task<MineTransaction> DeleteTransactionAsync(string id)
    {
        var transaction = await transactionrepository.GetByIdAsync(id);
        if (transaction == null)
            return MineTransaction.Unknown;
        
        await transactionrepository.DeleteAsync(transaction);
        return MineTransaction.Success;
    }
}