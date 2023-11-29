using Microsoft.EntityFrameworkCore;
using RHMVC.Interface;
using RHMVC.Models;
using static RHMVC.Interface.IUsuarioAutenticadoService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor(); // Adicione esta linha para permitir a injeção do IHttpContextAccessor
builder.Services.AddSingleton<IUsuarioAutenticadoService, UsuarioAutenticadoService>();
builder.Services.AddScoped<FolhaService>();
builder.Services.AddScoped<VerificaLogin>();
builder.Services.AddScoped<DescontoService>();
builder.Services.AddScoped<Usuario>();
// Adicione esta linha para configurar o serviço FolhaService

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer("Password=sa4321!;Persist Security Info=True;User ID=sa;Initial Catalog=rh_pim;Data Source=SERVER\\SQLEXPRESS; TrustServerCertificate=True"));

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
    pattern: "{controller=AcessoLogin}/{action=Index}/{id?}");

app.Run();
