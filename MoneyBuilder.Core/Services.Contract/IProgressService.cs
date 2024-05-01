namespace MoneyBuilder.Core.Services.Contract;

public interface IProgressService
{
    Task<UserProgress?> UpdateUserProgress(string userId, UserProgress updatedProgress);

}
