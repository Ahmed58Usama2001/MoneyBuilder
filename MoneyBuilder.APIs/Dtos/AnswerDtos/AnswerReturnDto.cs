namespace MoneyBuilder.APIs.Dtos.AnswerDtos;

public class AnswerReturnDto
{
    public int Id { get; set; }

    public string Description { get; set; }

    public bool IsRight { get; set; }

    public string? Explaination { get; set; }
}
