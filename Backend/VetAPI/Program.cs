using Microsoft.EntityFrameworkCore;
using VetAPI.Data;
using VetAPI.Repositories;
using VetAPI.Services;
using VetAPI.Services.Interfaces;
using VetAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 💾 DbContext - SQL Server bağlantısı
builder.Services.AddDbContext<VetDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🧩 Dependency Injection
builder.Services.AddScoped<IVetRepository, VetRepository>();
builder.Services.AddScoped<IVetService, VetService>();
builder.Services.AddScoped<IExaminationRepository, ExaminationRepository>();
builder.Services.AddScoped<IExaminationService, ExaminationService>();



// 🌐 HttpClient - SystemAPI iletişimi için
builder.Services.AddHttpClient("SystemAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5108");
});

// 🔧 Controller ve Swagger/OpenAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔐 (Gelecekte JWT için hazır)
builder.Services.AddAuthorization();

var app = builder.Build();

// 📦 Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
