namespace MoneyBuilder.Core.Entities;

public class Lecture : BaseEntityWithMediaUrl
{
    public string Title { get; set; }

    public string VideoUrl
    {
        get { return base.MediaUrl; }
        set { base.MediaUrl = value; }
    }

    public string? Description { get; set; }

    public int LevelId { get; set; }
    public Level Level { get; set; }

    [JsonIgnore]
    public List<Question>? Questions { get; set; } = new();
}
