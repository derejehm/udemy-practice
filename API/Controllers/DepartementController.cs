using DLL.Models;
using DLL.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class DepartementController : MainController
{
    private readonly IDepartementRepository _departementRepository;

    public  DepartementController(IDepartementRepository departementRepository )
    {
        _departementRepository = departementRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()   
    {
        return Ok(await _departementRepository.GetAll());
    }
    
    [HttpGet("{code}")]
    public async Task<IActionResult> GetA(string code)
    {
        return Ok(await _departementRepository.GetById(code));
    }

    [HttpPost]
    public async Task<IActionResult> Insert(Departement departement)
    {
        return Ok(await _departementRepository.Insert(departement));
    }

    [HttpPut("{code}")]
    public async Task<IActionResult>  update(Departement departement)
    {
        return Ok( await _departementRepository.Update(departement));
    }
    
    [HttpDelete("{code}")]
    public async Task<IActionResult> Delete(Departement departement)
    {
        return Ok(await _departementRepository.Delete(departement));
    }

}

/*
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
*/