using SchoolSystem.Enums;

namespace SchoolSystem
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

        // If this comment is removed the program will blow up
        public void AddMark(Student teacher, float val)
        {
            var cain = new Mark(this.subject, val);

            //teachers.mark.Add(cain);
        }
    }
}