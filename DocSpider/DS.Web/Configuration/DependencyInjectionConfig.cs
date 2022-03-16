using DS.Business.Interface.Repository;
using DS.Business.Interface.Service;
using DS.Business.Services;
using DS.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DS.Web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(Business.Interface.Repository.IGenericRepository<>), typeof(Data.Repository.GenericRepository<>));
            services.AddScoped<IArquivoRepository, ArquivoRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IDapperRepository, DapperRepository>();
            services.AddScoped<IArquivoService, ArquivoService>();
           
            return services;
        }
    }
}
