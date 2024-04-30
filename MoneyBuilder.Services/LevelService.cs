namespace MoneyBuilder.Services;

public class LevelService(IUnitOfWork unitOfWork) : ILevelService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Level?> CreateLevelAsync(Level level)
    {
        try
        {
            await _unitOfWork.Repository<Level>().AddAsync(level);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;

            return level;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return null;
        }
    }

    public async Task<bool> DeleteLevel(Level level)
    {

        if (level == null)
            return false;

        try
        {
            _unitOfWork.Repository<Level>().Delete(level);

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

    public async Task<IReadOnlyList<Level>> ReadAllLevelsAsync(LevelSpeceficationsParams speceficationsParams)
    {
        var spec = new LevelSpecefications(speceficationsParams);

        var levels = await _unitOfWork.Repository<Level>().GetAllWithSpecAsync(spec);

        return levels;
    }

    public async Task<Level?> ReadByIdAsync(int levelId)
    {
        var spec = new LevelSpecefications(levelId);

        var level = await _unitOfWork.Repository<Level>().GetByIdWithSpecAsync(spec);

        return level;
    }

    public async Task<Level?> UpdateLevel(Level storedLevel, Level newLevel)
    {

        if (storedLevel == null || newLevel == null )
            return null;

            storedLevel.Title=newLevel.Title;
            storedLevel.Objectives=newLevel.Objectives;
            storedLevel.PictureUrl=newLevel.PictureUrl;

        try
        {
            _unitOfWork.Repository<Level>().Update(storedLevel);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;

            return storedLevel;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return null;
        }
    }
}

