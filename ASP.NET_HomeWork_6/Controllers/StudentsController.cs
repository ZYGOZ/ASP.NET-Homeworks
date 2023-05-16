using ASP.NET_HomeWork_6.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_HomeWork_6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly List<Student> _students;

        public StudentsController()
        {
            _students = new List<Student>
        {
            new Student { Id = 1, Name = "Иван" },
            new Student { Id = 2, Name = "Петр" },
            new Student { Id = 3, Name = "Мария" }
        };
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return Ok(_students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> Post(Student student)
        {
            student.Id = _students.Count + 1;
            _students.Add(student);

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = student.Name;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            _students.Remove(existingStudent);

            return NoContent();
        }
    }

}
