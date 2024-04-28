namespace MoneyBuilder.Core.Entities;

public class Level:BaseEntityWithMediaUrl
{
    public string Title { get; set; }

    public string? PictureUrl
    {
        get { return base.MediaUrl; }
        set { base.MediaUrl = value; }
    }

    public string? Objectives { get; set; }

    public List<Lecture>? Lectures { get; set; } = new();

}
