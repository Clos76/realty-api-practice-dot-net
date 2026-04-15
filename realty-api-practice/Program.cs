using Microsoft.EntityFrameworkCore;
using realty_api_practice.Entities.Data;
using realty_api_practice.Repositories;
using realty_api_practice.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// ✅ Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Repositories — must be here, BEFORE builder.Build()
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();

// ✅ Services — must be here, BEFORE builder.Build()
builder.Services.AddScoped<IPropertyService, PropertyService>();

var app = builder.Build(); // ← everything above this, nothing below

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();