using Microsoft.EntityFrameworkCore;
using PetAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Controller'ları ekler (API endpoint'leri için)
builder.Services.AddControllers();

// Swagger/OpenAPI desteği ekler (API dokümantasyonu ve test arayüzü için)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PetDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// VetAPI için başlangıçta özel bir DbContext kaydına gerek yok.
// Veri işlemleri için SystemAPI'ye HTTP çağrıları yapacak.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Geliştirme ortamında Swagger UI'ı etkinleştirir
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTP'den HTTPS'ye yönlendirme yapar
app.UseHttpsRedirection();

// Yetkilendirme middleware'ini ekler (Auth API ile entegrasyon sonrası kullanılacak)
app.UseAuthorization();

// Controller'lardaki endpoint'leri HTTP istekleriyle eşler
app.MapControllers();

app.Run();