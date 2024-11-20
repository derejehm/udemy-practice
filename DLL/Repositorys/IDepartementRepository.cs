using System.Transactions;
using DLL.DbContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositorys;

public interface IDepartementRepository
{
    Task<Departement> Insert(Departement departement);
    Task<List<Departement>> GetAll();
    
    Task<Departement> GetById(string code);
    Task<Departement> Update(Departement departement);
    Task<Departement> Delete(Departement departement);
    
}

public class DepartementRepository : IDepartementRepository
{
    
    private readonly ApplicationDbContext _context;

    public DepartementRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Departement> Insert(Departement departement)
    {
        await _context.Departements.AddAsync(departement);
        await _context.SaveChangesAsync();
        return departement;
    }

    public async Task<List<Departement>> GetAll()
    {
        return await _context.Departements.ToListAsync();
    }

    public async Task<Departement> GetById(string code)
    {
        return await _context.Departements.FirstOrDefaultAsync(x => x.Code == code);
    }

    public async Task<Departement> Update(Departement departement)
    {
       var dept = await _context.Departements.FirstOrDefaultAsync(x => x.Code == departement.Code);
       dept.Name = departement.Name;
       _context.Departements.Update(dept);
       _context.SaveChangesAsync();
       return dept;
    }

    public async Task<Departement> Delete(Departement departement)
    {
       var tobdelete= await _context.Departements.FirstOrDefaultAsync(x => x.Code == departement.Code);
       _context.Departements.Remove(tobdelete);
       _context.SaveChangesAsync();
       return departement;
    }
}