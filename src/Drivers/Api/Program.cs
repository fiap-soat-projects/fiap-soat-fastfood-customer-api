using Adapter;
using Api.Middlewares;
using Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddAdapters();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
