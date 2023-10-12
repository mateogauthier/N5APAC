namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
        [TestInitialize]
        public void InitTest()
        {
        }

    [TestMethod]
    public void PostStudentOK()
    {
        var mockStudentService = new Mock<IStudentLogic>();
        var studentController = new StudentController(mockStudentService.Object);

        var student = new Student() { Name = "Pablo"};

        var result = studentController.PostStudent(student);

        Assert.IsInstanceOfType(result, typeof(OkResult));
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void PostStudentFail()
    {
        var mockStudentService = new Mock<IStudentLogic>();
        var studentController = new StudentController(mockStudentService.Object);

        var incorrectStudent = new Student() { Name = "555555111"};

        studentController.PostStudent(incorrectStudent);
    }
}
