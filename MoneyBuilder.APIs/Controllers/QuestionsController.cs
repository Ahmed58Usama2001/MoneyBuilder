
using MoneyBuilder.Core.Entities;

namespace MoneyBuilder.APIs.Controllers;

[Authorize]
public class QuestionsController(
    IMapper mapper,
    IQuestionService questionService,
    IAnswerService answerService,
    ILectureService lectureService,
    IUnitOfWork unitOfWork) : BaseApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IQuestionService _questionService = questionService;
    private readonly IAnswerService _answerService = answerService;
    private readonly ILectureService _lectureService = lectureService;

    [ProducesResponseType(typeof(QuestionReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<QuestionReturnDto>> CreateQuestionAsync(QuestionCreateDto questionDto)
    {
        if (questionDto is null) return BadRequest(new ApiResponse(400));

        Lecture? existingLecture = await _lectureService.ReadByIdAsync(questionDto.LectureId);
        if (existingLecture is null)
            return NotFound(new { Message = "Lecture wasn't Not Found", StatusCode = 404 });

        //var mappedQuestion = _mapper.Map<QuestionCreateDto, Question>(questionDto);

        var mappedQuestion = new Question()
        {
            Description = questionDto.Description,
            LectureId=existingLecture.Id,
            Lecture=existingLecture
        };

        var createdQuestion = await _questionService.CreateQuestionAsync(mappedQuestion);
        List<Answer> answers=new();

        Answer? mappedAnswer;
        Answer? createdAnswer;
        foreach (var answer in questionDto.Answers)
        {
            mappedAnswer = new Answer()
            {
                Description= answer.Description,
                IsRight= answer.IsRight,
                Explaination= answer.Explaination,
                Question=createdQuestion,
                QuestionId=createdQuestion.Id
            };

            createdAnswer= await _answerService.CreateAnswerAsync(mappedAnswer);
            if (createdAnswer is null) return BadRequest(new ApiResponse(400));

             answers.Add(createdAnswer);
        }
        createdQuestion.Answers = answers;

        createdQuestion = await _questionService.UpdateQuestion(createdQuestion.Id, createdQuestion);

        if (createdQuestion is null || createdQuestion?.Answers?.Count()<2) return BadRequest(new ApiResponse(400));

        return Ok(_mapper.Map<Question, QuestionReturnDto>(createdQuestion));
    }

    [ProducesResponseType(typeof(QuestionReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpGet]
    [Route("{lectureId}/questions")]
    public async Task<ActionResult<IReadOnlyList<QuestionReturnDto>>> GetQuestionsByLevelId(int lectureId)
    {
        QuestionSpecificationParams speceficationsParams = new QuestionSpecificationParams { lectureId = lectureId };
        if (speceficationsParams.lectureId <= 0)
            return BadRequest(new { message = "Enter a suitable lecture ID: It must be greater than 0" });

        var questions = await _questionService.ReadAllQuestionsAsync(speceficationsParams);

        if (questions == null)
            return NotFound(new ApiResponse(404));

        return Ok(_mapper.Map<IReadOnlyList<Question>, IReadOnlyList<QuestionReturnDto>>(questions));
    }

    [ProducesResponseType(typeof(QuestionReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionReturnDto>> GetQuestion(int id)
    {
        Question? question = await _questionService.ReadByIdAsync(id);

        if (question == null)
            return NotFound(new ApiResponse(404));


        return Ok(_mapper.Map<QuestionReturnDto>(question));
    }

    [ProducesResponseType(typeof(QuestionReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<QuestionReturnDto>> UpdateQuestion(int id, QuestionUpdateDto updatedQuestionDto)
    {
        Question? storedQuestion = await _questionService.ReadByIdAsync(id);

        if (storedQuestion == null)
            return NotFound(new ApiResponse(404));

        storedQuestion?.Answers?.Clear();

        List<Answer> answers = new List<Answer>();

        Answer? mappedAnswer;
        Answer? newAnswer;


        foreach (var answer in updatedQuestionDto.Answers)
        {
            mappedAnswer = new Answer()
            {
                Description = answer.Description,
                IsRight = answer.IsRight,
                Explaination = answer.Explaination,
                Question = storedQuestion,
                QuestionId = storedQuestion.Id
            };

            newAnswer = await _answerService.CreateAnswerAsync(mappedAnswer);
            if (newAnswer is null) return BadRequest(new ApiResponse(400));

            answers.Add(newAnswer);
        }

        storedQuestion.Answers = answers;

        storedQuestion = await _questionService.UpdateQuestion(id, storedQuestion);

        if (storedQuestion == null || storedQuestion?.Answers?.Count() < 2)
            return BadRequest(new ApiResponse(400));

        return Ok(_mapper.Map<QuestionReturnDto>(storedQuestion));
    }

    [ProducesResponseType(typeof(QuestionReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpDelete("question/{Id}")]
    public async Task<IActionResult> DeleteQuestion(int Id)
    {
        var result = await _questionService.DeleteQuestion(Id);

        if (!result)               
            return BadRequest(new ApiResponse(400));

         return Ok(true);
    }

    [ProducesResponseType(typeof(QuestionReturnDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpDelete("answer/{Id}")]
    public async Task<IActionResult> DeleteAnswer(int Id)
    {
        var result = await _answerService.DeleteAnswer(Id);

        if (!result)
            return BadRequest(new ApiResponse(400));

        return Ok(true);
    }
}

