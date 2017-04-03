using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade cannot be negative");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("MinGrade cannot be negative");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("MinGrade cannot be Biggest or equal from MaxGrade");
        }

        if (comments == null || comments == string.Empty)
        {
            throw new ArgumentNullException("Commentar cannot be null or Empty String");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
