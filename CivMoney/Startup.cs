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
            if (Env.IsDevelopment())
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL") + ";sslmode=Prefer;Trust Server Certificate=true"));
            }

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

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}
