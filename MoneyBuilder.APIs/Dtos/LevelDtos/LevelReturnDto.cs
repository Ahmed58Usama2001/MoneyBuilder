namespace MoneyBuilder.APIs.Dtos.LevelDtos;

public class LevelReturnDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string PictureUrl { get; set; }

    public string? Objectives { get; set; }

    public List<LectureReturnDto>? Lectures { get; set; } = new();

}
