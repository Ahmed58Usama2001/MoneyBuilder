namespace MoneyBuilder.Core.Entities;

public class Question:BaseEntity
{
    public string Description { get; set; }

    public int LectureId { get; set; }
    public Lecture Lecture { get; set; }

    public List<Answer>? Answers { get; set; } = new();
}
