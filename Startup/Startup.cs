using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentManagement.Models;
using StudentManagement.Models.DataManager;
using StudentManagement.Models.Repository;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

using StudentManagement;



namespace StudentManagement
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
            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));

            //services.AddDbContext<DBContext>();


            services.AddScoped<IStudentRepository, StudentManagement.Models.DataManager.StudentManager>();
            services.AddScoped<ILecturerRepository, LecturerManager>();
            services.AddScoped<IClassRepository, ClassManager>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader();
                   
                    policy.AllowAnyMethod();
                    policy.AllowCredentials();
                });
            });

            services.AddControllersWithViews();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Student Management", Version = "v1" });
                options.CustomSchemaIds(type => type.FullName); 
            });


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseCors();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });



        }

    }
}
