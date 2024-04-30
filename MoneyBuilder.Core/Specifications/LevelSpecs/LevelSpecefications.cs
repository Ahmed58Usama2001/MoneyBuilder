namespace MoneyBuilder.Core.Specifications.LevelSpecs;

public class LevelSpecefications : BaseSpecifications<Level>
{
    public LevelSpecefications(LevelSpeceficationsParams speceficationsParams)
        : base()

    {
        AddIncludes();

       

    }

    public LevelSpecefications(int id)
        : base(p => p.Id == id)
    {
        AddIncludes();
    }

    private void AddIncludes()
    {
        Includes.Add(p => p.Lectures);
    }

}
