
using DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.DbContext;

public class ApplicationDbContext :Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Departement> Departements { get; set; }

    public DbSet<Student> Students { get; set; }
}