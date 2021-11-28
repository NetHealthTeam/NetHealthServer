using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NetHealthServer.Data.Context;
using NetHealthServer.Jwt;
using NetHealthServer.Middlewares;
using NetHealthServer.Repo.Abstract;
using NetHealthServer.Repo.Concrete;
using NetHealthServer.Service.Abstract;
using NetHealthServer.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHealthServer
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
            services.AddDbContextPool<NetHealthDbContext>(options => options.UseMySql(
                "server=localhost;database=nethealthdatabasethird;user=root;password=root;port=3306;Connect Timeout=5;",
            new MySqlServerVersion(new Version(8, 0, 11)))

                );



            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IRegistrationRepo, RegistrationRepo>();
            services.AddScoped<IActionRepo, ActionRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INutritionRepo, NutritionRepo>();
            services.AddScoped<IDietService, DietService>();
            services.AddScoped<IGymService, GymService>();
            services.AddScoped<IGymRepo, GymRepo>();
            services.AddScoped<IWorkoutRepo, WorkoutRepo>();
            services.AddScoped<IWorkoutService, WorkoutService>();
            services.AddScoped<IExerciseRepo, ExerciseRepo>();
            services.AddScoped<IChatBoxService, ChatBoxService>();





            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false; x.SaveToken = true; x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("kibrit1999+kibrit")),
                    ValidateIssuer = false,
                    ValidateAudience = false


                };
            });
            services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager("kibrit1999+kibrit"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));


            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseCors(builder => builder
 .AllowAnyOrigin()
 .AllowAnyMethod()
 .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
