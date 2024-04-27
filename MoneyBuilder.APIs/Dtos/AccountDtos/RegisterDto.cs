namespace MoneyBuilder.APIs.Dtos.AccountDtos;

public class RegisterDto
{
    [MinLength(3, ErrorMessage = "The UserName must be at least 3 characters long.")]
    [MaxLength(100, ErrorMessage = "The UserName must be less than 100 characters long.")]
    public string UserName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Password { get; set; }
}
