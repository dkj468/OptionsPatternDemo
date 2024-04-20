using API.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FileOptions = API.Options.FileOptions;

var builder = WebApplication.CreateBuilder(args);

// add controllers 
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .Configure<FileOptions>(builder.Configuration.GetSection("file"));
builder.Services
       .AddOptions<FileOptions>().Bind(builder.Configuration.GetSection("file"));



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
