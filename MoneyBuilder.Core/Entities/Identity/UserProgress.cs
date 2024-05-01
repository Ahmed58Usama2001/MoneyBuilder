namespace MoneyBuilder.Core.Entities.Identity;

public class UserProgress : BaseEntity
{
    [JsonIgnore]
    public string AppUserId { get; set; }
    [JsonIgnore]
    public AppUser AppUser { get; set; }

    public int? CurrentLectureId { get; set; }
    public Lecture? CurrentLecture { get; set; }
}

