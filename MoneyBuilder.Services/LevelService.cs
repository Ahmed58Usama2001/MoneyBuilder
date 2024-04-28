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

    public async Task<bool> DeleteLevel(int levelId)
    {
        var level = await _unitOfWork.Repository<Level>().GetByIdAsync(levelId);

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

    public async Task<Level?> UpdateAnswer(int levelId, Level updatedlevel)
    {
        var level = await _unitOfWork.Repository<Level>().GetByIdAsync(levelId);

        if (level == null || updatedlevel == null || string.IsNullOrWhiteSpace(updatedlevel.Title))
            return null;

        level = updatedlevel;

        try
        {
            _unitOfWork.Repository<Level>().Update(level);
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
}

