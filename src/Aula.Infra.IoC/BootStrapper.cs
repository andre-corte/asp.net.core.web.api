using Aula.Domain.Interfaces.Repository;
using Aula.Domain.Interfaces.Services;
using Aula.Infra.Data.Repository;
using Aula.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Infra.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Services
            services.AddTransient<IUsuarioService, UsuarioService>();

            // Repository
            services.AddTransient<IUsuarioRepostory, UsuarioRepository>();
        }

        public static T GetService<T>()
        {
            var serviceCollection = new ServiceCollection();
            RegisterServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider.GetService<T>();
        }
    }
}
