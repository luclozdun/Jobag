using System.Reflection;
using Jobag.src.Shared.Domain.Repository;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Resume.Infraestructure.Repositories;

namespace jobag_api_ddd
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
            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseInMemoryDatabase("asd");
            });

            services.AddScoped<IPostulantRepository, PostulantRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISkillPostulantRepository, SkillPostulantRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddControllersWithViews();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
