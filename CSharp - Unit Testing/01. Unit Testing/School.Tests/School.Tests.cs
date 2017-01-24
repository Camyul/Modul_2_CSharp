namespace School.Tests
{
    using System;
    using Students_and_courses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void AddStudentAtSchool_ShouldBeAdded()
        {
            School karavelov = new School("Karavelov");
            Student pesho = new Student("Pesho", 13000);
            karavelov.AddStudent(pesho);

            Assert.AreEqual(karavelov.AllStudents.Count, 1);
        }
    }
}
