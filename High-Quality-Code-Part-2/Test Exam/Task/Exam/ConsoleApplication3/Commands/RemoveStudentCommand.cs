using SchoolSystem.Contracts;
using SchoolSystem.Core;
using System.Collections.Generic;

namespace SchoolSystem.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> studentInfo)
        {
            Engine.students.Remove(int.Parse(studentInfo[0]));
            return $"Student with ID {int.Parse(studentInfo[0])} was sucessfully removed.";
        }
    }
}
