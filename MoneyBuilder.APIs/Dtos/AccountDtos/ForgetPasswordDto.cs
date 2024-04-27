namespace MoneyBuilder.APIs.Dtos.AccountDtos;

public class ForgetPasswordDto
{
    [EmailAddress]
    public string Email { get; set; }
}
