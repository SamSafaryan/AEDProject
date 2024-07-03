using AEDProject.Entities.Data;
using AEDProject.Interfaces.Repositories;
using AEDProject.Interfaces.Services;
using AEDProject.Repositories;
using AEDProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AEDProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AEDContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AEDProjectDBV5")));
            builder.Services.AddScoped<IDocumentRepo, DocumentRepo>();
            builder.Services.AddScoped<IDocumentService, DocumentService>();
			builder.Services.AddScoped<ICountryRepo, CountryRepo>();
			builder.Services.AddScoped<ICountryService, CountryService>();
			builder.Services.AddScoped<IDocTypeRepo, DocTypeRepo>();
			builder.Services.AddScoped<IDocTypeService, DocTypeService>();
			builder.Services.AddScoped<IImageRepo, ImageRepo>();
			builder.Services.AddScoped<IImageService, ImageService>();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
