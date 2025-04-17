using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModel.User;

public class LoginUserViewModel
{
    [Required(ErrorMessage = "نام کاربری را وارد کنید")] public required string UserName { get; set; }

    [Required(ErrorMessage = "رمز عبور را وارد کنید")] public required string Password { get; set; }

    public bool RememberMe { get; set; }
}