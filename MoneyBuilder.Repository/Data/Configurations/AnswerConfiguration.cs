namespace MoneyBuilder.Repository.Data.Configurations;

internal class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    const int shortMaxLength = 255;
    const int longMaxLength = 450;
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answers");


        builder.Property(a => a.Description)
               .IsRequired()
               .HasMaxLength(shortMaxLength);

        builder.Property(a => a.Explaination)
             .HasMaxLength(longMaxLength);

        builder.Property(a => a.IsRight)
        .IsRequired();

        builder.Property(a => a.QuestionId)
       .IsRequired();

        builder.HasOne(a => a.Question)
                 .WithMany(q => q.Answers)
                 .HasForeignKey(a=> a.QuestionId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.NoAction);
    }
}
