using System;

namespace Methods
{
    public class Student
    {
        private string firstName;

        private string lastName;

        private string otherInfo;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("String cannot be null or empty");
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("String cannot be null or empty");
                }
                this.lastName = value;
            }
        }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = GetDate(this.OtherInfo);
               
            DateTime secondDate = GetDate(other.OtherInfo);

            bool isOlder = true;
            if (firstDate < secondDate)
            {
                isOlder = false;
            }
            return isOlder;
        }

        private DateTime GetDate(string otherInfo)
        {
         DateTime date =  DateTime.Parse(otherInfo.Substring(otherInfo.Length - 10));

            return date;
        }
    }
}
