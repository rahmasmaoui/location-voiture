using location_voiture.Data;
using location_voiture.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
// =========================================================================
// 1. CONFIGURATION DU DBCONTEXT AVEC SQL SERVER LOCALDB
// =========================================================================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajout du support pour Contrôleurs et Vues MVC
// Add services to the container.
builder.Services.AddControllersWithViews();
// 3. Enregistrement du Repository dans le conteneur IoC
builder.Services.AddScoped<ICategoryVoitureRepository, CategoryVoitureRepository>();
var app = builder.Build();

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

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
