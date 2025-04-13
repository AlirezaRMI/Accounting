using Application.Services.Interfaces;
using Domain.Entities;
using Domain.IRepository;
using Domain.ViewModel.Transaction;

namespace Application.Services.Implementations;

public class TransactionService(IBaseRepository<Transaction> transactionRepository) : ITransactionService
{
    public async Task<ICollection<TransactionViewModel>> GetTransactionsAsync()
    {
        IReadOnlyCollection<Transaction> transactions = await transactionRepository.GetAllAsync();

        return transactions.Select(x => new TransactionViewModel()
        {
            Type = x.Type,
            CreateDate = x.CreateDate,
            Description = x.Description,
            Price = x.Price,
        }).ToList();
        // return transactions.Select(x=> new TransactionViewModel(x)).ToList();
    }
}