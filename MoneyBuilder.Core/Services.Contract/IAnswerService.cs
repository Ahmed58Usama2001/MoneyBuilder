namespace MoneyBuilder.Core.Services.Contract;

public interface IAnswerService
{
    Task<Answer?> CreateAnswerAsync(Answer answer);

    Task<IReadOnlyList<Answer>> ReadAllAnswersAsync(AnswerSpecificationParams speceficationsParams);

    Task<Answer?> ReadByIdAsync(int answerId);

    Task<Answer?> UpdateAnswer(int answerId, Answer newAnswer);

    Task<bool> DeleteAnswer(int answerId);
}
