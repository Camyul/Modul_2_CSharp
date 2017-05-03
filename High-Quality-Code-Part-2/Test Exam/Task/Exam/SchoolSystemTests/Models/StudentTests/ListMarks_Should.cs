using Moq;
using NUnit.Framework;
using SchoolSystem.Enum;
using SchoolSystem.Enums;
using SchoolSystem.Models;
using SchoolSystem.Models.Contracts;
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

        [Test]
        public void ShouldListMarks_WhenStudentHasMarks()
        {
            var markMock = new Mock<IMarks>();
            markMock.SetupGet(x => x.Subject).Returns(Subject.English);
            markMock.SetupGet(x => x.Valuation).Returns(4);

            var student = new Student("Pesho", "Peshov", Grade.Eleventh);
            //student.Marks.Add(markMock.Object); //Don't work, i don't know what

            var executionResult = student.ListMarks()
                .ToLower();

            Assert.That(executionResult.Contains("has"));
            Assert.That(executionResult.Contains("marks"));
            Assert.That(executionResult.Contains("english"));
            Assert.That(executionResult.Contains("4"));
        }
    }
}
