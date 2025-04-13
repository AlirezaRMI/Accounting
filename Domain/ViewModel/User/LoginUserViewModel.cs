using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModel.User;

public class LoginUserViewModel
{
    [Required] public required string UserName { get; set; }

    [Required] public required string Password { get; set; }

    public bool RememberMe { get; set; }
}