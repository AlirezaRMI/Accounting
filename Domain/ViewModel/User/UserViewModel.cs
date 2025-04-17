using Domain.Enum.User;

namespace Domain.ViewModel.User;

public class UserViewModel
{
    public UserViewModel(Entities.User user)
    {
        Id = user.Id;
        UserName = user.UserName;
        AccountCode = user.AccountCode;
        Address = user.Address;
        Password = user.Password;
    }
    public string? UserName { get; set; }

    public string? AccountCode { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }
   
    public string? Id { get; set; }
}