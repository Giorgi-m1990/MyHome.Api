using Domain.Entities;
using Infrastructure.DataContext;
using Infrastructure.Repository.Abstraction;
using Infrastructure.Repository.Implementation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyHome.Application.Abstraction;
using MyHome.Application.Configurations;
using MyHome.Application.Implementation;
using MyHome.Application.Jobs;
using MyHome.Infrastructure.Repository.Abstraction;
using MyHome.Infrastructure.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyHome.Api", Version = "v1" });
            });

           
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            

            services.AddMediatR(AppDomain.CurrentDomain.Load("MyHome.Application"));

            services.Configure<CloudinarySetting>(Configuration.GetSection("CloudinarySettings"));

            services.AddTransient<IAdRepository, AdRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IFeatureRepository, FeatureRepository>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IFeatureItemRepository, FeatureItemRepository>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IFeatureItemSelectOptionsService, FeatureItemSelectOptionsService>();
            services.AddTransient<IFeatureItemSelectRepository, FeatureItemSelectRepository>();
            services.AddTransient<IAdFeatureService, AdFeatureService>();
            services.AddTransient<IAdvertainmentFeatureRepository, AdvertainmentFeatureRepository>();
            services.AddTransient<IAdImageRepository, AdImageRepository>();
            services.AddHostedService<AdExpireDataJob>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyHome.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
