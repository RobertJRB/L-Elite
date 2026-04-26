using Microsoft.EntityFrameworkCore;
using ReservasMesas.Application.Interfaces;
using ReservasMesas.Application.Services;
using ReservasMesas.Infrastructure.Data;
using ReservasMesas.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AreaRepository>();
builder.Services.AddScoped<MesaRepository>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ReservaRepository>();

builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IMesaService, MesaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IReservaService, ReservaService>();

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();