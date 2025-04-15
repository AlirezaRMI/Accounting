using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class AlirezaStepOneDbContext : DbContext
{
    public AlirezaStepOneDbContext(DbContextOptions<AlirezaStepOneDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }
    DbSet<User> Users { get; set; }
}