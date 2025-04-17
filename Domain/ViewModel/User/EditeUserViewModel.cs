using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModel.User;

public class EditeUserViewModel
{
    public string? Id { get; set; }

    public string? UserName { get; set; }

    public string? Address { get; set; }
    
    [MinLength(10,ErrorMessage = "شماره حساب/کارت معتبر نیست")]
    [MaxLength(16,ErrorMessage = "شماره حساب/کارت معتبر نیست")]
    [Required(ErrorMessage = "ورود شماره حساب/کارت الزامیست")]
    public string? AccountCode { get; set; }

    public EditeUserViewModel(UserViewModel user)
    {
        UserName = user.UserName;
        Address = user.Address;
        AccountCode = user.AccountCode;
        Id = user.Id;
    }

    public EditeUserViewModel()
    {
        
    }

}