namespace MoneyBuilder.APIs.Dtos.LectureDto;

public class LectureCreateDto
{
    public string Title { get; set; }

    public IFormFile? VideoUrl { get; set; }

    public string? Description { get; set; }

    [Required]
    public int LevelId { get; set; }
}
