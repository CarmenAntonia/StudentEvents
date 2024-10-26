using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentEvents.Dtos;
using StudentEvents.Models;
using StudentEvents.Services;

namespace StudentEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentService studentService;

        public StudentsController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public Task<List<Student>> Get()
        {
            return studentService.GetAsync();
        }
        

        [HttpGet]
        [Route("student")]
        public async Task<ActionResult<Student>> GetbyId(string id)
        {
            var student = await studentService.GetAsync(id);
            if (student is null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentDto student)
        {
            await studentService.CreateAsync(student);
            return CreatedAtAction(nameof(Get), student);
        }

        [HttpPut]
        public async Task<IActionResult> Put(string id, Student newStudent)
        {
            var student = await studentService.GetAsync(id);

            if (student is null)
            {
                return NotFound();
            }

            newStudent.Id = student.Id;

            await studentService.UpdateAsync(id, newStudent);

            return NoContent();
        }
    }
}
