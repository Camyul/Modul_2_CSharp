using NUnit.Framework;
using SchoolSystem.Enum;
using SchoolSystem.Models;
using System;

namespace SchoolSystemTests.Models.StudentTests
{
    [TestFixture]
    public class ListMarks_Should
    {
        [Test]
        public void ReturnErrorMessage_WhenStudentHasNoMarks()
        {
            var student = new Student("Pesho", "Peshev", Grade.Four);

            var executionResult = student.ListMarks();

            StringAssert.Contains("no marks", executionResult);
        }
    }
}
