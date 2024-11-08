using JwtAuthentication.DataAccess.Common.Repositories;
using JwtAuthentication.DataAccess.Context;
using JwtAuthentication.DataAccess.Repositories;
using JwtAuthentication.Logic.Common.Helpers;
using JwtAuthentication.Logic.Common.Services;
using JwtAuthentication.Logic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace JwtAuthentication.WebAPI
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
            services.AddDbContext<JwtAuthenticationContext>(options =>
            {
                options.UseSqlServer(Configuration["DB_CONNECTION"]);
            });

            services.Configure<AuthOptions>(options =>
            {
                options.Issuer = Configuration["ISSUER"];
                options.Audience = Configuration["AUDIENCE"];
                options.Secret = Configuration["SECRET"];

                var isInt = int.TryParse(Configuration["TOKEN_EXPIRES_SECONDS"], out int tokenLiftTime);
                options.TokenLifeTime = isInt ? tokenLiftTime : 1;
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtAuthentication.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JwtAuthentication.WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
