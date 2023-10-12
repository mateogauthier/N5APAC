using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        IStudentLogic studentLogic;
        public StudentController(IStudentLogic studentLogic)
        {
            this.studentLogic = studentLogic;
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult PostStudent([FromBody] Student student)
        {
            studentLogic.InsertStudents(student);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudent([FromRoute] int id)
        {
            Student? student = studentLogic.GetStudentById(id);
            return Ok(student);
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            List<Student>? students = studentLogic.GetStudents().ToList();
            return Ok(students);
        }
    }
}
