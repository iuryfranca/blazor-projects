using AppConcurso.Data;
using LearningBlazor.Context;
using LearningBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Injeção de dependências
builder.Services.AddScoped<CargoService>();
builder.Services.AddScoped<CandidatoService>();
builder.Services.AddScoped<InscricaoService>();

string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<ContextDB>(options =>
    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
