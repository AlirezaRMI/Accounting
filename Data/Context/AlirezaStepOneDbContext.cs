using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class AccountingContext : DbContext
{
    public AccountingContext(DbContextOptions<AccountingContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }
    DbSet<User> Users { get; set; }
}