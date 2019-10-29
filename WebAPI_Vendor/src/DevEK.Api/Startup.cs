using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using DevEK.Api.Configuration;
using DevEK.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevEK.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup Identify Context - Identity Tables
            //services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseMySql(configuration.GetConnectionString("DefaultConnection"), builder =>
            //   builder.MigrationsAssembly("DevEK.App")));


            // Setup App Context - System Tables
            services.AddDbContext<AppDBContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), builder =>
                builder.MigrationsAssembly(typeof(AppDBContext).Assembly.FullName)));

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.SuppressModelStateInvalidFilter = true;

            });

            services.ResolveDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
