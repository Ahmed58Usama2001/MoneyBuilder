namespace MoneyBuilder.Core.Specifications.QuestionSpecs;

public class QuestionSpecifications : BaseSpecifications<Question>
{
    public QuestionSpecifications(QuestionSpecificationParams speceficationsParams)
      : base(e =>
         (
               (speceficationsParams.lectureId == null || e.LectureId == speceficationsParams.lectureId)
         ))
    {
        AddIncludes();

        AddOrderBy(p => p.Id);

    }

    public QuestionSpecifications(int id)
        : base(e => e.Id.Equals(id))
    {
        AddIncludes();
    }
    private void AddIncludes()
    {
        Includes.Add(c => c.Answers);

    }
}