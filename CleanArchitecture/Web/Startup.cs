using Application.Features.Users.Queries.GetUsers;
using Application.Infrastructure;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;
using System.Reflection;
using AutoMapper;
using MediatR.Pipeline;
using FluentValidation.AspNetCore;
using Application.Features.Users.Commands.CreateUser;
using Web.Filters;
using Application.AutoMapperDomainProfiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Services;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Application.Features.Patient.Services.Interfaces;
using Application.Features.Users.Services.Interfaces;
using Application.Features.Users.Services;
using Application.Features.Patient.Services;
using Application.Features.Doctor.Services.Interfaces;
using Application.Features.Doctor.Services;
using Newtonsoft.Json;

namespace Web
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
            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x => {
                    x.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    x.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommand>());

            // Add swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info{ Title = "Clean Architecture App API", Version = "v1" });
            });

            // Add Authentication
            services.AddScoped<UserValidation>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Issuer"],
                       ValidAudience = Configuration["Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                   };
                   options.EventsType = typeof(UserValidation);
               });

            // Add Authorization
            services.AddAuthorization();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            // Add MediatR
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetUsersQueryHandler).GetTypeInfo().Assembly);

            // Add DbContext using SQL Server Provider
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("CatalogConnection")));

            // Add Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IMedicalExaminationRequestRepository, MedicalExaminationRequestRepository>();
            services.AddScoped<IDoctorWorkingTimeRepository, DoctorWorkingTimeRepository>();
            services.AddScoped<IBodyExaminationResultRepository, BodyExaminationResultRepository>();
            services.AddScoped<IBodyExaminationTypeRepository, BodyExaminationTypeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add Automapper
            services.AddAutoMapper();
            services.AddAutoMapper(typeof(RequestModelsToEntityModels).GetTypeInfo().Assembly);

            // Add Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISecurePasswordHasher, SecurePasswordHasher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture API V1");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
