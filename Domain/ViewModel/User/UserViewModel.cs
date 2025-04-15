namespace Domain.ViewModel.User;

public class UserViewModel
{
    public UserViewModel(Entities.User user)
    {
        Id = user.Id;
        UserName = user.UserName;
    }

    public string? UserName { get; set; }
    public string? Id { get; set; }
}