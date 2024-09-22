using LibraryApp.Business.Concrete;
using LibraryApp.Business.Contracts;
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

builder.Services.AddScoped<IUserDao, InMemoryUserDao>();
builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddScoped<IBookDao, InMemoryBookDao>();
builder.Services.AddScoped<IBookService, BookManager>();

builder.Services.AddScoped<IAuthorDao, InMemoryAuthorDao>();
builder.Services.AddScoped<IAuthorService, AuthorManager>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseAuthentication();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();



app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(name: "admin", areaName: "Admin", pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
