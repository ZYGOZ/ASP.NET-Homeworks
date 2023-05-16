using ASP.NET_HomeWork_6.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GradesController : ControllerBase
{
    private readonly List<Grade> _grades;

    public GradesController()
    {
        _grades = new List<Grade>
        {
            new Grade { Id = 1, StudentId = 1, Course = "Математика", Value = 4 },
            new Grade { Id = 2, StudentId = 2, Course = "Математика", Value = 1 },
            new Grade { Id = 3, StudentId = 3, Course = "Математика", Value = 5 }
        };
    }
    [HttpGet]
    public ActionResult<IEnumerable<Grade>> Get()
    {
        return Ok(_grades);
    }

    [HttpGet("{id}")]
    public ActionResult<Grade> Get(int id)
    {
        var grade = _grades.FirstOrDefault(g => g.Id == id);

        if (grade == null)
        {
            return NotFound();
        }

        return Ok(grade);
    }

    [HttpPost]
    public ActionResult<Grade> Post(Grade grade)
    {
        grade.Id = _grades.Count + 1;
        _grades.Add(grade);

        return CreatedAtAction(nameof(Get), new { id = grade.Id }, grade);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Grade grade)
    {
        var existingGrade = _grades.FirstOrDefault(g => g.Id == id);

        if (existingGrade == null)
        {
            return NotFound();
        }

        existingGrade.Course = grade.Course;
        existingGrade.Value = grade.Value;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existingGrade = _grades.FirstOrDefault(g => g.Id == id);

        if (existingGrade == null)
        {
            return NotFound();
        }

        _grades.Remove(existingGrade);

        return NoContent();
    }
}