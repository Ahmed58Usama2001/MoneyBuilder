namespace MoneyBuilder.Repository.Data.Configurations;

public class MoneyBuilderContext : IdentityDbContext<AppUser>
{

    public MoneyBuilderContext(DbContextOptions<MoneyBuilderContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}