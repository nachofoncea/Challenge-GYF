using ChallengeGYF.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using IBLL = ChallengeGYF.BLL.Interfaces;
using IDAL = ChallengeGYF.DAL.Interfaces;

namespace ChallengeGYF.Shared.IOC
{
    public static class IOCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegistrationBLL(services);
            AddRegistrationDAL(services);

            return services;
        }


        private static IServiceCollection AddRegistrationBLL(this IServiceCollection services)
        {
            services.AddTransient<IBLL.IProducto<DTO.DTOProducto>, BLL.Producto>();
            services.AddTransient<IBLL.ICategoria<DTO.DTOCategoria>, BLL.Categoria>();


            return services;
        }

        private static IServiceCollection AddRegistrationDAL(this IServiceCollection services)
        {
            services.AddTransient<IDAL.IProducto<DTO.DTOProducto>, DAL.EF.Producto>();
            services.AddTransient<IDAL.ICategoria<DTO.DTOCategoria>, DAL.EF.Categoria>();


            return services;
        }

    }


}
