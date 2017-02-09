namespace Academy.Tests.Commands.Adding
{
    using Academy.Commands.Adding;
    using Academy.Core;
    using Academy.Core.Contracts;
    using Academy.Core.Factories;
    using NUnit.Framework;
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Academy.Models.Contracts;
    using Academy.Models;
    using Academy.Models.Enums;
    using System.Collections.Generic;
    using System.Collections;
    [TestFixture]
    class AddStudentsToSeasonCommandsTest
    {


        /*Internal classes need to be tested and there is an assemby attribute:

            using System.Runtime.CompilerServices;
            [assembly: InternalsVisibleTo("NameOfYourUnitTestProject")]

        Add this to the project info file, e.g.Properties\AssemblyInfo.cs.*/

        [Test]
        public void Ctor_ShouldThrowArgumentNullException_WhenPassedNullValue()
        {
            IAcademyFactory testFactory = AcademyFactory.Instance;
            IEngine testEngine = Engine.Instance;
            var testCommand = new AddStudentToSeasonCommand(testFactory, testEngine);

            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, testEngine));
        }

        //[Test]
        //public void Ctor_ShouldAssignFactory_WhenPassedValueIsValid()
        //{
        //    IAcademyFactory testFactory = AcademyFactory.Instance;
        //    IEngine testEngine = Engine.Instance;
        //    var testCommand = new AddStudentToSeasonCommand(testFactory, testEngine);

        //    var result = RunStatic(typeof(AddStudentToSeasonCommand), "factory");

        //    Assert.AreEqual(testFactory, result);
        //}

        //private static object RunStatic(Type classType, string method)
        //{
        //    var methodInfo = classType.GetMethod(method,
        //    BindingFlags.NonPublic | BindingFlags.Static);
        //    return methodInfo.Invoke(null, null);
        //}

        //[Test]
        //public void Execute_ShouldThrowArgumentException_WhenPassedStudentIsAlredyPartOfSeason()
        //{
        //    //Arrange
        //    IAcademyFactory testFactory = AcademyFactory.Instance;
        //    IEngine testEngine = Engine.Instance;
        //    var testCommand = new AddStudentToSeasonCommand(testFactory, testEngine);
        //    var testNewStudent = new List<string>{ "Ivanov", "01" };

        //    //Act 
        //    testCommand.Execute(testNewStudent);

        //    //Assert
        //    Assert.Throws<ArgumentException>(() => testCommand.Execute(testNewStudent));
        //}
    }
}
