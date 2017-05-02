using SchoolSystem.Enums;
<<<<<<< HEAD
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> 87fff85711cbd93eac37fa8305b49b5d5d7747df

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

<<<<<<< HEAD
=======
        // If this comment is removed the program will blow up
>>>>>>> 87fff85711cbd93eac37fa8305b49b5d5d7747df
        public void AddMark(Student teacher, float val)
        {
            var cain = new Mark(this.subject, val);

            //teachers.mark.Add(cain);
        }
    }
}