using MoneyBuilder.Core.Entities;

namespace MoneyBuilder.Services;

public class AnswerService(IUnitOfWork unitOfWork) : IAnswerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Answer?> CreateAnswerAsync(Answer answer)
    {
        try
        {
            await _unitOfWork.Repository<Answer>().AddAsync(answer);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;

            return answer;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return null;
        }
    }

    public async Task<bool> DeleteAnswer(int answerId)
    {
        var answer = await _unitOfWork.Repository<Answer>().GetByIdAsync(answerId);

        if (answer == null)
            return false;

        try
        {
            _unitOfWork.Repository<Answer>().Delete(answer);

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

    public async Task<IReadOnlyList<Answer>> ReadAllAnswersAsync(AnswerSpecificationParams speceficationsParams)
    {
        var spec = new AnswerSpecifications(speceficationsParams);

        var answers = await _unitOfWork.Repository<Answer>().GetAllWithSpecAsync(spec);

        return answers;
    }

    public async Task<Answer?> ReadByIdAsync(int answerId)
    {
        var spec = new AnswerSpecifications(answerId);

        var answer = await _unitOfWork.Repository<Answer>().GetByIdWithSpecAsync(spec);

        return answer;
    }

    public async Task<Answer?> UpdateAnswer(int answerId, Answer newAnswer)
    {
        var answer = await _unitOfWork.Repository<Answer>().GetByIdAsync(answerId);

        if (answer == null || newAnswer == null || string.IsNullOrWhiteSpace(newAnswer.Description))
            return null;

        answer = newAnswer;

        try
        {
            _unitOfWork.Repository<Answer>().Update(answer);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;

            return answer;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return null;
        }
    }
}

