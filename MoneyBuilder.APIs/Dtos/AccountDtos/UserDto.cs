namespace MoneyBuilder.APIs.Dtos.AccountDtos;

public class UserDto
{
    public string UserName { get; set; }

    public string Email { get; set; }

    public UserProgress UserProgress { get; set; }

    public string Token { get; set; }

    public List<string>? Roles { get; set; } = new();


}
