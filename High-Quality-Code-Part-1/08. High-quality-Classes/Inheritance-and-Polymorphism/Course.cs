using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name)
        {
            this.Name = name;
            this.TeacherName = "Teacher not Added";
            this.students = new List<string>();
        }

        public Course(string courseName, string teacherName) 
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.students = new List<string>();
        }

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be Empty!");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be Empty!");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentNullException("Name cannot be Empty!");
                }

                this.students = value;
            }
        }

        protected string GetStudentsAsString()
        {
            string result = "{ }";

            if (this.Students == null || this.Students.Count == 0)
            {
                return result;
            }
            else
            {
                result = "{ " + string.Join(", ", this.Students) + " }";
                return result;
            }
        }
    }
}
