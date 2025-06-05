using Global_Solution.Application.Interface;
using Global_Solution.Application.Services;
using Global_Solution.Domain.Interface;
using Global_Solution.Domain.Interfaces;
using Global_Solution.Infrastructure.Data.AppData;
using Global_Solution.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(connectionString)
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information));

// Application Services
builder.Services.AddScoped<IAlertaApplication, AlertaApplication>();
builder.Services.AddScoped<IAreaRiscoApplication, AreaRiscoApplication>();
builder.Services.AddScoped<IInscricaoAlertaApplication, InscricaoAlertaApplication>();
builder.Services.AddScoped<ILeituraSensorApplication, LeituraSensorApplication>();
builder.Services.AddScoped<INotificacaoApplication, NotificacaoApplication>();
builder.Services.AddScoped<ISensorApplication, SensorApplication>();
builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();

// Domain Repositories
builder.Services.AddScoped<IAlertaRepository, AlertaRepository>();
builder.Services.AddScoped<IAreaRiscoRepository, AreaRiscoRepository>();
builder.Services.AddScoped<IInscricaoAlertaRepository, InscricaoAlertaRepository>();
builder.Services.AddScoped<ILeituraSensorRepository, LeituraSensorRepository>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Swagger (API docs)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
