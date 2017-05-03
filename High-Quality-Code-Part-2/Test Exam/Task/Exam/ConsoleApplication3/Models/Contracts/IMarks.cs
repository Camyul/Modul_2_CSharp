using SchoolSystem.Enums;

namespace SchoolSystem.Models.Contracts
{
    public interface IMarks
    {
        Subject Subject { get; }

        float Valuation { get; }
    }
}
