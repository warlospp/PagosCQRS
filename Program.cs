using Microsoft.EntityFrameworkCore;
using PagosCQRS.Commands;
using PagosCQRS.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pagos API", Version = "v1" });
});

builder.Services.AddDbContext<CommandDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CommandConnection")));

builder.Services.AddDbContext<QueryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QueryConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pagos API v1"));
}

app.MapControllers();
app.Run();



