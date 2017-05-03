using SchoolSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.Contracts
{
    public interface IStudents
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        Grade Grades { get; set; }

        List<Mark> Marks { get;  }

        string ListMarks();

    }
}
