using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using CivMoney.Data;
using CivMoney.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using CivMoney.Services;
using CivMoney.DataAccess;
using CivMoney.DataAccess.Contracts;
using System;

namespace CivMoney
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Env = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(GetAndParsePostgresConnectionString()));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllers();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITransactionService, TransactionService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {              
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
                UpdateDatabase(app);
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string GetAndParsePostgresConnectionString()
        {
            string postgresConnectionUrl;

            if (Env.IsDevelopment())
            {
                postgresConnectionUrl = Configuration.GetConnectionString("DefaultConnection");
            }
            else
            {
                postgresConnectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            }

            var isUri = Uri.TryCreate(postgresConnectionUrl, UriKind.Absolute, out var uri);

            if (!isUri) throw new Exception($"'{postgresConnectionUrl}' is not a valid postgres URL to be parsed.");

            return
                $"Server={uri.Host};Port={uri.Port};User Id={uri.UserInfo.Split(':')[0]};Password={uri.UserInfo.Split(':')[1]};Database={uri.LocalPath.Substring(1)};sslmode=Prefer;Trust Server Certificate=true";
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}
