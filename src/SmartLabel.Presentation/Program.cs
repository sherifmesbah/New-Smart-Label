using Microsoft.Extensions.FileProviders;
using SmartLabel.Infrastructure;
using SmartLabel.Application;
using SmartLabel.Presentation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services
	.AddInfrastructures(builder.Configuration)
	.AddApplications();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		Path.Combine(builder.Environment.WebRootPath, "Uploads")),
	RequestPath = "/Uploads"
});
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
