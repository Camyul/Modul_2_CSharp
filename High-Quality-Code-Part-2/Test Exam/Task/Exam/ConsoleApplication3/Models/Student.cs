using System;
using System.Collections.Generic;
using System.Linq;
using SchoolSystem.Models;
using SchoolSystem.Enum;
using System.Text.RegularExpressions;

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
            this.Marks = new List<Mark>();
        }

        public List<Mark> Marks
        {
            get
            {
                return this.marks;
            }

            private set
            {
                this.marks = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (!Regex.Match(value, @"^[a-zA-Z]+$").Success)
                {
                    throw new ArgumentOutOfRangeException($"FirstName {value} can contain only latin symbols");
                }

                if (value.Length < 2 && value.Length > 30)
                {
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
                if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    throw new ArgumentOutOfRangeException($"LastName {value} can contain only latin symbols");
                }

                if (value.Length < 2 && value.Length > 30)
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
                if ((int)value < 1 || (int)value > 12)
                {
                    throw new ArgumentOutOfRangeException("Grades must be between 1 an 12");
                }

                this.grades = value;
            }
        }

        public string ListMarks()
        {
            if (this.Marks.Count == 0)
            {
                return "This student has no marks.";
            }

            var listMarks = this.Marks
                .Select(m => $"{m.Subject} => {m.Valuation}")
                .ToList();
            return string.Join("\n", listMarks);
        }
    }
}
