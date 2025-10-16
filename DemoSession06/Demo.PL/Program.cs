using AutoMapper;
using Demo.BLL.MappingProfiles;
using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Contexts;
using Demo.DAL.Repositories.Classes;
using Demo.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services : Add services to the DI container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ApplicationDbContext>(); // Register service 
            //Give CLR permission to inject this service if needed


            builder.Services.AddDbContext<ApplicationDbContext>(options=>
              {
                  var ConString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(ConString);
              });
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            //builder.Services.AddScoped<IMapper, Mapper>();
            //builder.Services.AddAutoMapper(nameof(MappingProfiles).assembly);XXXXXXXXXXXXXXXX
            builder.Services.AddAutoMapper(m => m.AddProfile(new MappingProfiles()));

            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            } 

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
