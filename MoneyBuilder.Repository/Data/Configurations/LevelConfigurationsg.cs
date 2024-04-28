namespace MoneyBuilder.Repository.Data.Configurations;

internal class LevelConfigurations : IEntityTypeConfiguration<Level>
{
    const int shortMaxLength = 255;
    const int longMaxLength = 450;
    public void Configure(EntityTypeBuilder<Level> builder)
    {
        builder.ToTable("Levels");


        builder.Property(l => l.Title)
               .IsRequired()
               .HasMaxLength(shortMaxLength);

        builder.Property(l => l.Objectives)
        .HasMaxLength(longMaxLength);

        builder.Ignore(q => q.MediaUrl);

        builder.HasMany(l => l.Lectures)
              .WithOne(lec => lec.Level)
              .HasForeignKey(c => c.LevelId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
