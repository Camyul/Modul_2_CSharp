using SchoolSystem.Enums;
using SchoolSystem.Models;

namespace SchoolSystem.Models
{
    internal class Teachers
    {
        public string fName;
        public string lName;
        public Subject subject;

        public Teachers(string fName, string lName, Subject subject)
        {
            this.fName = fName;
            this.lName = lName;
            this.subject = subject;
        }

        public void AddMark(Student teacher, float val)
        {
            var cain = new Mark(this.subject, val);

            //teachers.mark.Add(cain);
        }
    }
}