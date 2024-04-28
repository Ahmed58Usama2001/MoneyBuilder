namespace MoneyBuilder.Core.Specifications.AnswerSpecs;

public class AnswerSpecifications : BaseSpecifications<Answer>
{
    public AnswerSpecifications(AnswerSpecificationParams speceficationsParams)
      : base(e =>
         (
               (speceficationsParams.questionId == null || e.QuestionId == speceficationsParams.questionId)
         ))
    {
       // AddIncludes();

        AddOrderBy(p => p.Id);

    }

    public AnswerSpecifications(int id)
        : base(e => e.Id.Equals(id))
    {
        //AddIncludes();
    }
    private void AddIncludes()
    {

    }
}

