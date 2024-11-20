using DLL.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL;

public static class DLLDependancy
{
    public static void AllDependancy(IServiceCollection Services,IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string"
                                                   + "'DefaultConnection' not found.");

        Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        
    }
}