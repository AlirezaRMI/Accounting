using Domain.Enum.Transeation;
using Domain.ViewModel.Transaction;

namespace Application.Services.Interfaces;

public interface ITransactionService
{
    /// <summary>
    /// get All Transaction
    /// </summary>
    /// <returns>list<Trancaction></returns>



    /// <summary>
    /// add Transaction
    /// </summary>
    /// <param name="transaction"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    
    Task<int> GetUserTransactionsCountAsync(string userId);
    Task<List<TransactionViewModel>> GetUserTransactionsPagingAsync(string userId, int page, int pageSize);
    Task<AddTransactionResult> AddTransactionAsync(AddTransactionViewModel transaction,string? userId);
    Task<List<TransactionViewModel>> GetUserTransactionsAsync(string userId, TransactionStatus? status = null);
    Task<TransactionViewModel?> GetTransactionByIdAsync(string id);
    Task<MineTransaction> UpdateTransactionAsync(EditeTransactionViewModel model);
    
    /// <summary>
    /// Delete TransactionbyId
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<MineTransaction> DeleteTransactionAsync(string id);
    
    Task<MineTransaction> ConfirmTransactionAsync(string id);
}