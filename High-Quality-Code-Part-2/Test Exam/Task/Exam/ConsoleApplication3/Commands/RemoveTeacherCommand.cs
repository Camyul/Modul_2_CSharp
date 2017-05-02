using SchoolSystem.Contracts;
using SchoolSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> teacherInfo)
        {
            Engine.teachers.Remove(int.Parse(teacherInfo[0]));
            return $"Teacher with ID {int.Parse(teacherInfo[0])} was sucessfully removed.";
        }
    }
}
