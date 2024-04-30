namespace MoneyBuilder.Services;

public class LectureService(IUnitOfWork unitOfWork) : ILectureService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Lecture?> CreateLectureAsync(Lecture lecture)
    {
        try
        {
            await _unitOfWork.Repository<Lecture>().AddAsync(lecture);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;

            return lecture;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return null;
        }
    }

    public async Task<bool> DeleteLecture(int lectureId)
    {
        var lecture = await _unitOfWork.Repository<Lecture>().GetByIdAsync(lectureId);

        if (lecture == null)
            return false;

        try
        {
            _unitOfWork.Repository<Lecture>().Delete(lecture);

            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0)
                return false;

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return false;
        }
    }

    public async Task<IReadOnlyList<Lecture>> ReadAllLecturesAsync(LectureSpecificationParams speceficationsParams)
    {
        var spec = new LectureSpecifications(speceficationsParams);

        var lectures = await _unitOfWork.Repository<Lecture>().GetAllWithSpecAsync(spec);

        return lectures;
    }

    public async Task<Lecture?> ReadByIdAsync(int lectureId)
    {
        var spec = new LectureSpecifications(lectureId);

        var lecture = await _unitOfWork.Repository<Lecture>().GetByIdWithSpecAsync(spec);

        return lecture;
    }

    public async Task<Lecture?> UpdateLecture(Lecture storedLecture, Lecture newLecture)
    {
        if (storedLecture == null || newLecture == null)
            return null;

        storedLecture.Title = newLecture.Title;
        storedLecture.Description = newLecture.Description;
        storedLecture.VideoUrl = newLecture.VideoUrl;

        try
        {
            _unitOfWork.Repository<Lecture>().Update(storedLecture);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;

            return storedLecture;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return null;
        }
    }
}

