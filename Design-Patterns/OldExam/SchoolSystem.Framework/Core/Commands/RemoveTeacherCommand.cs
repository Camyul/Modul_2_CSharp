using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        private readonly IRemoveTeacher removeTeacher;

        public RemoveTeacherCommand(IRemoveTeacher removeTeacher)
        {
            this.removeTeacher = removeTeacher;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            //if (!Engine.Teachers.ContainsKey(teacherId))
            //{
            //    throw new ArgumentException("The given key was not present in the dictionary.");
            //}

            this.removeTeacher.RemoveTeacher(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
