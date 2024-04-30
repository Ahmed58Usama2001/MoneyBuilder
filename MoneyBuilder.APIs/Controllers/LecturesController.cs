namespace MoneyBuilder.APIs.Controllers;

[Authorize]
public class LecturesController(
    IMapper mapper,
    ILectureService lectureService,
    ILevelService levelService,
    IUnitOfWork unitOfWork) : BaseApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILectureService _lectureService = lectureService;
    private readonly ILevelService _levelService = levelService;

    [ProducesResponseType(typeof(LectureReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<LectureReturnDto>> CreateLectureAsync(LectureCreateDto lectureDto)
    {
        if (lectureDto is null) return BadRequest(new ApiResponse(400));

        Level? existingLevel = await _levelService.ReadByIdAsync(lectureDto.LevelId);
        if (existingLevel is null)
            return NotFound(new { Message = "Level wasn't Not Found", StatusCode = 404 });

        var mappedLecture = _mapper.Map<LectureCreateDto, Lecture>(lectureDto);

        mappedLecture.VideoUrl = DocumentSetting.UploadFile(lectureDto?.VideoUrl, "Lectures\\LecturesVideos");

        var createdLecture = await _lectureService.CreateLectureAsync(mappedLecture);

        if (createdLecture is null) return BadRequest(new ApiResponse(400));

        return Ok(_mapper.Map<Lecture, LectureReturnDto>(createdLecture));
    }

    [ProducesResponseType(typeof(LectureReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpGet]
    [Route("{levelId}/lectures")]
    public async Task<ActionResult<IReadOnlyList<LectureReturnDto>>> GetLecturesByLevelId(int levelId)
    {
        LectureSpecificationParams speceficationsParams = new LectureSpecificationParams { levelId = levelId };
        if (speceficationsParams.levelId <= 0)
            return BadRequest(new { message = "Enter a suitable level ID: It must be greater than 0" });

        var lectures = await _lectureService.ReadAllLecturesAsync(speceficationsParams);

        if (lectures == null)
            return NotFound(new ApiResponse(404));

        return Ok(_mapper.Map<IReadOnlyList<Lecture>, IReadOnlyList<LectureReturnDto>>(lectures));
    }

    [ProducesResponseType(typeof(LectureReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<ActionResult<LectureReturnDto>> GetLecture(int id)
    {
        Lecture? lecture = await _lectureService.ReadByIdAsync(id);

        if (lecture == null)
            return NotFound(new ApiResponse(404));


        return Ok(_mapper.Map<LectureReturnDto>(lecture));
    }

    [ProducesResponseType(typeof(LectureReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<LectureReturnDto>> UpdateLecture(int id, LectureUpdateDto updatedLectureDto)
    {
        Lecture? storedLecture = await _lectureService.ReadByIdAsync(id);

        if (storedLecture == null)
            return NotFound(new ApiResponse(404));

        if (!string.IsNullOrEmpty(storedLecture?.VideoUrl))
            DocumentSetting.DeleteFile(storedLecture.VideoUrl);

        Lecture newLecture = _mapper.Map<LectureUpdateDto, Lecture>(updatedLectureDto);
        newLecture.Id = storedLecture.Id;

        if (updatedLectureDto.VideoUrl is not null)
            newLecture.VideoUrl = DocumentSetting.UploadFile(updatedLectureDto?.VideoUrl, "Lectures\\LecturesVideos");

        storedLecture = await _lectureService.UpdateLecture(storedLecture, newLecture);

        if (storedLecture == null)
            return BadRequest(new ApiResponse(400));

        return Ok(_mapper.Map<LectureReturnDto>(storedLecture));
    }

    [ProducesResponseType(typeof(LectureReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlogPost(int id)
    {
        var lecture = await _unitOfWork.Repository<Lecture>().GetByIdAsync(id);
        if (lecture == null)
            return NotFound(new ApiResponse(404));

        var result = await _lectureService.DeleteLecture(id);

        if (result)
        {
            if (!string.IsNullOrEmpty(lecture.VideoUrl))
                DocumentSetting.DeleteFile(lecture.VideoUrl);

            return Ok(true);
        }

        return BadRequest(new ApiResponse(400));
    }
}
