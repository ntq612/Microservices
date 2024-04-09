using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastuctureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        //Add service to container
        //services.AddDbContext<ApplicationDbContext>()
        return services;
    }
}