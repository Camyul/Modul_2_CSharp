using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    public interface IAddStudent
    {
        void AddStudent(int studentId, IStudent student);
    }
}