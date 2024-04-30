namespace MoneyBuilder.Repository.Data.Configurations;

internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    const int shortMaxLength = 255;
    const int longMaxLength = 450;
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("Questions");


        builder.Property(q => q.Description)
               .IsRequired()
               .HasMaxLength(shortMaxLength);

        builder.Property(q => q.LectureId)
       .IsRequired();

        builder.HasOne(q => q.Lecture)
                 .WithMany(l => l.Questions)
                 .HasForeignKey(q => q.LectureId)
                 .IsRequired();

        builder.HasMany(q => q.Answers)
              .WithOne(a => a.Question)
              .HasForeignKey(a => a.QuestionId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
