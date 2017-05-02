using SchoolSystem;
using System;
using System.Collections.Generic;
using SchoolSystem.Contracts;

namespace SchoolSystem.Commands
{
    class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> paras)
        {
            Engine.students.Remove(int.Parse(paras[0]));
            return $"Student with ID {int.Parse(paras[0])} was sucessfully removed.";
        }
    }

    class CreateStudentCommand : ICommand
    {
        public static int id = 0;
        public string Execute(IList<string> studentInfo)
        {
            Engine.students.Add(id, new Student(studentInfo[0], studentInfo[1], (Grade)int.Parse(studentInfo[2])));
            return $"A new student with name {studentInfo[0]} {studentInfo[1]}, grade {(Grade) int.Parse(studentInfo[2])} and ID {id++} was created.";
        }
    }

    class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {            
            return Engine.students[int.Parse(parameters[0])].ListMarks();
        }
    }
    class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> prms)
        {
            var teecherid = int.Parse(prms[0]);
            var studentid = int.Parse(prms[1]);
            // Please work
            var student = Engine.students[teecherid];
            var adhyaapak = Engine.teachers[studentid];
            adhyaapak.AddMark(student, float.Parse(prms[2]));
            return $"Teacher {adhyaapak.fName} {adhyaapak.lName} added mark {float.Parse(prms[2])} to student {student.FirstName} {student.LastName} in {adhyaapak.subject}.";
        }
    }
}
