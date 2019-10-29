using System;
using DevEK.Business.Interfaces;
using DevEK.Business.Notifications;
using DevEK.Business.Services;
using DevEK.Data.Context;
using DevEK.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DevEK.Api.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<AppDBContext>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<INotify, Notify>();

            return services;
        }

    }
}
