﻿using AutoMapper;
using Core.CQRS;
using Domain.Commands;
using Domain.Handlers.Commands;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Bus;
using Infrastructure.Configurations;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Mappings;
using Services.Services;
using Services.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace App.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<IMovieRepository, MovieRepository>();

            services.AddScoped<IRepository<Person>, Repository<Person>> ();

            services.AddScoped<IHandler<CreateMovieCommand>, MovieCommandHandler>();
            services.AddScoped<IHandler<UpdateMovieCommand>, MovieCommandHandler>();
            services.AddScoped<IHandler<RemoveMovieCommand>, MovieCommandHandler>();

            services.AddScoped<IHandler<CreatePersonCommand>, PersonCommandHandler>();
            services.AddScoped<IHandler<CreatePersonCommand>, PersonCommandHandler>();
            services.AddScoped<IHandler<CreatePersonCommand>, PersonCommandHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IBus, InMemoryBus>();

            ConfigureAutomapper(services);

            ConfigureSwagger(services);

            services.AddDbContext<ConfigurationContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            ConfigureSwaggerUi(app);
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void ConfigureAutomapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Movies API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        private static void ConfigureSwaggerUi(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies");
            });
        }
    }
}