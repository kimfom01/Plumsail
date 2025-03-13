using Microsoft.EntityFrameworkCore;
using Plumsail.Database;
using Plumsail.Endpoints;
using Plumsail.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("TempDb"));
builder.Services.AddScoped<IEntityService, EntityService>();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUi(options => options.DocumentPath = "/openapi/v1.json");

app.UseHttpsRedirection();

app.MapEntityEndpoints();

app.Run();