namespace MoneyBuilder.APIs.Dtos.LevelDtos;

public class LevelCreateDto
{
    public string Title { get; set; }
    public IFormFile PictureUrl { get; set; }
    public string? Objectives { get; set; }
}
