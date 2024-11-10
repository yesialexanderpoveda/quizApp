using DB;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<QuizContext>(options =>
{
 options.UseSqlServer(builder.Configuration.GetConnectionString("quizConnection"));

});

builder.Services.AddIdentity<AplicationUser, IdentityRole>()
   .AddEntityFrameworkStores<QuizContext>()
   .AddDefaultTokenProviders(); 

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
   var context = scope.ServiceProvider.GetRequiredService<QuizContext>();
   context.Database.Migrate(); 

}

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

async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
{
    string[] roleNames = { "ADMIN", "USER" };
    foreach (var roleName in roleNames)
    {
        bool roleExists = await roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}