using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class AlirezaStepOneDbContext : DbContext
{
    public AlirezaStepOneDbContext(DbContextOptions<AlirezaStepOneDbContext> options)
        : base(options)
    {
    }
    
    DbSet<User> Users { get; set; }
}