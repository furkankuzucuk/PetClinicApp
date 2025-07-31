using AuthAPI.Data;
using AuthAPI.Repositories;
using AuthAPI.Repositories.Interfaces;
using AuthAPI.Services;
using AuthAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetClinicApp.Shared.Data.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Veritabanı bağlantısı (AuthDb)
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2️⃣ JWT Authentication ayarları
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // PROD ortamında true olmalı ve Issuer belirtilmeli
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "default_key_for_dev"))
        };
    });
 builder.Services.AddHttpClient("SystemAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5108"); // SystemAPI'nin çalıştığı PORT! 🔥
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
   

// 3️⃣ Controller & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


// 4️⃣ Servis ve Repository Dependency Injection
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>(); // Identity şifreleme

var app = builder.Build();

// 🧪 Swagger UI (sadece dev ortamında açık)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ⛓️ Middleware Pipeline
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
