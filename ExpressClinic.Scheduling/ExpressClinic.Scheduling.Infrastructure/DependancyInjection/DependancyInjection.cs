using ExpressClinic.Scheduling.Abstraction.IRepositories.ICommandsRepositories;
using ExpressClinic.Scheduling.Abstraction.IRepositories.IQueriesRepositories;
using ExpressClinic.Scheduling.Infrastructure.Data.SQLServer;
using ExpressClinic.Scheduling.Infrastructure.Repositories;
using ExpressClinic.Scheduling.Infrastructure.Repositories.QueriesRepositories;
using ExpressClinic.SharedKernal.Infrastructure.DependancyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressClinic.Scheduling.Infrastructure.DependancyInjection
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddSchedulingInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ScheduleDbContext>(options => 
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        p => p.MigrationsAssembly(typeof(ScheduleDbContext).Assembly.FullName)));

            services.AddTransient<IScheduleCommandsRepository, ScheduleCommandsRepository>();
            services.AddTransient<IScheduleQueriesRepository, ScheduleQueriesRepository>();

            services.AddSharedKernalInfrastructure();

            return services;
        }
    }
}
