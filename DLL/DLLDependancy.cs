using DLL.DBContext;
using DLL.Repositories;
using DLL.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL;

public static class DLLDependancy
{
    public static void AllDependancy(IServiceCollection services,IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string"
                                                   + "'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
            
        //services.AddTransient<IDepartementRepository, DepartementRepository>();
       // services.AddTransient<IStudentRepository, StudentRepository>(); 
        var mm = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            
        // repository dependency

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        // services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        // services.AddTransient<IStudentRepository, StudentRepository>();

        
    }
}