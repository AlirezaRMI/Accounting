using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModel.User;

public class AddUserViewModel
{
    [Required (ErrorMessage = "ورود نام کاربری الزامیست")]
    [MaxLength(100,ErrorMessage = "نام کاربری طولانی است")]
    [MinLength(5,ErrorMessage = "نام کاربری کوتاه است")]
    public string? UserName { get; set; }
        
    [Required (ErrorMessage = "ورود رمز عبور الزامیست")]
    [MinLength(5,ErrorMessage = "کلمه عبور کوتاه است")]
    [MaxLength(100,ErrorMessage = "کلمه عبور طولانی است")]
    public string? Password { get; set; }

    [Compare("Password",ErrorMessage = "کلمه عبور با تکرار آن مغایرت دارد")]
    public string? RePassword { get; set; }
        
    [MinLength(10,ErrorMessage = "شماره حساب/کارت معتبر نیست")]
    [MaxLength(16,ErrorMessage = "شماره حساب/کارت معتبر نیست")]
    [Required(ErrorMessage = "ورود شماره حساب/کارت الزامیست")]
    public string? AccountCode { get; set; }

    [MaxLength(700, ErrorMessage = "آدرس وارد شده طولانی است.")]
    public string? Address { get; set; }

    public AddUserViewModel()
    {
          
    }

    public Entities.User GenerateUser() => new()
    {
        UserName = UserName
    };

}