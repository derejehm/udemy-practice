using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class DepartementController : MainController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(DepartementStatic.GetDepartements());
    }
    
    [HttpGet("{code}")]
    public IActionResult GetA(string code)
    {
        return Ok(DepartementStatic.GetDepartementByCode(code));
    }

    [HttpPost]
    public IActionResult Insert(Departement departement)
    {
        return Ok(DepartementStatic.AddDepartement((departement)));
    }

    [HttpPut("{code}")]
    public IActionResult update(string code, Departement departement)
    {
        return Ok(DepartementStatic.updateDepartement(code,  departement));
    }
    
    [HttpDelete("{code}")]
    public IActionResult Delete(string code)
    {
        return Ok(DepartementStatic.DeleteDepartement(code));
    }

}

public static class DepartementStatic{

    private static List<Departement> AllDepartements { get; set; } = new List<Departement>();

    public static List<Departement> GetDepartements()
    {
        return AllDepartements;
    }

    public static Departement GetDepartementByCode(string code)
    {
        return AllDepartements.FirstOrDefault(x => x.Code == code);
    }

    public static Departement AddDepartement(Departement departement)
    {
        AllDepartements.Add(departement);
        return departement;
    }

    public static Departement updateDepartement(string code, Departement departement)
    {
        Departement result = new Departement();
        
        foreach (var aDepartement in AllDepartements)
        {
            if (code == aDepartement.Code)
            {
                aDepartement.Name = departement.Name;
                result=aDepartement;
            }
        }

        return result;
    }

    public static Departement DeleteDepartement(string code)
    {
        var department= AllDepartements.FirstOrDefault(x => x.Code == code);
        AllDepartements=AllDepartements.Where(x=>x.Code!=department.Code).ToList();
        return department;
    }
}