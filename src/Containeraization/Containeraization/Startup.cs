using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Operations;
using RepositoryContext;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Containeraization
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
            services.AddDbContext<DataContext>(s=> {
                s.UseSqlServer(Configuration.GetSection("ConnectionStrings:DockerDbConnectionString").Value);
            });
            services.AddScoped<IRepositoryOperation, RepositoryOperation>();
            services.AddScoped<ICompanyService,CompanyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IHealthCheck, HealthCheckService>();
            
            services.AddCors(options=> {

                options.AddPolicy("AllowPolicy", policy => { policy.AllowAnyHeader().WithOrigins("http://localhost:4200", "http://localhost:4201").AllowAnyMethod(); });
            
            });
            services.AddMvc(options => options.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("AllowPolicy");
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("AllowPolicy");
            });

            
            app.UseMvc();

        }
    }
}
