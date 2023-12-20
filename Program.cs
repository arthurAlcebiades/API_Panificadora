using API_Panificadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Panificadora.Data;
using System.Configuration;
using API_Panificadora.Repositorio;

var builder = WebApplication.CreateBuilder(args);
/*
builder.Services.AddDbContext<API_PanificadoraContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("API_PanificadoraContext") ?? throw new InvalidOperationException("Connection string 'API_PanificadoraContext' not found.")));
*/
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddDbContext<Contexto>
// (options => options.UseSqlServer
//("Data Source=localhost\\SQLEXPRESS;Database=PANIFICADORA;Trusted_Connection=True;TrustServerCertificate=true;\""));

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

 void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    services.Configure<CookiePolicyOptions>(options =>
    {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services.AddDbContext<AppContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("API_PanificadoraContext")));

    services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

    services.AddMvc();

}
