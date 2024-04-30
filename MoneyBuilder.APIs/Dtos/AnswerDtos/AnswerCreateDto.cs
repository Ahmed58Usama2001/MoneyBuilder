namespace MoneyBuilder.APIs.Dtos.AnswerDtos;

public class AnswerCreateDto
{
    public string Description { get; set; }

    public bool IsRight { get; set; }

    public string? Explaination { get; set; }
}
