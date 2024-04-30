namespace MoneyBuilder.APIs.Dtos.LectureDto;

public class LectureUpdateDto
{
    public string Title { get; set; }

    public IFormFile VideoUrl { get; set; }

    public string? Description { get; set; }
}
