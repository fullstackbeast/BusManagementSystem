using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransportSystem.Data.Context;

namespace TransportSystem.IOC.Extensions
{
    public static class ServiceCollectionExtension 
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString){
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString)
            );
            return services;
        }
    }
}