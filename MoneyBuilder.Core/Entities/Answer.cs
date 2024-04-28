namespace MoneyBuilder.Core.Entities;

public class Answer:BaseEntity
{
    public string Description { get; set; }

    public bool IsRight { get; set; }

    public string? Explaination { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }
}
