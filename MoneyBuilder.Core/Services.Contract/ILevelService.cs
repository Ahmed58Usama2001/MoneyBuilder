namespace MoneyBuilder.Core.Services.Contract;

public interface ILevelService
{
    Task<Level?> CreateLevelAsync(Level level);

    Task<IReadOnlyList<Level>> ReadAllLevelsAsync(LevelSpeceficationsParams speceficationsParams);

    Task<Level?> ReadByIdAsync(int levelId);

    Task<Level?> UpdateLevel(Level storedLevel, Level newLevel);

    Task<bool> DeleteLevel(Level level);
}
