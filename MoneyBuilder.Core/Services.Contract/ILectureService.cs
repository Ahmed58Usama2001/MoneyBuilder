namespace MoneyBuilder.Core.Services.Contract;

public interface ILectureService
{
    Task<Lecture?> CreateLectureAsync(Lecture lecture);

    Task<IReadOnlyList<Lecture>> ReadAllLecturesAsync(LectureSpecificationParams speceficationsParams);

    Task<Lecture?> ReadByIdAsync(int lectureId);

    Task<Lecture?> UpdateLecture(int lectureId, Lecture updatedLecture);

    Task<bool> DeleteLecture(int lectureId);
}
