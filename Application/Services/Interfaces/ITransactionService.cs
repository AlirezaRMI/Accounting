using Domain.ViewModel.Transaction;

namespace Application.Services.Interfaces;

public interface ITransactionService
{
    Task<ICollection<TransactionViewModel>> GetTransactionsAsync();
}