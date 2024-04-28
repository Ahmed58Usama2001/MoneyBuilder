namespace MoneyBuilder.Repository.Data.Configurations;

internal class LectureConfigurations : IEntityTypeConfiguration<Lecture>
{
    const int shortMaxLength = 255;
    const int longMaxLength = 450;
    public void Configure(EntityTypeBuilder<Lecture> builder)
    {
        builder.ToTable("Lectures");


        builder.Property(l => l.Title)
               .IsRequired()
               .HasMaxLength(shortMaxLength);

        builder.Property(l => l.Description)
        .HasMaxLength(longMaxLength);

        builder.Ignore(q => q.MediaUrl);

        builder.HasOne(l => l.Level)
                 .WithMany(lev => lev.Lectures)
                 .HasForeignKey(l => l.LevelId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(q => q.Questions)
              .WithOne(lec => lec.Lecture)
              .HasForeignKey(lec => lec.LectureId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
