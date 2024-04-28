using API.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OptionsPatternDemo.Options;
using FileOptions = API.Options.FileOptions;

var builder = WebApplication.CreateBuilder(args);


// add controllers 
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddCommandLine(args);


//with custom validation logic

//builder.Services
//       .AddOptions<FileOptions>().Bind(builder.Configuration.GetSection("file"))
//       .ValidateDataAnnotations()
//       .Validate(fileOptions => {
//           if (string.IsNullOrEmpty(fileOptions.FileType))
//           {
//               return false;
//           }
//           return true;
//       });

//validate on start-up
builder.Services
       .AddOptions<FileOptions>().Bind(builder.Configuration.GetSection(FileOptions.Key))
       .ValidateDataAnnotations()
       .ValidateOnStart();

// using IConfigureOptions -- manage other than appsettings configs
//builder.Services.ConfigureOptions<FileOptionsSetup>();




var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
