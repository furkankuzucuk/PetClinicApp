using SystemAPI.Data; // SystemDbContext'in bulunduğu namespace
using Microsoft.EntityFrameworkCore; // AddDbContext uzantı metodu için

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Controller'ları ekler (API endpoint'leri için)
builder.Services.AddControllers();

// Swagger/OpenAPI desteği ekler (API dokümantasyonu ve test arayüzü için)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SystemDbContext'i bağımlılık enjeksiyonuna (DI) kaydediyoruz
// appsettings.json dosyasındaki "ConnectionStrings:DefaultConnection" değerini kullanır
builder.Services.AddDbContext<SystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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