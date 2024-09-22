using Autofac;
using Autofac.Extensions.DependencyInjection;
using LibraryApp.Business.Concrete;
using LibraryApp.Business.Contracts;
using LibraryApp.Business.DependecyResolvers.Autofac;
using LibraryApp.DataAccess.Concrete.InMemory;
using LibraryApp.DataAccess.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");
});

// Add services to container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AfBusinessModule()));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseAuthentication();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(name: "admin", areaName: "Admin", pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
