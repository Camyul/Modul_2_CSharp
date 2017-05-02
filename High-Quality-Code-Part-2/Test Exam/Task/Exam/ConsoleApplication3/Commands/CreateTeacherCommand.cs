using System.Collections.Generic;
using SchoolSystem.Contracts;
using SchoolSystem.Enums;

namespace SchoolSystem.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        public static int id = 0;

        public string Execute(IList<string> teacherInfo)
        {
            Engine.teachers.Add(id, new Teachers(teacherInfo[0], teacherInfo[1], (Subject)int.Parse(teacherInfo[2])));
            return $"A new teacher with name {teacherInfo[0]} {teacherInfo[1]}, subject {(Subject)int.Parse(teacherInfo[2])} and ID {id++} was created.";
        }
    }
}