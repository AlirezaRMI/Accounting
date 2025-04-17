using Domain.Entities;
using Domain.Enum.User;
using Domain.ViewModel.User;

namespace Application.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// added user by admin
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task AddUserAsync(AddUserViewModel user);
    
    /// <summary>
    /// register user when auth
    /// </summary>
    /// <param name="register"></param>
    /// <returns></returns>
    Task<RegisterResult> RegisterUserAsync(RegisterViewModel register);
    
    /// <summary>
    /// login user when auth    
    /// </summary>
    /// <param name="login"></param>
    /// <returns>Tuple(LoginResult,UserViewModel?)</returns>
    Task<(LoginResult,UserViewModel?)> LoginUserAsync(LoginUserViewModel login);
    Task<UserViewModel?> GetUserByUsernameAsync(string username);
    
    Task<EditeResult> EditeUserAsync(EditeUserViewModel user);
    Task<long> GetUserBalanceAsync(string id);
}