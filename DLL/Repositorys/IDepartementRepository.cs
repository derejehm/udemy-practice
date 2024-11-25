using System.Transactions;
using DLL.DBContext;
using DLL.Models;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositorys;

public interface IDepartementRepository:IRepositoryBase<Departement>
{
   
    
}

public class DepartementRepository : RepositoryBase<Departement>, IDepartementRepository
{

    public DepartementRepository(ApplicationDbContext context):base(context)
    {
    }
}