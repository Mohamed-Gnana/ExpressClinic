using ExpressClinic.SharedKernal.Abstraction.IServices;
using ExpressClinic.SharedKernal.Infrastructure.Services.EmailService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Infrastructure.DependancyInjection
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddSharedKernalInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
