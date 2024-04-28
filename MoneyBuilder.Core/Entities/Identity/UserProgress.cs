namespace MoneyBuilder.Core.Entities.Identity;

public class UserProgress : BaseEntity
{
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public int CurrentLectureId { get; set; }
    public Lecture CurrentLecture { get; set; }
}

