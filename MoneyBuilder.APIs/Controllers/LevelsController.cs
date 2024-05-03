namespace MoneyBuilder.APIs.Controllers;

public class LevelsController(
    IMapper mapper,
    ILevelService levelService,
    IUnitOfWork unitOfWork) : BaseApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILevelService _levelService = levelService;

    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(LevelReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<LevelReturnDto>> CreateLevelAsync(LevelCreateDto levelDto)
    {
        if (levelDto is null) return BadRequest(new ApiResponse(400));

        var mappedLevel = _mapper.Map<LevelCreateDto, Level>(levelDto);

        mappedLevel.PictureUrl = DocumentSetting.UploadFile(levelDto?.PictureUrl, "Levels\\LevelsImages");

        var createdLevel = await _levelService.CreateLevelAsync(mappedLevel);

        if (createdLevel is null) return BadRequest(new ApiResponse(400));

        return Ok(_mapper.Map<Level, LevelReturnDto>(createdLevel));
    }

    [AllowAnonymous]
    [ProducesResponseType(typeof(LevelReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LevelReturnDto>>> GetLevels([FromQuery] LevelSpeceficationsParams speceficationsParams)
    {
        var levels = await _levelService.ReadAllLevelsAsync(speceficationsParams);

        if (levels == null)
            return NotFound(new ApiResponse(404));

        return Ok(_mapper.Map<IReadOnlyList<Level>, IReadOnlyList<LevelReturnDto>>(levels));
    }

    [Authorize(Roles = "Admin,User")]
    [ProducesResponseType(typeof(LevelReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<ActionResult<LevelReturnDto>> GetLevel(int id)
    {
        Level? level = await _levelService.ReadByIdAsync(id);

        if (level == null)
            return NotFound(new ApiResponse(404));


        return Ok(_mapper.Map<LevelReturnDto>(level));
    }

    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(LevelReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<LevelReturnDto>> UpdateLevel(int id, LevelCreateDto updatedLevelDto)
    {
        Level? storedLevel = await _levelService.ReadByIdAsync(id);

        if (storedLevel == null)
            return NotFound(new ApiResponse(404));

        if (!string.IsNullOrEmpty(storedLevel?.PictureUrl))
            DocumentSetting.DeleteFile(storedLevel.PictureUrl);

        Level newLevel = _mapper.Map<LevelCreateDto, Level>(updatedLevelDto);
        newLevel.Id = storedLevel.Id;

        if (updatedLevelDto.PictureUrl is not null)
            newLevel.PictureUrl = DocumentSetting.UploadFile(updatedLevelDto?.PictureUrl, "Levels\\LevelsImages");

        storedLevel = await _levelService.UpdateLevel(storedLevel, newLevel);

        if (storedLevel == null)
            return BadRequest(new ApiResponse(400));

        return Ok(_mapper.Map<LevelReturnDto>(storedLevel));
    }

    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(LevelReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLevel(int id)
    {
        var level = await _unitOfWork.Repository<Level>().GetByIdAsync(id);
        if (level == null)
            return NotFound(new ApiResponse(404));

        var result = await _levelService.DeleteLevel(id);

        if (result)
        {
            if (!string.IsNullOrEmpty(level.PictureUrl))
                DocumentSetting.DeleteFile(level.PictureUrl);

            return Ok(true);
        }

        return BadRequest(new ApiResponse(400));
    }
}
