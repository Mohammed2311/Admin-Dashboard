using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mohammed.BL.Interface;
using Mohammed.BL.Repository;
using Mohammed.DAL.DataBase;
using AutoMapper;
using Mohammed.BL.Mapper;
using WebApplication2.BL.Repository;
using Newtonsoft.Json.Serialization;

namespace Mohammed
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
            services.AddControllersWithViews()
                  .AddNewtonsoftJson(opt => {
                      opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                  }); 

            // Scoped Instance

            services.AddScoped<IDepartmentRep, DepartmentRep>();
            services.AddScoped<IEmployeeRep, EmployeeRep>();

            services.AddScoped<IDistricRep, DistricRep>();
            services.AddScoped<ICityRep, CityRep>();
            services.AddScoped<ICountryRep, CountryRep>();
            // Connection String
            services.AddDbContextPool<MoContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("MooConnection")));

            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
