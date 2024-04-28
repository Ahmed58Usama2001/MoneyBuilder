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

    public DbSet<UserProgress> UsersProgress { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
}