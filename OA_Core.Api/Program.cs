using OA_Core.Api.Filters;
using OA_Core.Domain.Config;
using OA_Core.Domain.Interfaces.Notifications;
using OA_Core.Domain.Interfaces.Repository;
using OA_Core.Domain.Interfaces.Service;
using OA_Core.Domain.Notifications;
using OA_Core.Repository.Context;
using OA_Core.Repository.Repositories;
using OA_Core.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

#region AutoMapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region appConfig

var appConfig = builder.Configuration.GetSection(nameof(AppConfig)).Get<AppConfig>();
builder.Services.AddSingleton(appConfig);

#endregion

#region Filtros

builder.Services.AddMvc(options =>
{
    options.Filters.Add<NotificatonFilter>();
    options.Filters.Add<ExceptionFilter>();
});

#endregion

#region Injecao de dependencias

builder.Services.AddScoped<DapperDbConnection>();
builder.Services.AddScoped<INotificador, Notificador>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

#endregion

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
