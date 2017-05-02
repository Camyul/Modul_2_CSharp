using System;
using System.Collections.Generic;
using System.Linq;
using SchoolSystem.Models;
using SchoolSystem.Enum;

namespace SchoolSystem.Models
{
    public class Student
    {
        // This code sucks, you know it and I know it.  
        // Move on and call me an idiot later.
        private string firstName;
        private string lastName;
        private Grade grades;
        private List<Mark> marks;

        public Student(string fName, string lName, Grade grades)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Grades = grades;
            this.marks = new List<Mark>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value.Length < 2 && 30 < value.Length)
                {
                    // TODO check for only latin symbols
                    throw new ArgumentOutOfRangeException("First Name must be between 2 an 30 symbols");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value.Length < 2 && 30 < value.Length)
                {
                    throw new ArgumentOutOfRangeException("Last Name must be between 2 an 30 symbols");
                }

                this.lastName = value;
            }
        }

        public Grade Grades
        {
            get
            {
                return this.grades;
            }

            set
            {
                if ((int)value < 1 && 12 < (int)value)
                {
                    throw new ArgumentOutOfRangeException("Grades must be between 1 an 12");
                }

                this.grades = value;
            }
        }

        public string ListMarks() {
            var listMarks = marks.Select(m => $"{m.Subject} => {m.Valuation}").ToList();
            return string.Join("\n", listMarks); }
    }
}
