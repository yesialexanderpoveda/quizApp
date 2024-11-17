using DB;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
// Usa los namespaces correctos para tus interfaces y repositorios
using IRepository; // Cambia según tu estructura de proyecto
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<QuizContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("quizConnection"));
});

// Registra ITemporalQuestions y TemporalQRepository
builder.Services.AddScoped(typeof(ITemporalQuestions<>), typeof(TemporalQRepository<>));



builder.Services.AddIdentity<AplicationUser, IdentityRole>()
   .AddEntityFrameworkStores<QuizContext>()
   .AddDefaultTokenProviders();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<QuizContext>();
    context.Database.Migrate(); 
}

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // Crear roles ADMIN y USER si no existen
    string[] roleNames = { "ADMIN", "USER" };
    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
