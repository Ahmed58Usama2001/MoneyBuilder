namespace MoneyBuilder.Core.Services.Contract;

public interface IQuestionService
{
    Task<Question?> CreateQuestionAsync(Question question);

    Task<IReadOnlyList<Question>> ReadAllQuestionsAsync(QuestionSpecificationParams speceficationsParams);

    Task<Question?> ReadByIdAsync(int questionId);

    Task<Question?> UpdateQuestion(int questionId, Question updatedQuestion);

    Task<bool> DeleteQuestion(int questionId);
}
