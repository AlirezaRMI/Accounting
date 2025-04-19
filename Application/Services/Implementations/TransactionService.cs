using Application.Services.Interfaces;
using Data.Context;
using Domain.Entities;
using Domain.Enum.Transeation;
using Domain.IRepository;
using Domain.ViewModel.Transaction;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementations;

public class TransactionService(IBaseRepository<Transaction> transactionrepository, AccountingContext context)
    : ITransactionService
{
    public async Task<AddTransactionResult> AddTransactionAsync(AddTransactionViewModel transaction, string? userId)
    {
        if (userId == null) throw new ArgumentNullException(nameof(userId));

        var now = DateTime.Now;

        var mineTransaction = new Transaction()
        {
            CreatTime = TimeOnly.FromDateTime(now),
            CreateDate = DateOnly.FromDateTime(now),
            Description = transaction.Description,
            Price = transaction.Price,
            UserId = userId,
            Type = transaction.Type
        };

        await transactionrepository.AddAsync(mineTransaction);
        return AddTransactionResult.Success;
    }


    public async Task<TransactionViewModel?> GetTransactionByIdAsync(string id)
    {
        var transaction = await transactionrepository.GetByIdAsync(id);

        if (transaction == null)
            return null;

        return new TransactionViewModel
        {
            Id = transaction.Id,
            Description = transaction.Description,
            Price = transaction.Price,
            Type = transaction.Type,
            UpdeteDate = DateOnly.FromDateTime(DateTime.Now),
            Createdate = DateOnly.FromDateTime(DateTime.Now),
            CreatTime = TimeOnly.FromDateTime(DateTime.Now),
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
            transaction.CreatTime = model.CreatTime;
            await transactionrepository.UpdateAsync(transaction);
        }

        return MineTransaction.Success;
    }

    public async Task<List<TransactionViewModel>> GetUserTransactionsAsync(string userId,
        TransactionStatus? status = null)
    {
        var transactions = await transactionrepository.GetAllAsync();

        return transactions
            .Where(t => t.UserId == userId && (!status.HasValue || t.Status == status))
            .OrderByDescending(t => t.CreateDate)
            .ThenByDescending(t => t.CreatTime)
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
        if (transaction == null)
            return MineTransaction.Unknown;
        transaction.IsConfirmed = true;
        transaction.Status = TransactionStatus.Confirmed;
        await transactionrepository.UpdateAsync(transaction);
        return MineTransaction.Success;
    }

    public async Task<List<TransactionViewModel>> GetUserTransactionsPagingAsync(string userId, int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;

        var transactions = await transactionrepository.GetUserTransactionsPagingAsync(userId, skip, pageSize);

        return transactions
            .Select(t => new TransactionViewModel(t))
            .ToList();
    }

    public async Task<int> GetUserTransactionsCountAsync(string userId)
    {
        return await transactionrepository.GetUserTransactionsCountAsync(userId);
    }
}