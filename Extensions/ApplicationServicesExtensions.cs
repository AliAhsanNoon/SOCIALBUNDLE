using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DbConnection"));
            });
            service.AddCors();
            service.AddScoped<ITokenService, TokenService>();
            return service;
        }
    }
}
