namespace Students_and_courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Course
    {
        const int studentsInClass = 29;

        private string name;
        private IList<Student> stList = new List<Student>();

        public Course(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public IList<Student> StList
        {
            get
            {
                return this.stList;
            }
            set
            {
                this.stList = value;
            }
        }

        public void AddStudent(Student st)
        {
            if (StList.Count >= studentsInClass)
            {
                throw new ArgumentOutOfRangeException("Number of Student in Class must be 30");
            }
            this.StList.Add(st);
        }

        public void RemoveStudent(Student st)
        {
            int num = this.StList.IndexOf(st);
            this.StList.RemoveAt(num);
        }
    }
}
