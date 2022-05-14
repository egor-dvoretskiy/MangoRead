using MangoRead.DAL;
using MangoRead.DAL.Interfaces;
using MangoRead.DAL.Repositories;
using MangoRead.DAL.SeedData;
using MangoRead.Domain.Models.Account;
using MangoRead.Middlewares;
using MangoRead.Service.Implementations;
using MangoRead.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionStringContent = builder.Configuration.GetConnectionString("MangoReadContext");
string connectionStringAccountDb = builder.Configuration.GetConnectionString("AccountDbContext");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionStringContent, b => b.MigrationsAssembly("MangoRead.DAL")));
builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseSqlServer(connectionStringAccountDb, b => b.MigrationsAssembly("MangoRead.DAL")));

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(opts =>
{
    opts.Password.RequiredLength = 3;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
})
    .AddEntityFrameworkStores<AccountDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IManuscriptService, ManuscriptService>();
builder.Services.AddScoped<IManuscriptRepository, ManuscriptRepository>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

var app = builder.Build();

string contentFolderPath = builder.Configuration.GetValue<string>("StaticFilesConfiguration:ContentFolderPath");
string requestedFolderPath = builder.Configuration.GetValue<string>("StaticFilesConfiguration:RequestedFolderPath");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    SeedData.Initialize(services, contentFolderPath);
    await RolesSeed.SeedRolesAsync(userManager, roleManager);
    await RolesSeed.SeedSuperAdminAsync(userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.SetFolders(contentFolderPath);
app.SetFolders(requestedFolderPath);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
