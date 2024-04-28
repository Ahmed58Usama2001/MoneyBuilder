namespace MoneyBuilder.Core.Entities;

public class Question:BaseEntityWithMediaUrl
{
    public string Description { get; set; }

    public string? PictureUrl
    {
        get { return base.MediaUrl; }
        set { base.MediaUrl = value; }
    }

    public int LectureId { get; set; }
    public Lecture Lecture { get; set; }

    public List<Answer>? Answers { get; set; } = new();
}
