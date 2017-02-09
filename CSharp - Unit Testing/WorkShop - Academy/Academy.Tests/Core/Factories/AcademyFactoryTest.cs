namespace Academy.Tests.Core.Factories
{
    using Academy.Core.Contracts;
    using Academy.Core.Factories;
    using Academy.Models.Contracts;
    using Academy.Models.Utils.LectureResources;
    using NUnit.Framework;
    using System;
    [TestFixture]
    class AcademyFactoryTest
    {
        [Test]
        public void CreateLectureResourse_ShouldThrowArgumentException_WhenPassedTypeIsInvalid()
        {
            //Arrange
            IAcademyFactory testFactory = AcademyFactory.Instance;

            //Act & Assert

            Assert.Throws<ArgumentException>(() => testFactory.CreateLectureResource("clip", "CSS", "http://telerikacademy.com"));


        }

        [Test]
        public void CreateLectureResourse_ShouldAssignCorrectData_WhenPassedTypeVideo()
        {
            //Arrange
            IAcademyFactory testFactory = AcademyFactory.Instance;

            //Act & Assert

            Assert.IsInstanceOf<VideoResource>(testFactory.CreateLectureResource("video", "CSS", "http://telerikacademy.com"));
        }

        [Test]
        public void CreateLectureResourse_ShouldAssignCorrectData_WhenPassedTypePresentation()
        {
            //Arrange
            IAcademyFactory testFactory = AcademyFactory.Instance;

            //Act & Assert

            Assert.IsInstanceOf<PresentationResource>(testFactory.CreateLectureResource("presentation", "CSS", "http://telerikacademy.com"));
        }

        [Test]
        public void CreateLectureResourse_ShouldAssignCorrectData_WhenPassedTypeDemo()
        {
            //Arrange
            IAcademyFactory testFactory = AcademyFactory.Instance;

            //Act & Assert

            Assert.IsInstanceOf<DemoResource>(testFactory.CreateLectureResource("demo", "CSS", "http://telerikacademy.com"));
        }

        [Test]
        public void CreateLectureResourse_ShouldAssignCorrectData_WhenPassedTypeHomework()
        {
            //Arrange
            IAcademyFactory testFactory = AcademyFactory.Instance;

            //Act & Assert

            Assert.IsInstanceOf<HomeworkResource>(testFactory.CreateLectureResource("homework", "CSS", "http://telerikacademy.com"));
        }
    }
}
