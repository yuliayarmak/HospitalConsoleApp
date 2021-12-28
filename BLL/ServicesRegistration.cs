using BLL.IServices;
using BLL.Services;
using DAL.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ServicesRegistration
    {
        /// <summary>
        /// method-extension for default IServiceCollection
        /// </summary>
        /// <param name="serviceCollection">extension object name</param>
        /// <returns></returns>
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRegistryService, RegistryService>();
            serviceCollection.AddScoped<IPatientService, PatientService>();
            serviceCollection.AddScoped<IDoctorService, DoctorService>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }
    }
}
