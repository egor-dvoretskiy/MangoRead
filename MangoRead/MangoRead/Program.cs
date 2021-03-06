using MangoRead.DAL;
using MangoRead.DAL.Interfaces;
using MangoRead.DAL.Repositories;
using MangoRead.DAL.SeedData;
using MangoRead.Middlewares;
using MangoRead.Service.Implementations;
using MangoRead.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MangoReadContext");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MangoRead.DAL")));

builder.Services.AddScoped<IManuscriptService, ManuscriptService>();
builder.Services.AddScoped<IManuscriptRepository, ManuscriptRepository>();

var app = builder.Build();

string contentFolderPath = builder.Configuration.GetValue<string>("StaticFilesConfiguration:ContentFolderPath");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services, contentFolderPath);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.SetContentFolders(contentFolderPath);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
