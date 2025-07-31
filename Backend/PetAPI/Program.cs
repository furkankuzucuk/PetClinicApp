using Microsoft.EntityFrameworkCore;
using PetAPI.Data;
using PetAPI.Repositories;
using PetAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Services Configuration
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 💾 DbContext - SQL Server bağlantısı
builder.Services.AddDbContext<PetDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🧩 Dependency Injection
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IPetService, PetService>();

// 🔐 İleride AuthAPI JWT doğrulaması için hazırlanabilir
builder.Services.AddAuthorization();

var app = builder.Build();

// 🌍 Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
