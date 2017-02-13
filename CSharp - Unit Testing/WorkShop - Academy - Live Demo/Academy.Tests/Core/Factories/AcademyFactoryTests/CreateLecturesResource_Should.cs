using Academy.Core.Factories;
using Academy.Models.Utils.LectureResources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Core.Factories.AcademyFactoryTests
{
    [TestFixture]
    public class CreateLecturesResource_Should
    {
        [Test]
        public void ReturnVideoResource_WhenVideoTypeIsPassed()
        {
            //Arrange
            var factory = AddStudentToSeasonCommand.Instance;

            //Act
            var resource = factory.CreateLectureResource("video", "Pesho's video", "11115");

            //Assert
            Assert.IsInstanceOf<VideoResource>(resource);
        }

        [Test]
        public void ReturnDemoResource_WhenDemoTypeIsPassed()
        {
            //Arrange
            var factory = AddStudentToSeasonCommand.Instance;

            //Act
            var resource = factory.CreateLectureResource("demo", "Pesho's video", "11115");

            //Assert
            Assert.IsInstanceOf<DemoResource>(resource);
        }

        [Test]
        public void ReturnPresentationResource_WhenPresentationTypeIsPassed()
        {
            //Arrange
            var factory = AddStudentToSeasonCommand.Instance;

            //Act
            var resource = factory.CreateLectureResource("presentation", "Pesho's video", "11115");

            //Assert
            Assert.IsInstanceOf<PresentationResource>(resource);
        }

        [Test]
        public void ReturnHomeworkResource_WhenHomeworkTypeIsPassed()
        {
            //Arrange
            var factory = AddStudentToSeasonCommand.Instance;

            //Act
            var resource = factory.CreateLectureResource("homework", "Pesho's video", "11115");

            //Assert
            Assert.IsInstanceOf<HomeworkResource>(resource);
        }

        [Test]
        public void ThrowArgumentException_WhenInvalidTypeIsPassed()
        {
            //Arrange
            var factory = AddStudentToSeasonCommand.Instance;
            

            //Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("pesho", "Pesho's video", "11115"));
        }
    }
}
