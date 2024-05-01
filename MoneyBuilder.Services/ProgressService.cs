namespace MoneyBuilder.Services;

public class ProgressService(IUnitOfWork unitOfWork) : IProgressService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UserProgress?> UpdateUserProgress(string userId, UserProgress updatedProgress)
    {
        var storedProgress = await _unitOfWork.Repository<UserProgress>().FindAsync(up=>up.AppUserId==userId);

        if (storedProgress == null || updatedProgress == null || updatedProgress.CurrentLectureId ==null)
            return null;

        storedProgress = updatedProgress;

        try
        {
            _unitOfWork.Repository<UserProgress>().Update(storedProgress);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;

            return storedProgress;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return null;
        }
    }
}
