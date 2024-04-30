namespace MoneyBuilder.APIs.Dtos.QuestionDto;

public class QuestionUpdateDto
{
    public string Description { get; set; }

    public List<AnswerCreateDto>? Answers { get; set; } = new();
}
