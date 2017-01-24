namespace Students_and_courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Student
    {
        private string name;
        private int idNumber;

        public Student(string name, int id)
        {
            this.Name = name;
            this.IdNumber = id;             
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Name must be least one symbol");
                }
                this.name = value;
            }
        }

        public int IdNumber
        {
            get
            {
                return this.idNumber;
            }
            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("number must be between 10000 and 99999");
                }
                this.idNumber = value;
            }
        }
    }
}
