namespace MoneyBuilder.Core.Specifications.LectureSpecs;

public class LectureSpecifications :BaseSpecifications<Lecture>
{
    public LectureSpecifications(LectureSpecificationParams speceficationsParams)
      : base(e =>
         (
               (speceficationsParams.levelId == null || e.LevelId == speceficationsParams.levelId)
         ))
    {
        AddIncludes();

            AddOrderBy(p => p.Id);

    }

    public LectureSpecifications(int id) 
        : base(e => e.Id.Equals(id))
    {
        AddIncludes();
    }
    private void AddIncludes()
    {
        Includes.Add(c => c.Questions);

    }
}

