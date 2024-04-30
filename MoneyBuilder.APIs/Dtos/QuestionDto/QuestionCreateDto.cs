
namespace MoneyBuilder.APIs.Dtos.QuestionDto;

public class QuestionCreateDto
{
    public string Description { get; set; }

    [Required]
    public int LectureId { get; set; }

    public List<AnswerCreateDto>? Answers { get; set; } = new();
}
