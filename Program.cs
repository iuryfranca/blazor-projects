using AppConcurso.Context;
using AppConcurso.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<CargoService>();
builder.Services.AddScoped<CandidatoService>();
builder.Services.AddScoped<InscricaoService>();
builder.Services.AddScoped<SideMenuService>();
builder.Services.AddScoped<IFlowbiteService, FlowbiteService>();
builder.Services.AddScoped<ToastService>();

string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<ContextDB>(options =>
    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/layout/_Host");

app.Run();
