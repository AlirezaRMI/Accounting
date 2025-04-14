using Domain.Enum.Transeation;
using Domain.ViewModel.Transaction;

namespace Application.Services.Interfaces;

public interface ITransactionService
{
    /// <summary>
    /// get All Transaction
    /// </summary>
    /// <returns>list<Trancaction></returns>
    Task<List<TransactionViewModel>> GetTransactionsAsync();
    
    
    /// <summary>
    /// add Transaction
    /// </summary>
    /// <param name="transaction"></param>
    /// <returns></returns>
    Task<AddTransactionResult> AddTransactionAsync(AddTransactionViewModel transaction);
    
    
    /// <summary>
    /// Delete TransactionbyId
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<MineTransaction> DeleteTransactionAsync(string id);
}