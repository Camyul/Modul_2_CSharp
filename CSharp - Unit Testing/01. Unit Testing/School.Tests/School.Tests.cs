namespace School.Tests
{
    using System;
    using Students_and_courses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void GetNameOfSchool_ShouldNameOfSchool()
        {
            School karavelov = new School("Karavelov");


            Assert.AreEqual(karavelov.Name, "Karavelov");
        }

        [TestMethod]
        public void AddStudentAtSchool_ShouldBeAdded()
        {
            School karavelov = new School("Karavelov");
            Student pesho = new Student("Pesho", 13000);
            karavelov.AddStudent(pesho);

            Assert.AreEqual(karavelov.AllStudents.Count, 1);
        }

        [TestMethod]
        public void RemoveStudentAtSchool_ShouldBeRemoved()
        {
            School karavelov = new School("Karavelov");
            Student pesho = new Student("Pesho", 13000);
            Student gosho = new Student("Gosho", 18000);

            karavelov.AddStudent(pesho);
            karavelov.AddStudent(gosho);
            karavelov.RemoveStudent(pesho);

            Assert.AreEqual(karavelov.AllStudents.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullStudentAtSchool_ShouldArgumentExeption()
        {
            School karavelov = new School("Karavelov");

            karavelov.AddStudent(null);
        }


        [TestMethod]
        public void GetNameOfCourse_ShouldNameOfCourse()
        {
            Course biologic = new Course("Biologic");

            Assert.AreEqual(biologic.Name, "Biologic");
        }

        [TestMethod]
        public void AddStudentAtCourse_ShouldBeAdded()
        {
            Course fisics = new Course("Fisics");
            Student pesho = new Student("Pesho", 17000);

            fisics.AddStudent(pesho);

            Assert.AreEqual(fisics.StList.Count, 1);
        }

        [TestMethod]
        public void RemoveStudentAtCourse_ShouldBeRemoved()
        {
            Course fisics = new Course("Fisics");
            Student pesho = new Student("Pesho", 17000);
            Student sasho = new Student("Sasho", 19000);
            Student tisho = new Student("Tisho", 18000);

            fisics.AddStudent(pesho);
            fisics.AddStudent(sasho);
            fisics.AddStudent(tisho);
            fisics.RemoveStudent(pesho);

            Assert.AreEqual(fisics.StList.Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullAtCourse_ShouldExeption()
        {

            Course fisics = new Course("Fisics");

            fisics.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullAtCourse_ShouldExeption()
        {

            Course fisics = new Course("Fisics");

            fisics.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddMoreStudentAtCourse_ShouldExeption()
        {
            Course fisics = new Course("Fisics");
            Student pesho = new Student("Pesho", 17000);

            for (int i = 0; i < 30; i++)
            {
                fisics.AddStudent(pesho);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddStudentWhitIncorectIdNumber_ShouldArgumentOutOfRangeExeption()
        {
            Student pesho = new Student("Pesho", 9000);

           
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateStudentWhitoutName_ShouldNullReferenceExeption()
        {
            Student pesho = new Student(null,11000);
        }

        [TestMethod]
        public void GetNameOfStudent_ShouldNameOfStudent()
        {
            Student pesho = new Student("Pesho", 11000);

            Assert.AreEqual(pesho.Name, "Pesho");
        }
    }
}
