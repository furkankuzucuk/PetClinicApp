using Microsoft.EntityFrameworkCore;
using NotifyAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Controller'ları ekler (API endpoint'leri için)
builder.Services.AddControllers();

// Swagger/OpenAPI desteği ekler (API dokümantasyonu ve test arayüzü için)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NotifyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// NotifyAPI için başlangıçta özel bir DbContext kaydına gerek yok
// Eğer bildirim loglama veya şablonlar için DB kullanmak isterseniz buraya eklenir.

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