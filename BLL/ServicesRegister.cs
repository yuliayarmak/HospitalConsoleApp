using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// class to register services
    /// </summary>
    public class ServicesRegister
    {
        private static bool isRegistered;
        private static ServiceProvider serviceProvider;

        /// <summary>
        /// method to register services
        /// </summary>
        /// <returns>registered instance of service provider</returns>
        public static ServiceProvider RegisterServices()
        {
            if(!isRegistered)
            {
                var serviceColl = new ServiceCollection();
                serviceColl.RegisterServices();
                serviceProvider = serviceColl.BuildServiceProvider();

                isRegistered = true;
            }
            return serviceProvider;
        }
    }
}
