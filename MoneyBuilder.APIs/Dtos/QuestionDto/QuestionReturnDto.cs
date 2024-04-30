namespace MoneyBuilder.APIs.Dtos.QuestionDto;

public class QuestionReturnDto
{
    public int Id { get; set; }
    public string Description { get; set; }

    public int LectureId { get; set; }

    public List<AnswerReturnDto>? Answers { get; set; } = new();

}
