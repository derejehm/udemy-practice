using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class StudentController : MainController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(StudentStatic.GetStudents());
    }
    
    [HttpGet("{email}")]
    public IActionResult GetA(string email)
    {
        return Ok(StudentStatic.GetStudentByEmail(email));
    }

    [HttpPost]
    public IActionResult Insert(Student student)
    {
        return Ok(StudentStatic.AddStudent((student)));
    }

    [HttpPut("{email}")]
    public IActionResult update(string email, Student student)
    {
        return Ok(StudentStatic.updateStudent(email,  student));
    }
    
    [HttpDelete("{email}")]
    public IActionResult Delete(string email)
    {
        return Ok(StudentStatic.DeleteStudent(email));
    }
}

public static class StudentStatic{

    private static List<Student> AllStudents { get; set; } = new List<Student>();

    public static List<Student> GetStudents()
    {
        return AllStudents;
    }

    public static Student GetStudentByEmail(string email)
    {
        return AllStudents.FirstOrDefault(x => x.Email == email);
    }

    public static Student AddStudent(Student student)
    {
        AllStudents.Add(student);
        return student;
    }

    public static Student updateStudent(string email, Student student)
    {
        Student result = new Student();
        
        foreach (var aStudent in AllStudents)
        {
            if (email == aStudent.Email)
            {
                aStudent.Name = student.Name;
                result=aStudent;
            }
        }

        return result;
    }

    public static Student DeleteStudent(string email)
    {
        var student= AllStudents.FirstOrDefault(x => x.Email == email);
        AllStudents=AllStudents.Where(x=>x.Email!=student.Email).ToList();
        return student;
    }
}