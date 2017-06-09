using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Models.Contracts
{
    public interface ISchool : IAddStudent, IAddTeacher, IRemoveStudent, IRemoveTeacher, IGetStudentAndTeacher
    {
    }
}
