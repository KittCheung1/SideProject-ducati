using DucatiWebApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var AllowMySpecificOrigins = "_allowMySpecificOrigins";



builder.Services.AddDbContext<DucatiWebApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DucatiWebApiContext")));

builder.Services.AddScoped(p =>
{
    var context = p.GetRequiredService<IDbContextFactory<DucatiWebApiContext>>().CreateDbContext();
    context.Database.EnsureCreated();

    return context;
});

builder.Services
.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    };
});
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowMySpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500").AllowAnyMethod().AllowAnyHeader();

                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowMySpecificOrigins);

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
