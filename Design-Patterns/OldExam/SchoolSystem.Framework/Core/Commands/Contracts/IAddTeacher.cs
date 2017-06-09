using SchoolSystem.Framework.Models.Contracts;
namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    public interface IAddTeacher
    {
        void AddTeacher(int teacherId, ITeacher teacher);
    }
}
