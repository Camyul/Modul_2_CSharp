namespace Students_and_courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class School
    {
        private IList<Student> allStudents = new List<Student>();

        public School(string name)
        {
            this.Name = name;
        }

        public IList<Student> AllStudents
        {
            get
            {
                return this.allStudents;
            }
            set
            {
                this.allStudents = value;
            }
        }

        public string Name { get; private set; }

        public void AddStudent(Student st)
        {
            this.AllStudents.Add(st);
        }

        public void RemoveStudent(Student st)
        {
            int num = this.AllStudents.IndexOf(st);
            this.AllStudents.RemoveAt(num);
        }

        
    }
}
