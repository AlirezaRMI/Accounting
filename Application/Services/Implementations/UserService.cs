using Application.Helpers;
using Application.Services.Interfaces;
using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Enum.Transeation;
using Domain.Enum.User;
using Domain.IRepository;
using Domain.ViewModel.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services.Implementations;

public class UserService(IBaseRepository<User> userRepository, ILogger<UserService> logger,AlirezaStepOneDbContext context) : IUserService
{
    public async Task AddUserAsync(AddUserViewModel user)
    {
        await userRepository.AddAsync(user.GenerateUser());
    }

    public async Task<RegisterResult> RegisterUserAsync(RegisterViewModel register)
    {
        try
        {
            if (await GetUserByUsernameAsync(register.UserName) is not null)
                return RegisterResult.UserAlreadyExists;

            User mainUser = new User()
            {
                UserName = register.UserName,
                Address = register.Address,
                Password = PasswordHash.EncodePasswordMd5(register.Password),
                Status = Status.Active,
                IsActive = false,
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                AccountCode = register.AccountCode,
            };

            await userRepository.AddAsync(mainUser);
            return RegisterResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return RegisterResult.Error;
        }
    }

    public async Task<(LoginResult, UserViewModel?)> LoginUserAsync(LoginUserViewModel login)
    {
        try
        {
            var user = await userRepository.GetQueryable().SingleOrDefaultAsync(x => x.UserName == login.UserName);
            if (user is null || user.Password != PasswordHash.EncodePasswordMd5(login.Password))
                return (LoginResult.NotFound, null);

            if (user.Status != Status.Active)
                return (LoginResult.NotActive, null);

            return (LoginResult.Success, new(user));
        }
        catch (Exception e)
        {
            logger.LogError($"when user by user name {login.UserName} occurred error :" + e.Message);
            return (LoginResult.Error, null);
        }
    }

    public async Task<UserViewModel?> GetUserByUsernameAsync(string username)
    {
        var user = await userRepository.GetQueryable().SingleOrDefaultAsync(x => x.UserName == username.Trim());
        return user switch
        {
            null => null,
            _ => new(user)
        };
    }

    public async Task<long> GetUserBalanceAsync(string id)
    {
        var increase = await context.Transactions
            .Where(t => t.UserId == id && t.Type == TransactionType.Increase)
            .SumAsync(t => t.Price);

        var decrease = await context.Transactions
            .Where(t => t.UserId == id && t.Type == TransactionType.Decrease)
            .SumAsync(t => t.Price);

        return increase - decrease;
    }

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByAccountCode(string accountCode)
    {
        throw new NotImplementedException();
    }
}