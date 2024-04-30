namespace MoneyBuilder.APIs.Dtos.LectureDto;

public class LectureReturnDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string VideoUrl { get; set; }

    public string? Description { get; set; }

    public int LevelId { get; set; }
    public string Level { get; set; }

}
