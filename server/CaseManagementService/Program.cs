using CaseManagementService.Interfaces;
using CaseManagementService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Enables Swagger endpoints
builder.Services.AddSwaggerGen(); // Adds Swagger generation

// Register the mock service
builder.Services.AddScoped<ICaseService, MockCaseService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger middleware
    app.UseSwaggerUI(); // Enable Swagger UI
}

// Map controllers
app.MapControllers();

app.Run();
