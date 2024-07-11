using Labo_BLL.Interfaces;
using BLL = Labo_BLL.Services;
using Labo_DAL.Repositories;
using DAL = Labo_DAL.Services;
using API_ProjectHammeau.Tools;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Data.SqlClient;
using API_ProjectHammeau.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddTransient(sp => new SqlConnection(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IUserRepo, DAL.UserService>();
builder.Services.AddScoped<IUserService, BLL.UserServices>();

builder.Services.AddScoped<TokenGenerator>();
builder.Services.AddCors(b => b.AddDefaultPolicy(o => {
    o.WithOrigins("http://localhost:4200");
    o.AllowCredentials();
    o.AllowAnyMethod();
    o.AllowAnyHeader();
    }));

//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//   .AddNegotiate();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    builder.Configuration.GetSection("TokenInfo").GetSection("secretKey").Value)),
                ValidateLifetime = true,
                ValidAudience = "https://monclient.com",
                ValidIssuer = "https://monapi.com",
                ValidateAudience = false
            };
        }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adminPolicy", policy => policy.RequireRole("admin"));
    //options.AddPolicy("modoPolicy", policy => policy.RequireRole("admin", "moderator"));
    //options.AddPolicy("adminPolicy", policy => policy.RequireClaim("UserId", "1");
    options.AddPolicy("isConnectedPolicy", policy => policy.RequireAuthenticatedUser());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<GamesHub>("/gameshub");
app.Run();
